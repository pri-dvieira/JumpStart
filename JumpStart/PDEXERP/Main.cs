using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDEXERP
{
    public class Main
    {
        #region Constructor

        public Main(dynamic BSO, dynamic PSO)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            Globals.BSO = BSO;
            Globals.PSO = PSO;
        }

        private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string assemblyFullName;

            System.Reflection.AssemblyName assemblyName;

            const string PRIMAVERA_FOLDER = "PRIMAVERA\\SG100\\Apl";

            assemblyName = new System.Reflection.AssemblyName(args.Name);
            assemblyFullName = System.IO.Path.Combine(System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), PRIMAVERA_FOLDER), assemblyName.Name + ".dll");

            if (System.IO.File.Exists(assemblyFullName))
                return System.Reflection.Assembly.LoadFrom(assemblyFullName);
            else
                return null;
        }

        #endregion Constructor

        readonly string TDU_Cabimentacao = "TDU_PDEXCabimentacao";

        /// <summary>
        /// Percorre todos os documentos sem cabimentação e efetua o respectivo pedido.
        /// </summary>
        public void DocCabimentacao()
        {
            try
            {
                string sql = string.Format("SELECT * FROM {0} WHERE CDU_NumCab IS NULL", TDU_Cabimentacao);
                StdBE100.StdBELista docs = Globals.BSO.Consulta(sql);

                while (!docs.NoFim())
                {
                    CreateCabimento(docs.Valor("CDU_DocId").ToString());
                    docs.Seguinte();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateCabimento(string DocId)
        {
            try
            {
                PDEXLib.PDEXRequester pDEXRequester = new PDEXLib.PDEXRequester();

                PDEXLib.Cabimento cabimento = pDEXRequester.GetCabimento();

                if (cabimento != null)
                {
                    StdBE100.StdBECamposChave camposChave = new StdBE100.StdBECamposChave();
                    camposChave.AddCampoChave("CDU_DocId", DocId);

                    StdBE100.StdBERegistoUtil registo = Globals.BSO.TabelasUtilizador.Edita(TDU_Cabimentacao, camposChave);
                    registo.Campos["CDU_NumCab"].Valor = cabimento.p_cab_des_id;

                    Globals.BSO.TabelasUtilizador.Actualiza(TDU_Cabimentacao, registo);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primavera.Extensibility.BusinessEntities;
using Primavera.Extensibility.Base.Editors;
using Primavera.Extensibility.BusinessEntities.ExtensibilityService.EventArgs;
using CmpBE100;

namespace Primavera.Extensibilidade
{
    public class UiFichaFornecedores :FichaFornecedores
    {
        public override void AntesDeGravar( ref bool Cancel, ExtensibilityEventArgs e)
        {
            

            CmpBEDocumentoCompra Linha = new CmpBEDocumentoCompra();

            if ((BSO.Base.ArtigosFornecedores.Existe( strArtigo: "A0001",strFornecedor:"DANIEL")))
               
            {
                PSO.Dialogos.MostraDialogoEspera("Continuar com a gravacao do documento");

                if (Cancel==false)
                {
                    PSO.Dialogos.MostraDialogoEspera("Todas as operacoes deve ser cancelada");
                }
            }  



            }

    }
}

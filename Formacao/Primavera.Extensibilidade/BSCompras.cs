using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmpBE100;
using Primavera.Extensibility.BusinessEntities;
using Primavera.Extensibility.BusinessEntities.ExtensibilityService.EventArgs;
using Primavera.Extensibility.Purchases.Services;

namespace Primavera.Extensibilidade
{
    public class BSCompras : CmpBSCompras
    {
        public override void AntesDeGravar(CmpBEDocumentoCompra clsDocCompra, ref string strAvisos, ref string IdDocLiqRet, ref string IdDocLiqRetGar, ExtensibilityEventArgs e)
        {
            string artigo = "";
            StringBuilder artigonaocompradosFornecedores = new StringBuilder();

            for (int i = 1; i < clsDocCompra.Linhas.NumItens; i++)
            {
                artigo = clsDocCompra.Linhas.GetEdita(i).Artigo;

                if (!BSO.Base.ArtigosFornecedores.Existe(artigo, clsDocCompra.Entidade))
                {
                    artigonaocompradosFornecedores.Append(artigo);
                }
            }

            if (artigonaocompradosFornecedores.Length > 0)
            {
                if (PSO.Dialogos.MostraMensagem(StdPlatBS100.StdBSTipos.TipoMsg.PRI_SimNao, "Existem artigos que não pertencem ao fornecedor, continuar?", StdPlatBS100.StdBSTipos.IconId.PRI_Questiona, artigonaocompradosFornecedores.ToString(), 1, true) == StdPlatBS100.StdBSTipos.ResultMsg.PRI_Nao)
                {
                    throw new Exception("Cancelado pelo Utilizador");
                }
            }
        }
    }
}

using System;
using CmpBE100;
using Primavera.Extensibility.BusinessEntities.ExtensibilityService.EventArgs;
using Primavera.Extensibility.Purchases.Services;
using StdBE100;

namespace PDEX.Extensibility
{
    public class BsCompras : CmpBSCompras
    {
        public override void DepoisDeGravar(CmpBEDocumentoCompra clsDocCompra, ref string strAvisos, ref string IdDocLiqRet, ref string IdDocLiqRetGar, ExtensibilityEventArgs e)
        {
            //if (Globals.globalFunctions.DocSujeitoCabimentacao(clsDocCompra.Tipodoc))
            //{
            //    // Regista documento para cabimentação
            //    if (Globals.globalFunctions.DocElegivelCabimentacao(clsDocCompra))
            //    {
            //        RegistaParaCabimentacao(clsDocCompra, ref strAvisos);
            //    }
            //}

            RegistaParaCabimentacao(clsDocCompra, ref strAvisos);
        }

        /// <summary>
        /// Regista documento de compra para cabimentação.
        /// </summary>
        /// <param name="documentoCompra">Documento de compra.</param>
        /// <param name="Avisos">Devolve erros encontrados caso não efetue o registo.</param>
        private void RegistaParaCabimentacao(CmpBEDocumentoCompra documentoCompra, ref string Avisos)
        {
            try
            {
                bool criaNovaCabimentacao = true;

                // Inicializa um objeto para atualizar a cabimentação
                StdBERegistoUtil registo = DaRegistoCabimentacao(documentoCompra);

                if (registo.EmModoEdicao)
                {
                    criaNovaCabimentacao = (PSO.Utils.FInt(registo.Campos["CDU_NumCab"].Valor) > 0);
                }

                if (criaNovaCabimentacao)
                {
                    // Identificação do documento
                    registo.Campos["CDU_DocId"].Valor = documentoCompra.ID;
                    registo.Campos["CDU_TipoDoc"].Valor = documentoCompra.Tipodoc;
                    registo.Campos["CDU_Serie"].Valor = documentoCompra.Serie;
                    registo.Campos["CDU_NumDoc"].Valor = documentoCompra.NumDoc;
                    registo.Campos["CDU_Documento"].Valor = documentoCompra.Documento;

                    registo.Campos["CDU_NumDocExterno"].Valor = documentoCompra.NumDocExterno;
                    registo.Campos["CDU_DataDoc"].Valor = documentoCompra.DataDoc;

                    registo.Campos["CDU_TipoEntidade"].Valor = documentoCompra.TipoEntidade;
                    registo.Campos["CDU_Entidade"].Valor = documentoCompra.Entidade;
                    registo.Campos["CDU_NumContribuinte"].Valor = documentoCompra.NumContribuinte;
                    registo.Campos["CDU_Moeda"].Valor = documentoCompra.Moeda;
                    registo.Campos["CDU_CondPag"].Valor = documentoCompra.CondPag;
                    registo.Campos["CDU_Observacoes"].Valor = documentoCompra.Observacoes;

                    foreach (CmpBELinhaDocumentoCompra linha in documentoCompra.Linhas)
                    {
                        if (!string.IsNullOrWhiteSpace(linha.Artigo))
                        {
                            registo.Campos["CDU_FonteFinancCBL"].Valor = linha.FonteCBL;
                            registo.Campos["CDU_OrganicaCBL"].Valor = linha.OrganicaCBL;
                            registo.Campos["CDU_ClasseEcon"].Valor = linha.ClassEconCBL;

                            break;
                        }
                    }

                    BSO.TabelasUtilizador.Actualiza(Globals.TDU_Cabimentacao, registo);

                    CriaTarefaAsync();
                }
            }
            catch (Exception ex)
            {
                Avisos = "Ocorreu um erro ao registar o documento para cabimentação." + Environment.NewLine + ex.Message;
            }
        }

        private StdBERegistoUtil DaRegistoCabimentacao(CmpBEDocumentoCompra documentoCompra)
        {
            StdBERegistoUtil registo;

            // Chave fisica da tabela
            StdBECamposChave camposChave = new StdBECamposChave();
            camposChave.AddCampoChave("CDU_DocId", documentoCompra.ID);

            if (BSO.TabelasUtilizador.Existe(Globals.TDU_Cabimentacao, camposChave))
            {
                // Registo existe, edita
                registo = BSO.TabelasUtilizador.Edita(Globals.TDU_Cabimentacao, camposChave);
            }
            else
            {
                // Novo registo
                registo = new StdBERegistoUtil();
            }

            return registo;
        }

        private void CriaTarefaAsync()
        {
            string topicId = "PDEXTopic";
            string taskId = "GeneratePDEXMessages";
            string pipeline = "PDEXTopicPipeline";

            string parametros = PSO.Strings.Formata("topicId=@1@|taskId=@2@|EnterpriseFilter=@3@|InstanceId=@4@", topicId, taskId, BSO.Contexto.CodEmp, BSO.Contexto.Instancia);
            PSO.Bot.CriaTarefa(topicId, taskId, pipeline, parametros);
        }

    }
}

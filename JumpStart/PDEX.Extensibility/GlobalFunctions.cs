using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmpBE100;
using Primavera.Extensibility.BusinessEntities;
using Primavera.Extensibility.CustomCode;

namespace PDEX.Extensibility
{
    public class GlobalFunctions
    {
        private readonly ErpBS100.ErpBS BSO = null;
        private readonly StdPlatBS100.StdBSInterfPub PSO = null;
        
        public GlobalFunctions(ErpBS100.ErpBS bso, StdPlatBS100.StdBSInterfPub pso)
        {
            BSO = bso;
            PSO = pso;
        }

        public bool DocSujeitoCabimentacao(string tipoDoc)
        {
            bool result = false;

            try
            {
                CmpBETabCompra tabCompra = BSO.Compras.TabCompras.Edita(tipoDoc);

                if (tabCompra != null)
                {
                    // Apenas válido para documentos financeiros com natureza a pagar
                    if ((tabCompra.TipoDocumento == 4) && (tabCompra.PagarReceber == "P"))
                    {
                        result = PSO.Utils.FBool(BSO.Compras.TabCompras.DaValorAtributo(tipoDoc, "CDU_SujeitoCabimentacao"));
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Valida se todas as linhas têm os mesmos valores na FonteCBL, ClasseEconomica e Organica para cabimentação
        /// </summary>
        /// <param name="documentoCompra">Documento de compra.</param>
        /// <returns>True - Documento elegível; False - Documento não elegível</returns>
        public bool DocElegivelCabimentacao(CmpBEDocumentoCompra documentoCompra)
        {
            string avisos = string.Empty;
            return DocElegivelCabimentacao(documentoCompra, ref avisos);
        }

        /// <summary>
        /// Valida se todas as linhas têm os mesmos valores na FonteCBL, ClasseEconomica e Organica para cabimentação
        /// </summary>
        /// <param name="documentoCompra">Documento de compra.</param>
        /// <param name="avisos">Devolve os avisos encontrados.</param>
        /// <returns>True - Documento elegível; False - Documento não elegível</returns>
        public bool DocElegivelCabimentacao(CmpBEDocumentoCompra documentoCompra, ref string avisos)
        {
            avisos = string.Empty;

            string fonteCBL = string.Empty;
            string organicaCBL = string.Empty;
            string classEconCBL = string.Empty;

            int numLinha = 1;
            foreach (CmpBELinhaDocumentoCompra linha in documentoCompra.Linhas)
            {
                if (!string.IsNullOrWhiteSpace(linha.Artigo))
                {
                    // FontCBL
                    if (string.IsNullOrWhiteSpace(linha.FonteCBL))
                    {
                        avisos = string.Format("Não está definida a fonte de financiamento na linha nº {0}.", numLinha.ToString()) + Environment.NewLine;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(fonteCBL) && (fonteCBL != linha.FonteCBL))
                        {
                            avisos = string.Format("A fonte de financiamento da linha nº {0} difere da anterior.", numLinha.ToString()) + Environment.NewLine;
                        }
                    }

                    // OrganicaBL
                    if (string.IsNullOrWhiteSpace(linha.OrganicaCBL))
                    {
                        avisos = string.Format("Não está definida a classe orgânica na linha nº {0}.", numLinha.ToString()) + Environment.NewLine;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(organicaCBL) && (organicaCBL != linha.OrganicaCBL))
                        {
                            avisos = string.Format("A classe orgânica da linha nº {0} difere da anterior.", numLinha.ToString()) + Environment.NewLine;
                        }
                    }

                    // ClassEconCBL
                    if (string.IsNullOrWhiteSpace(linha.ClassEconCBL))
                    {
                        avisos = string.Format("Não está definida a classe económica na linha nº {0}.", numLinha.ToString()) + Environment.NewLine;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(classEconCBL) && (classEconCBL != linha.ClassEconCBL))
                        {
                            avisos = string.Format("A classe económica da linha nº {0} difere da anterior.", numLinha.ToString()) + Environment.NewLine;
                        }
                    }

                    fonteCBL = linha.FonteCBL;
                    organicaCBL = linha.OrganicaCBL;
                    classEconCBL = linha.ClassEconCBL;
                }

                numLinha++;
            }

            return string.IsNullOrWhiteSpace(avisos);
        }
    }
}

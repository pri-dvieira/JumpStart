using System;
using Primavera.Extensibility.BusinessEntities.ExtensibilityService.EventArgs;
using Primavera.Extensibility.Purchases.Editors;


namespace PDEX.Extensibility
{
    public class UiEditorCompras : EditorCompras
    {
        public override void AntesDeGravar(ref bool Cancel, ExtensibilityEventArgs e)
        {
            //string avisos = string.Empty;

            //// Valida se todas as linhas têm os mesmos valores na FonteCBL, ClasseEconomica e Organica para cabimentação
            //if (Globals.globalFunctions.DocSujeitoCabimentacao(DocumentoCompra.Tipodoc))
            //{
            //    if (!Globals.globalFunctions.DocElegivelCabimentacao(DocumentoCompra, ref avisos))
            //    {
            //        string msg = string.Format("O documento {0} está sujeito a cabimentação mas existem condições que o impedem!", this.DocumentoCompra.Tipodoc) + Environment.NewLine + "Continuar com a gravação do documento?";
            //        Cancel = (PSO.Dialogos.MostraMensagem(StdPlatBS100.StdBSTipos.TipoMsg.PRI_SimNao, msg, StdPlatBS100.StdBSTipos.IconId.PRI_Questiona, avisos, 1, !string.IsNullOrWhiteSpace(avisos)) == StdPlatBS100.StdBSTipos.ResultMsg.PRI_Nao);
            //    }
            //}
        }
    }
}

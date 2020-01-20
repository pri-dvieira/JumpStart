using System;
using System.Text;
using Primavera.Extensibility.CustomForm;
using PRISDK100;
using StdBE100;
using UpgradeHelpers.Spread;

namespace PDEX.Extensibility
{
    public partial class frmCabimentacao : CustomForm
    {
        // Menus contexto grelha
        private const string BANDA_Sigof = "BandaSigof";
        private const string BANDA_Cabimentacao = "BandaCabimentacao";

        private const string MNU_Cabimentacao = "mnuCabimentacao";
        private const string MNU_PedirNumCab = "mnuPedirNumCab";
        private const string MNU_PedirTodosNumCab = "mnuPedirTodosNumCab";
        private const string MNU_ConsultarCab = "mnuConsultarCab";
        private const string MNU_ConsultarTodosCab = "mnuConsultarTodosCab";

        // Column name consts
        // Normal columns
        private const string colTipoDoc = "cab.CDU_TipoDoc";
        private const string colSerie = "cab.CDU_Serie";
        private const string colNumDoc = "cab.CDU_NumDoc";
        private const string colDocumento = "cab.CDU_Documento";
        private const string colNumDocExterno = "cab.CDU_NumDocExterno";
        private const string colDataDoc = "cab.CDU_DataDoc";

        private const string colEntidade = "cab.CDU_Entidade";
        private const string colNomeEntidade = "ent.Nome";
        private const string colNumContribuinte = "cab.CDU_NumContribuinte";

        private const string colMoeda = "cab.CDU_Moeda";
        private const string colCondPag = "cab.CDU_CondPag";

        private const string colFonteFinancCBL = "cab.CDU_FonteFinancCBL";
        private const string colOrganicaCBL = "cab.CDU_OrganicaCBL";
        private const string colClasseEcon = "cab.CDU_ClasseEcon";

        private const string colNumCab = "cab.CDU_NumCab";
        private const string colEstadoCab = "cab.CDU_EstadoCab";

        private const string colObservacoes = "cab.CDU_Observacoes";

        // Calculated column
        //private const string colDiasAtraso = "DiasAtraso = DATEDIFF(d, GETDATE(), DataVenc)";
        // Hidden column
        private const string colDocId = "cab.CDU_DocId";
        private const string colTipoEntidade = "cab.CDU_TipoEntidade";

        private bool controlsInitialized;
        private string categoriaEntidade = "mntTabFornecedores";

        /// <summary>
        /// Private constructor
        /// </summary>
        public frmCabimentacao()
        {
            InitializeComponent();
        }

        #region Events        

        /// <summary>
        /// Form load
        /// </summary>
        private void frmDemoGrid_Load(object sender, EventArgs e)
        {
            // Initialize the SDK context
            PriSDKContext.Initialize(BSO, PSO);

            // Initialize SDK controls
            InitializeSDKControls();

            // Initialize the grid
            InitializeGrid();            
        }

        private void frmDemoGrid_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            try
            {
                //Ensure that resources released.                
                tiposEntidade1.Termina();
                f41.Termina();
                filtroEntidades1.Termina();
                grelhaCabimentacao.Termina();

                controlsInitialized = false;
            }
            catch { }
        }

        private void ActualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
            }
            catch (Exception ex)
            {
                PSO.Dialogos.MostraErroSimples("", StdPlatBS100.StdBSTipos.IconId.PRI_Critico, ex.Message);
            }
        }

        private void grelhaCabimentacao_ActualizaDados(object Sender, EventArgs e)
        {
            LoadGrid();
        }

        private void grelhaCabimentacao_DataFill(object Sender, PriGrelha.DataFillEventArgs e)
        {
            //// Set modulo description
            //SetModuloDesc(e.Row);

            //// Set days of delay
            //int daysOfDelay = PSO.Utils.FInt(priGrelha1.GetGRID_GetValorCelula(e.Row, colDiasAtraso));
            //daysOfDelay = daysOfDelay < 0 ? Math.Abs(daysOfDelay) : 0;
            //priGrelha1.SetGRID_SetValorCelula(e.Row, colDiasAtraso, daysOfDelay);
        }

        private void grelhaCabimentacao_FormatacaoAlterada(object Sender, PriGrelha.FormatacaoAlteradaEventArgs e)
        {
            grelhaCabimentacao.LimpaGrelha();
        }

        private void grelhaCabimentacao_MenuContextoSeleccionado(object Sender, PriGrelha.MenuContextoSeleccionadoEventArgs e)
        {
            switch (e.Comando.ToUpper())
            {
                case "MNUSTDDRILLDOWN":
                    ExecuteDrillDown();
                    break;
                case MNU_PedirNumCab:
                    break;
                case MNU_PedirTodosNumCab:
                    break;
                case MNU_ConsultarCab:
                    break;
                case MNU_ConsultarTodosCab:
                    break;
                default:
                    break;
            }
        }

        #endregion Events

        #region Private

        /// <summary>
        /// Initialize SDK controls.
        /// </summary>
        private void InitializeSDKControls()
        {
            //Initializes controls
            if (!controlsInitialized)
            {
                // Initialize the controls with the SDK context
                tiposEntidade1.Inicializa(PriSDKContext.SdkContext);
                f41.Inicializa(PriSDKContext.SdkContext);
                filtroEntidades1.Inicializa(PriSDKContext.SdkContext);
                grelhaCabimentacao.Inicializa(PriSDKContext.SdkContext);

                controlsInitialized = true;
            }
        }

        private void InitializeGrid()
        {
            CriarMenuGrelhaOpcoes();
            grelhaCabimentacao.BandaMenuContexto = BANDA_Cabimentacao;

            //priGrelha1.BandaMenuContexto = "PopupGrelhasStd";
            grelhaCabimentacao.IniciaDadosConfig();

            // Number of groupings allowed (maximum of 4)
            grelhaCabimentacao.AddColAgrupa();
            grelhaCabimentacao.AddColAgrupa();
            grelhaCabimentacao.AddColAgrupa();
            grelhaCabimentacao.AddColAgrupa();

            // Normal columns
            
            grelhaCabimentacao.AddColKey(colDocumento, FpCellType.CellTypeEdit, "Documento", 10, true, strCamposBaseDados: colDocumento, blnDrillDown: true);
            grelhaCabimentacao.AddColKey(colNumDocExterno, FpCellType.CellTypeEdit, "Número", 10, true, strCamposBaseDados: colNumDocExterno, blnDrillDown: true);
            grelhaCabimentacao.AddColKey(colDataDoc, FpCellType.CellTypeDate, "Data Doc.", 8, true, strCamposBaseDados: colDataDoc);

            grelhaCabimentacao.AddColKey(colNumCab, FpCellType.CellTypeInteger, "Núm.Cabimento", 15, true, strCamposBaseDados: colNumCab);
            grelhaCabimentacao.AddColKey(colEstadoCab, FpCellType.CellTypeEdit, "Estado", 15, true, strCamposBaseDados: colEstadoCab);

            grelhaCabimentacao.AddColKey(colEntidade, FpCellType.CellTypeEdit, "Entidade", 10, true, strCamposBaseDados: colEntidade, blnDrillDown: true);
            grelhaCabimentacao.AddColKey(colNomeEntidade, FpCellType.CellTypeEdit, "Nome", 30, true, strCamposBaseDados: colNomeEntidade, blnDrillDown: true);
            grelhaCabimentacao.AddColKey(colNumContribuinte, FpCellType.CellTypeEdit, "Núm.Contrib.", 24, true, strCamposBaseDados: colNumContribuinte, blnDrillDown: true);

            grelhaCabimentacao.AddColKey(colMoeda, FpCellType.CellTypeEdit, "Moeda", 8, true, strCamposBaseDados: colMoeda, blnDrillDown: true);
            grelhaCabimentacao.AddColKey(colCondPag, FpCellType.CellTypeEdit, "Cond.Pag.", 8, true, strCamposBaseDados: colCondPag, blnDrillDown: true);

            grelhaCabimentacao.AddColKey(colFonteFinancCBL, FpCellType.CellTypeEdit, "Fonte Finan.", 10, true, strCamposBaseDados: colFonteFinancCBL, blnDrillDown: true);
            grelhaCabimentacao.AddColKey(colOrganicaCBL, FpCellType.CellTypeEdit, "Orgânica", 10, true, strCamposBaseDados: colOrganicaCBL, blnDrillDown: true);
            grelhaCabimentacao.AddColKey(colClasseEcon, FpCellType.CellTypeEdit, "Classe Econ.", 10, true, strCamposBaseDados: colClasseEcon, blnDrillDown: true);

            grelhaCabimentacao.AddColKey(colObservacoes, FpCellType.CellTypeEdit, "Obs", 30, true, strCamposBaseDados: colObservacoes);

            // Hidden column
            grelhaCabimentacao.AddColKey(colDocId, FpCellType.CellTypeEdit, "DocId", 10, true, false, blnDisponivelParaConfiguracao: false, strCamposBaseDados: colDocId);
            grelhaCabimentacao.AddColKey(colTipoDoc, FpCellType.CellTypeEdit, "Doc.", 10, true, false, strCamposBaseDados: colTipoDoc, blnDrillDown: true);
            grelhaCabimentacao.AddColKey(colSerie, FpCellType.CellTypeEdit, "Série", 10, true, false, strCamposBaseDados: colSerie);
            grelhaCabimentacao.AddColKey(colNumDoc, FpCellType.CellTypeInteger, "Núm.Doc.", 10, true, false, strCamposBaseDados: colNumDoc, blnDrillDown: true);
            grelhaCabimentacao.AddColKey(colTipoEntidade, FpCellType.CellTypeEdit, "TipoEntidade", 10, true, false, strCamposBaseDados: colTipoEntidade);            

            //Default grouping
            grelhaCabimentacao.AdicionaAgrupamento(grelhaCabimentacao.Cols.GetEdita(colEntidade).Number);

            // Other properties
            grelhaCabimentacao.TituloGrelha = "Cabimentacao";
            grelhaCabimentacao.PermiteAgrupamentosUser = true;
            grelhaCabimentacao.PermiteOrdenacao = true;
            grelhaCabimentacao.PermiteActualizar = true;
            grelhaCabimentacao.PermiteFiltros = true;
            grelhaCabimentacao.PermiteDetalhes = true;
            grelhaCabimentacao.PermiteStatusBar = true;
            grelhaCabimentacao.PermiteDataFill = true;
            grelhaCabimentacao.PermiteVistas = true;

            grelhaCabimentacao.LimpaGrelha();
        }

        private void CriarMenuGrelhaOpcoes()
        {
            BSO.DSO.Plat.Menus.InicializaBanda(BANDA_Cabimentacao);
            BSO.DSO.Plat.Menus.AddMenuContexto(BANDA_Cabimentacao, MNU_Cabimentacao, "Cabimentação");

            BSO.DSO.Plat.Menus.InicializaBanda(BANDA_Sigof);

            BSO.DSO.Plat.Menus.AddMenuContexto(BANDA_Sigof, MNU_PedirNumCab, "Pedir Cabimento");
            BSO.DSO.Plat.Menus.AddMenuContexto(BANDA_Sigof, MNU_PedirTodosNumCab, "Pedir todos os Cabimentos");

            BSO.DSO.Plat.Menus.AddMenuContexto(BANDA_Sigof, MNU_ConsultarCab, "Consultar Cabimento");
            BSO.DSO.Plat.Menus.AddMenuContexto(BANDA_Sigof, MNU_ConsultarTodosCab, "Consultar todos os Cabimentos");

            BSO.DSO.Plat.Menus.LigaBandaMenu(BANDA_Sigof, MNU_Cabimentacao, BANDA_Cabimentacao);
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadGrid()
        {
            StringBuilder query = new StringBuilder();

            query.AppendLine(string.Format("SELECT {0}", grelhaCabimentacao.DaCamposBDSelect()));
            query.AppendLine(string.Format("FROM {0} cab", Globals.TDU_Cabimentacao));
            query.AppendLine(string.Format("INNER JOIN V_Entidades ent ON {0} = ent.TipoEntidade AND {1} = ent.Entidade", colTipoEntidade, colEntidade));

            //if (!string.IsNullOrWhiteSpace(f41.Text))
            //{
            //    query.AppendLine(string.Format("WHERE {0} = {1} AND {2} = '{3}'", colTipoEntidade, tiposEntidade1.TipoEntidade, colEntidade, f41.Text));
            //}

            query.AppendLine(string.Format("ORDER BY {0}", colDataDoc));

            grelhaCabimentacao.DataBind(PriSDKContext.SdkContext.BSO.Consulta(query.ToString()));
        }

        //private void SelecionaCategoriaF4()
        //{
        //    f41.Enabled = true;
        //    f41.PermiteDrillDown = true;

        //    switch (tiposEntidade1.TipoEntidade)
        //    {
        //        case "C":
        //            f41.Categoria = clsSDKTypes.EnumCategoria.Clientes;
        //            categoriaEntidade = "mntTabClientes";
        //            break;
        //        case "F":
        //            f41.Categoria = clsSDKTypes.EnumCategoria.Fornecedores;
        //            categoriaEntidade = "mntTabFornecedores";
        //            break;
        //        default:
        //            f41.Categoria = clsSDKTypes.EnumCategoria.NaoDefinida;
        //            f41.Enabled = false;
        //            f41.Limpa();
        //            f41.PermiteDrillDown = false;
        //            break;
        //    }

        //    f41.ResetText();
        //}

        private void ExecuteDrillDown()
        {
            int row = grelhaCabimentacao.Grelha.ActiveRowIndex;
            int col = grelhaCabimentacao.Grelha.ActiveColumnIndex;

            string colKey = grelhaCabimentacao.Cols.GetEditaCol(col).ColKey;

            if ((colKey == colNomeEntidade) || colKey == colEntidade)
            {
                string entidade = PSO.Utils.FStr(grelhaCabimentacao.GetGRID_GetValorCelula(row, colEntidade));

                DrillDownManager.DrillDownEntidade(PSO, categoriaEntidade, entidade);

                return;
            }

            if ((colKey == colNumDoc) || (colKey == colDocumento) || (colKey == colNumDocExterno))
            {
                string docId = PSO.Utils.FStr(grelhaCabimentacao.GetGRID_GetValorCelula(row, colDocId));

                DrillDownManager.DrillDownDocumentoId(PSO, "C", docId);

                return;
            }
        }


        #endregion Private

        private void tiposEntidade1_TextChange(object Sender, TiposEntidade.TextChangeEventArgs e)
        {

        }
    }
}


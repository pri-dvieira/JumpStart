namespace PDEX.Extensibility
{
    partial class frmCabimentacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StdBase100.StdBETipoEntidade stdBETipoEntidade1 = new StdBase100.StdBETipoEntidade();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grelhaCabimentacao = new PRISDK100.PriGrelha();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f41 = new PRISDK100.F4();
            this.tiposEntidade1 = new PRISDK100.TiposEntidade();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDataFinal = new System.Windows.Forms.DateTimePicker();
            this.filtroEntidades1 = new PRISDK100.FiltroEntidades();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grelhaCabimentacao)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.filtroEntidades1);
            this.panel1.Controls.Add(this.dateTimePickerDataFinal);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePickerDataInicial);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.f41);
            this.panel1.Controls.Add(this.tiposEntidade1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 131);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grelhaCabimentacao);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1087, 404);
            this.panel2.TabIndex = 6;
            // 
            // grelhaCabimentacao
            // 
            this.grelhaCabimentacao.BackColor = System.Drawing.Color.White;
            this.grelhaCabimentacao.BandaMenuContexto = "";
            this.grelhaCabimentacao.BotaoConfigurarActiveBar = true;
            this.grelhaCabimentacao.BotaoProcurarActiveBar = false;
            this.grelhaCabimentacao.CaminhoTemplateImpressao = "";
            this.grelhaCabimentacao.Cols = null;
            this.grelhaCabimentacao.ColsFrozen = -1;
            this.grelhaCabimentacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grelhaCabimentacao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grelhaCabimentacao.Location = new System.Drawing.Point(0, 0);
            this.grelhaCabimentacao.Name = "grelhaCabimentacao";
            this.grelhaCabimentacao.NumeroMaxRegistosSemPag = 150000;
            this.grelhaCabimentacao.NumeroRegistos = 0;
            this.grelhaCabimentacao.NumLinhasCabecalho = 1;
            this.grelhaCabimentacao.OrientacaoMapa = PRISDK100.clsSDKTypes.OrientacaoImpressao.oiDefault;
            this.grelhaCabimentacao.ParentFormModal = false;
            this.grelhaCabimentacao.PermiteActiveBar = false;
            this.grelhaCabimentacao.PermiteActualizar = true;
            this.grelhaCabimentacao.PermiteAgrupamentosUser = true;
            this.grelhaCabimentacao.PermiteConfigurarDetalhes = false;
            this.grelhaCabimentacao.PermiteContextoVazia = false;
            this.grelhaCabimentacao.PermiteDataFill = false;
            this.grelhaCabimentacao.PermiteDetalhes = true;
            this.grelhaCabimentacao.PermiteEdicao = false;
            this.grelhaCabimentacao.PermiteFiltros = true;
            this.grelhaCabimentacao.PermiteGrafico = true;
            this.grelhaCabimentacao.PermiteGrandeTotal = false;
            this.grelhaCabimentacao.PermiteOrdenacao = true;
            this.grelhaCabimentacao.PermitePaginacao = false;
            this.grelhaCabimentacao.PermiteScrollBars = true;
            this.grelhaCabimentacao.PermiteStatusBar = true;
            this.grelhaCabimentacao.PermiteVistas = true;
            this.grelhaCabimentacao.PosicionaColunaSeguinte = true;
            this.grelhaCabimentacao.Size = new System.Drawing.Size(1087, 404);
            this.grelhaCabimentacao.TabIndex = 5;
            this.grelhaCabimentacao.TituloGrelha = "";
            this.grelhaCabimentacao.TituloMapa = "";
            this.grelhaCabimentacao.TypeNameLinha = "";
            this.grelhaCabimentacao.TypeNameLinhas = "";
            this.grelhaCabimentacao.FormatacaoAlterada += new PRISDK100.PriGrelha.FormatacaoAlteradaHandler(this.grelhaCabimentacao_FormatacaoAlterada);
            this.grelhaCabimentacao.MenuContextoSeleccionado += new PRISDK100.PriGrelha.MenuContextoSeleccionadoHandler(this.grelhaCabimentacao_MenuContextoSeleccionado);
            this.grelhaCabimentacao.ActualizaDados += new PRISDK100.PriGrelha.ActualizaDadosHandler(this.grelhaCabimentacao_ActualizaDados);
            this.grelhaCabimentacao.DataFill += new PRISDK100.PriGrelha.DataFillHandler(this.grelhaCabimentacao_DataFill);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1087, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.ActualizarToolStripMenuItem_Click);
            // 
            // f41
            // 
            this.f41.Audit = "mnuTabClientes";
            this.f41.AutoComplete = false;
            this.f41.BackColorLocked = System.Drawing.SystemColors.ButtonFace;
            this.f41.CampoChave = "Cliente";
            this.f41.CampoChaveFisica = "";
            this.f41.CampoDescricao = "Nome";
            this.f41.Caption = "Cliente:";
            this.f41.CarregarValoresEdicao = false;
            this.f41.Categoria = PRISDK100.clsSDKTypes.EnumCategoria.Clientes;
            this.f41.ChaveFisica = "";
            this.f41.ChaveNumerica = false;
            this.f41.F4Modal = true;
            this.f41.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.f41.IDCategoria = "Clientes";
            this.f41.Location = new System.Drawing.Point(240, 1);
            this.f41.MaxLengthDescricao = 0;
            this.f41.MaxLengthF4 = 50;
            this.f41.MinimumSize = new System.Drawing.Size(37, 21);
            this.f41.Modulo = "BAS";
            this.f41.MostraDescricao = true;
            this.f41.MostraLink = false;
            this.f41.Name = "f41";
            this.f41.PainesInformacaoRelacionada = false;
            this.f41.PainesInformacaoRelacionadaMultiplasChaves = false;
            this.f41.PermiteDrillDown = true;
            this.f41.PermiteEnabledLink = true;
            this.f41.PodeEditarDescricao = false;
            this.f41.ResourceID = 669;
            this.f41.ResourcePersonalizada = false;
            this.f41.Restricao = "";
            this.f41.SelectionFormula = "";
            this.f41.Size = new System.Drawing.Size(364, 22);
            this.f41.TabIndex = 10;
            this.f41.TextoDescricao = "";
            this.f41.WidthEspacamento = 60;
            this.f41.WidthF4 = 1590;
            this.f41.WidthLink = 1600;
            // 
            // tiposEntidade1
            // 
            this.tiposEntidade1.Activo = true;
            this.tiposEntidade1.Caption = "Tipo de Entidade:";
            stdBETipoEntidade1.AcedeOperacao = false;
            stdBETipoEntidade1.Audit = "";
            stdBETipoEntidade1.Campo_Chave = "";
            stdBETipoEntidade1.Categoria = "";
            stdBETipoEntidade1.Descricao = "";
            stdBETipoEntidade1.DescricaoPlural = "";
            stdBETipoEntidade1.Modulo = "";
            stdBETipoEntidade1.Natureza = "";
            stdBETipoEntidade1.Tabela = "";
            stdBETipoEntidade1.TipoEntidade = "";
            stdBETipoEntidade1.Visivel = false;
            this.tiposEntidade1.Contexto = stdBETipoEntidade1;
            this.tiposEntidade1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tiposEntidade1.LarguraLink = 0;
            this.tiposEntidade1.Location = new System.Drawing.Point(60, 2);
            this.tiposEntidade1.Margin = new System.Windows.Forms.Padding(2);
            this.tiposEntidade1.Modulo = "";
            this.tiposEntidade1.MostraLink = false;
            this.tiposEntidade1.Name = "tiposEntidade1";
            this.tiposEntidade1.PermiteSemTipoEntidade = false;
            this.tiposEntidade1.ResourceID = 0;
            this.tiposEntidade1.Size = new System.Drawing.Size(175, 21);
            this.tiposEntidade1.TabIndex = 9;
            this.tiposEntidade1.Texto = "";
            this.tiposEntidade1.TipoContexto = PRISDK100.clsSDKTypes.enumContexto.Editor;
            this.tiposEntidade1.TipoEntidade = "";
            this.tiposEntidade1.TiposEntidade_TiposEntidade = null;
            this.tiposEntidade1.Titulo = "Tipo de Entidade:";
            this.tiposEntidade1.WidthLink = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Entidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Período:";
            // 
            // dateTimePickerDataInicial
            // 
            this.dateTimePickerDataInicial.Location = new System.Drawing.Point(60, 29);
            this.dateTimePickerDataInicial.Name = "dateTimePickerDataInicial";
            this.dateTimePickerDataInicial.Size = new System.Drawing.Size(175, 20);
            this.dateTimePickerDataInicial.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "até";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(724, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // dateTimePickerDataFinal
            // 
            this.dateTimePickerDataFinal.Location = new System.Drawing.Point(269, 29);
            this.dateTimePickerDataFinal.Name = "dateTimePickerDataFinal";
            this.dateTimePickerDataFinal.Size = new System.Drawing.Size(175, 20);
            this.dateTimePickerDataFinal.TabIndex = 16;
            // 
            // filtroEntidades1
            // 
            this.filtroEntidades1.AplContextoAudit = "";
            this.filtroEntidades1.CCorrenteEstendida = true;
            this.filtroEntidades1.ContextoAudit = "";
            this.filtroEntidades1.EntidadesAssociadas = false;
            this.filtroEntidades1.F4Modal = false;
            this.filtroEntidades1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.filtroEntidades1.Location = new System.Drawing.Point(491, 44);
            this.filtroEntidades1.Modulo = "";
            this.filtroEntidades1.MostraEntidadesAsocciadas = true;
            this.filtroEntidades1.MultiSelecao = true;
            this.filtroEntidades1.Name = "filtroEntidades1";
            this.filtroEntidades1.PermiteSemTipoEntidade = true;
            this.filtroEntidades1.Size = new System.Drawing.Size(505, 58);
            this.filtroEntidades1.TabIndex = 17;
            this.filtroEntidades1.TipoContexto = PRISDK100.clsSDKTypes.enumContexto.Manutencao;
            this.filtroEntidades1.TipoEntidadeCombo = "";
            this.filtroEntidades1.TiposEntidade = null;
            this.filtroEntidades1.ValorRestricao = "";
            // 
            // frmCabimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(759, 411);
            this.Name = "frmCabimentacao";
            this.Size = new System.Drawing.Size(1087, 559);
            this.Text = "Pendentes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDemoGrid_FormClosed);
            this.Load += new System.EventHandler(this.frmDemoGrid_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grelhaCabimentacao)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private PRISDK100.PriGrelha grelhaCabimentacao;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private PRISDK100.F4 f41;
        private PRISDK100.TiposEntidade tiposEntidade1;
        private PRISDK100.FiltroEntidades filtroEntidades1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFinal;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
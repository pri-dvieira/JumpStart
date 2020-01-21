namespace TestePDEX
{
    partial class Form111
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form111));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Actualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.btCabimentar = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.btConsultar = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.btLiquidar = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Actualizar,
            this.toolStripTextBox1,
            this.btCabimentar,
            this.toolStripTextBox2,
            this.btConsultar,
            this.toolStripTextBox3,
            this.btLiquidar,
            this.toolStripTextBox4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(873, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Actualizar
            // 
            this.Actualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Actualizar.Image = ((System.Drawing.Image)(resources.GetObject("Actualizar.Image")));
            this.Actualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(24, 24);
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.Click += new System.EventHandler(this.Actualizar_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox1.Text = "Atualizar";
            // 
            // btCabimentar
            // 
            this.btCabimentar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCabimentar.Image = ((System.Drawing.Image)(resources.GetObject("btCabimentar.Image")));
            this.btCabimentar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCabimentar.Name = "btCabimentar";
            this.btCabimentar.Size = new System.Drawing.Size(24, 24);
            this.btCabimentar.Text = "Cabimentar";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox2.Text = "Cabimentar";
            // 
            // btConsultar
            // 
            this.btConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btConsultar.Image")));
            this.btConsultar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btConsultar.Name = "btConsultar";
            this.btConsultar.Size = new System.Drawing.Size(24, 24);
            this.btConsultar.Text = "Consultar Cabimento";
            this.btConsultar.Click += new System.EventHandler(this.btConsultar_Click);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox3.Text = "Consultar";
            this.toolStripTextBox3.Click += new System.EventHandler(this.toolStripTextBox3_Click);
            // 
            // btLiquidar
            // 
            this.btLiquidar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btLiquidar.Image = ((System.Drawing.Image)(resources.GetObject("btLiquidar.Image")));
            this.btLiquidar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btLiquidar.Name = "btLiquidar";
            this.btLiquidar.Size = new System.Drawing.Size(24, 24);
            this.btLiquidar.Text = "Liquidar";
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox4.Text = "Liquidar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dataGridView1.Location = new System.Drawing.Point(12, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(858, 408);
            this.dataGridView1.TabIndex = 2;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // Form111
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 516);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form111";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Actualizar;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton btCabimentar;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripButton btConsultar;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton btLiquidar;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
    }
}


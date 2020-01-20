namespace TestePDEX
{
    partial class Form1
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
            this.buttonCabimentacao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCabimentacao
            // 
            this.buttonCabimentacao.Location = new System.Drawing.Point(12, 12);
            this.buttonCabimentacao.Name = "buttonCabimentacao";
            this.buttonCabimentacao.Size = new System.Drawing.Size(297, 23);
            this.buttonCabimentacao.TabIndex = 0;
            this.buttonCabimentacao.Text = "Cabimentação";
            this.buttonCabimentacao.UseVisualStyleBackColor = true;
            this.buttonCabimentacao.Click += new System.EventHandler(this.ButtonCabimentacao_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCabimentacao);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCabimentacao;
    }
}


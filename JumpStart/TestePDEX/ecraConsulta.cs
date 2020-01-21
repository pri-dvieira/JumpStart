using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestePDEX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonCabimentacao_Click(object sender, EventArgs e)
        {
            PDEXERP.Main pdexMain = new PDEXERP.Main(PriEngine.BSO, PriEngine.Plataforma);
            pdexMain.DocCabimentacao();
        }
    }
}

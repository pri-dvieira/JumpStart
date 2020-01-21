using Primavera.Extensibility.CustomForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StdPlatBS100;
using PDEX.Extensibility;
using StdBE100;
using System.Data.SqlClient;

namespace TestePDEX
{
    public partial class Form111 : Form
    {

       

        public Form111()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
              


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            //string qry = "select * from TDU_PDEXCabimentacao";
            //DataTable dt = PDEX.Extensibility.Platform.UiPlataforma.(qry);
            //DGV_PEDEX.DataSource = dt;
            SqlConnection con = new SqlConnection("Data Source=acadv10\\primavera;Initial Catalog=PRIDEMO;Integrated Security=True");
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("select *from TDU_Cabimento", con);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = sqlCommand;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btguardar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ecraConsulta().Show();

        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {

        }
    }
}

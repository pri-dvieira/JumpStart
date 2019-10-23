using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErpBS100;
using Primavera.Extensibility.Engine;
using StdPlatBS100;
using CmpBE100;

namespace Primavera.Integracao
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        public StdPlatBS PSO { get; private set; }
        public ErpBS BSO { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PSO = new StdPlatBS100.StdPlatBS();

                StdBE100.StdBETransaccao trans = new StdBE100.StdBETransaccao();

                StdPlatBS100.StdBSConfApl ConfApl = new StdPlatBS100.StdBSConfApl();
                ConfApl.Utilizador = "primavera";
                ConfApl.PwdUtilizador = "qualquer";
                ConfApl.Instancia = "Default";
                ConfApl.AbvtApl = "ERP";
                ConfApl.LicVersaoMinima = "10.00";

                StdBE100.StdBETipos.EnumTipoPlataforma tipoPlataforma =
                    StdBE100.StdBETipos.EnumTipoPlataforma.tpEmpresarial;

                PSO.AbrePlataformaEmpresa("DEMO", trans, ConfApl, tipoPlataforma);

                label1EstadoPlataforma.Text = "Plataforma Aberto...";
            }
            catch (Exception )
            {
                label1EstadoPlataforma.Text = "Erro ao abrir Plataforma!";

            }
        }

        private void button2AbririMotor_Click(object sender, EventArgs e)
        {
            try
            {
                BSO = new ErpBS100.ErpBS();

                StdBE100.StdBETipos.EnumTipoPlataforma tipoPlataforma =
                StdBE100.StdBETipos.EnumTipoPlataforma.tpEmpresarial;
                BSO.AbreEmpresaTrabalho(tipoPlataforma, "DEMO", "primavera", "qualquer");

                //use this service to trigger the API events.
                ExtensibilityService service = new ExtensibilityService();

                service.Initialize(BSO);

                // Check if service is operational
                if (service.IsOperational)
                {
                    // Inshore that all extensions are loaded.
                    service.LoadExtensions();
                }

                label2EstadoMotor.Text = "Motor aberto...";

            }
            catch (Exception)
            {
                label2EstadoMotor.Text = " Erro ao abrir o motor!";

            }
        }

        private void button3CriarFurnecedor_Click(object sender, EventArgs e)
        {
            try
            {
                //Instacia o BE Fornecedor 
                BasBE100.BasBEFornecedor beFornecedor = new BasBE100.BasBEFornecedor();
                beFornecedor.Fornecedor = "AILTON";
                beFornecedor.Nome = "NomeAILTON";
                beFornecedor.NumContribuinte = "23456789";
                beFornecedor.CondPag = "1";
                beFornecedor.Moeda = "CVE";
               



                //Gravar o BE Fornecedor
                
                BSO.Base.Fornecedores.Actualiza(beFornecedor);

                label3EstadoFornecedor.Text = "Criado com Sucesso";
            }
            catch (Exception ex)
            {
                label3EstadoFornecedor.Text = ex.Message;

            }
        }

        private void button4CriarFatura_Click(object sender, EventArgs e)
        {
            
            try
            {
                CmpBEDocumentoCompra fatura = new CmpBEDocumentoCompra();
                fatura.Tipodoc = "VFA";
                fatura.Serie = "A";
                fatura.Entidade = "DANIEL";
                fatura.TipoEntidade = "F";
                fatura.DataDoc = DateTime.Now;
                fatura.NumDocExterno = "2";
                
               
                fatura.Observacoes = "Documentos de pedido de compra generado automaticamente";

                fatura = BSO.Compras.Documentos.PreencheDadosRelacionados(fatura);
                
                
                CmpBEDocumentoCompra Linha = new CmpBEDocumentoCompra();

                             
                fatura.CAE.Equals(Linha);

                BSO.Compras.Documentos.AdicionaLinha(fatura, "A0001");

                 BSO.Compras.Documentos.Actualiza(fatura);

                label4CriarFatura.Text = fatura.Documento;
            }
            catch (Exception ex)
            {
                label4CriarFatura.Text = ex.Message;
            }
            
            

        }
    }
}

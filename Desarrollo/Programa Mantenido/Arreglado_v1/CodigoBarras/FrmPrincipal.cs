using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LectorExcel;
using System.IO;
using Entidad;
namespace CodigoBarras
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        static string extension;
        static int numColumnas;
        private void BtnBuscaExcelPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                string input = string.Empty;
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Archivos Excel|*.xlsx;*.xls|All Files (*.*)|*.*";
                open.InitialDirectory = "C:";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    input = open.FileName;
                    extension = Path.GetExtension(open.FileName);
                    txtruta.Text = input;
                    txtNombreHoja.Enabled = true;
                    btnLlenaExcel.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Error al encontrar la hoja de excel, revise los datos.", "Buscar Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void btnLlenaExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsexcel = new DataSet();
                GestionarExcel gestionarExcel = new GestionarExcel();
                dsexcel=gestionarExcel.obtenerData(extension, txtNombreHoja.Text, txtruta.Text);
                if (dsexcel != null)
                {
                    dgvContenedor.DataSource = dsexcel.Tables[0];
                    numColumnas = (dgvContenedor.Columns.Count);
                }
                else
                {
                    MessageBox.Show("no hay datos, revise la extension");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Error de Formato");
            }
        }
               

        private void btnGeneraPdf_Click(object sender, EventArgs e)
        {
            try
            {

             
                List<EDatos> listaDatos = new List<EDatos>();
                
                int columnas = 6;

                int i = 0;
               
                foreach (DataGridViewRow row in dgvContenedor.Rows)
                {
                    EDatos objDato = new EDatos();
                    objDato.codigo = dgvContenedor.Rows[i].Cells[0].Value.ToString();                    
                    objDato.cliente = dgvContenedor.Rows[i].Cells[1].Value.ToString();
                    objDato.direccion = dgvContenedor.Rows[i].Cells[2].Value.ToString();
                    objDato.ciudad = dgvContenedor.Rows[i].Cells[3].Value.ToString();                    
                   
                   
                        listaDatos.Add(objDato);
                    
                    
                    i++;
                }
                JCItextSharp.Instancia.generaBarcodePDF("D:\\", listaDatos, columnas);
                MessageBox.Show("PDF Exportado");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al exportat excel");
            }
            
        }
    }
}

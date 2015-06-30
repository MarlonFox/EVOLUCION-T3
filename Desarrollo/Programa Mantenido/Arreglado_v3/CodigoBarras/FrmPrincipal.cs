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

        public Int32 PosicionColumna(string nombreColumna)
        {
            for (int k1 = 0; k1 < numColumnas; k1++)
            {
                if (dgvContenedor.Columns[k1].Name.ToLower().Equals(nombreColumna))
                {
                    return k1;
                }
            }
            return -1;
        }


        private void btnGeneraPdf_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog sfd =new SaveFileDialog();
                
                string rutaSave = string.Empty;
                sfd.FileName = "Documento"; // Default file name
                sfd.DefaultExt = ".pdf"; // Default file extension
                sfd.Filter = "Archivos PDF (.pdf)|*.pdf"; // Filter files by extension

                if (sfd.ShowDialog()==DialogResult.OK)
                {
                     rutaSave = sfd.FileName.ToString();
                }

                List<EDatos> listaDatos = new List<EDatos>();
                
                int columnas = 6;

                int i = 0;
                int posicionCodigo=PosicionColumna("codigo");
                int posicionNombre=PosicionColumna("nombre");
                int posicionDireccion=PosicionColumna("direccion");
                int posicionCiudades=PosicionColumna("ciudades");
                foreach (DataGridViewRow row in dgvContenedor.Rows)
                {
                    EDatos objDato = new EDatos();
                    objDato.codigo = dgvContenedor.Rows[i].Cells[posicionCodigo].Value.ToString();                    
                    objDato.cliente = dgvContenedor.Rows[i].Cells[posicionNombre].Value.ToString();
                    objDato.direccion = dgvContenedor.Rows[i].Cells[posicionDireccion].Value.ToString();
                    objDato.ciudad = dgvContenedor.Rows[i].Cells[posicionCiudades].Value.ToString();                    
                   
                   
                        listaDatos.Add(objDato);
                    
                    
                    i++;
                }
                JCItextSharp.Instancia.generaBarcodePDF(rutaSave, listaDatos, columnas);
                MessageBox.Show("PDF Exportado");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al exportat excel");
            }
            
        }
    }
}

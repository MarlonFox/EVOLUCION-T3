using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
namespace CodigoBarras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnBuscaExcelPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                string input = string.Empty;
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Archivos Excel|*.xls|All Files (*.*)|*.*";
                open.InitialDirectory = "C:";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    input = open.FileName;
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
        public class datos
        {
            public String codigo { get; set; }
            public String cliente { get; set; }
            public String direccion { get; set; }
            public String ciudad { get; set; }

        }
        private void btnLlenaExcel_Click(object sender, EventArgs e)
        {
            try
            {                
                //Inicialización de las variables
                OleDbConnection conexion = new OleDbConnection();
                OleDbCommand comando = new OleDbCommand();
                OleDbDataAdapter adaptador = new OleDbDataAdapter();
                DataSet dsexcel = new DataSet();
                String ExcelPath = "";
                String data = "";
                dsexcel.Clear();
                data = txtNombreHoja.Text;
                ExcelPath = txtruta.Text.ToLower();
                int caracteresRuta = (txtruta.Text.Trim().ToLower()).Length;
                String extension = (txtruta.Text.Trim().ToLower()).Substring(caracteresRuta - 4);

                conexion.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelPath + "; Extended Properties= \"Excel 8.0;HDR=YES;IMEX=1\"";
               

                conexion.Open();
                comando.CommandText = "SELECT * FROM [" + data + "$] where valido=1";
                comando.Connection = conexion;
                adaptador.SelectCommand = comando;
                adaptador.Fill(dsexcel);
                conexion.Close();
                

                if (dsexcel != null)
                {
                    dgvContenedor.DataSource = dsexcel.Tables[0];
                }
                else
                {
                    MessageBox.Show("no hay datos, revise la extension");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void btnGeneraPdf_Click(object sender, EventArgs e)
        {
            List<String> lcodigos = new List<String>();
            List<String> lclientes = new List<String>();
            List<String> ldirecciones = new List<String>();
            List<String> lciudades = new List<String>();

            int i = 0;
            foreach (DataGridViewRow row in dgvContenedor.Rows)
            {
                datos objDatos = new datos();
                lcodigos.Add(dgvContenedor.Rows[i].Cells[0].Value.ToString());
                lclientes.Add(dgvContenedor.Rows[i].Cells[1].Value.ToString());
                ldirecciones.Add(dgvContenedor.Rows[i].Cells[2].Value.ToString());
                lciudades.Add(dgvContenedor.Rows[i].Cells[3].Value.ToString());
                i++;
            }


            generaBarcodePDF("D:\\", lcodigos, lclientes, ldirecciones, lciudades, 6);
            MessageBox.Show("yes");
        }

        public Image GetBarcode39(PdfContentByte pdfContentByte, string code, bool extended)
        {
            Barcode39 barcode39 = new Barcode39 { Code = code, StartStopText = false, Extended = extended };
            return barcode39.CreateImageWithBarcode(pdfContentByte, null, null);
        }
        public Image GetBarcode128(PdfContentByte pdfContentByte, string code, bool extended, int codeType)
        {
            Barcode128 code128 = new Barcode128 { Code = code, Extended = extended, CodeType = codeType };
            return code128.CreateImageWithBarcode(pdfContentByte, null, null);
        }

        public void generaBarcodePDF(String ruta, List<String> Lista1, List<String> Lista2, List<String> Lista3, List<String> Lista4, int col)
        {

            //creo el documento y le asigno margenes
            ruta = ruta + Guid.NewGuid() + ".pdf";
            Document document = new Document(PageSize.A4, 20, 20, 20, 20);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(ruta, FileMode.Create));
            document.Open();
            PdfContentByte pdfContentByte = pdfWriter.DirectContent;


            PdfPTable table = new PdfPTable(col)
            {
                WidthPercentage = 100
            };


            for (int i = 0; i < Lista1.Count; i++)
            {
                PdfPTable tabla_contenido = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };

                // Barcode 128 EAN
                Image imageEan = GetBarcode128(pdfContentByte, Lista1[i], false, Barcode.EAN13);
                tabla_contenido.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla_contenido.AddCell(new Phrase(new Chunk(imageEan, 0, 0)));
                PdfPCell cellEmpresa = new PdfPCell(new Phrase(Lista2[i], new Font(iTextSharp.text.Font.HELVETICA, 6f, iTextSharp.text.Font.NORMAL)));
                PdfPCell cellDireccion = new PdfPCell(new Phrase(Lista3[i], new Font(iTextSharp.text.Font.HELVETICA, 5f, iTextSharp.text.Font.NORMAL)));
                PdfPCell cellLugar = new PdfPCell(new Phrase(Lista4[i], new Font(iTextSharp.text.Font.HELVETICA, 6f, iTextSharp.text.Font.NORMAL)));
                cellEmpresa.Border = Rectangle.NO_BORDER;
                cellDireccion.Border = Rectangle.NO_BORDER;
                cellLugar.Border = Rectangle.NO_BORDER;

                tabla_contenido.AddCell(cellEmpresa);
                tabla_contenido.AddCell(cellDireccion);
                tabla_contenido.AddCell(cellLugar);

                tabla_contenido.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(tabla_contenido);
            }

            for (int k = 0; k < col - 1; k++)
            {
                PdfPTable tabla_contenido = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };
                // Barcode 128 EAN
                Image imageEan = GetBarcode128(pdfContentByte, "", false, Barcode.EAN13);
                tabla_contenido.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla_contenido.AddCell(new Phrase(new Chunk(imageEan, 0, 0)));
                PdfPCell cellEmpresa = new PdfPCell(new Phrase("", new Font(iTextSharp.text.Font.HELVETICA, 6f, iTextSharp.text.Font.NORMAL)));
                PdfPCell cellDireccion = new PdfPCell(new Phrase("", new Font(iTextSharp.text.Font.HELVETICA, 5f, iTextSharp.text.Font.NORMAL)));
                PdfPCell cellLugar = new PdfPCell(new Phrase("", new Font(iTextSharp.text.Font.HELVETICA, 6f, iTextSharp.text.Font.NORMAL)));
                cellEmpresa.Border = Rectangle.NO_BORDER;
                cellDireccion.Border = Rectangle.NO_BORDER;
                cellLugar.Border = Rectangle.NO_BORDER;

                tabla_contenido.AddCell(cellEmpresa);
                tabla_contenido.AddCell(cellDireccion);
                tabla_contenido.AddCell(cellLugar);

                tabla_contenido.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(tabla_contenido);
            }

            document.Add(table);
            document.Close();

        }
    }
}

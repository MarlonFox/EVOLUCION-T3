using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CodigoBarras
{
    public class JCItextSharp
    {
        private static JCItextSharp _instancia;
        public static JCItextSharp Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new JCItextSharp();
                return _instancia;
            }
        }
        protected JCItextSharp() { }

        public Image GetBarcode39(PdfContentByte pdfContentByte, string code, bool extended)
        {
            Barcode39 barcode39 = new Barcode39 { Code = code, StartStopText = false, Extended = extended };
            return barcode39.CreateImageWithBarcode(pdfContentByte, null, null);
        }
        /// <summary>
        /// Gets the barcode128.
        /// </summary>
        /// <param name="pdfContentByte">The PDF content byte.</param>
        /// <param name="code">The code.</param>
        /// <param name="extended">if set to <c>true</c> [extended].</param>
        /// <param name="codeType">Type of the code.</param>
        /// <returns>Barcode image.</returns>
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
                PdfPCell cellEmpresa = new PdfPCell(new Phrase(Lista2[i], new Font(Font.HELVETICA, 6f, Font.NORMAL)));
                PdfPCell cellDireccion = new PdfPCell(new Phrase(Lista3[i], new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                PdfPCell cellLugar = new PdfPCell(new Phrase(Lista4[i], new Font(Font.HELVETICA, 6f, Font.NORMAL)));
                cellEmpresa.Border = Rectangle.NO_BORDER;
                cellDireccion.Border = Rectangle.NO_BORDER;
                cellLugar.Border = Rectangle.NO_BORDER;

                tabla_contenido.AddCell(cellEmpresa);
                tabla_contenido.AddCell(cellDireccion);
                tabla_contenido.AddCell(cellLugar);

                //table.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla_contenido.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                //table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //			table.DefaultCell.FixedHeight = 70;

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
                PdfPCell cellEmpresa = new PdfPCell(new Phrase("", new Font(Font.HELVETICA, 6f, Font.NORMAL)));
                PdfPCell cellDireccion = new PdfPCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                PdfPCell cellLugar = new PdfPCell(new Phrase("", new Font(Font.HELVETICA, 6f, Font.NORMAL)));
                cellEmpresa.Border = Rectangle.NO_BORDER;
                cellDireccion.Border = Rectangle.NO_BORDER;
                cellLugar.Border = Rectangle.NO_BORDER;

                tabla_contenido.AddCell(cellEmpresa);
                tabla_contenido.AddCell(cellDireccion);
                tabla_contenido.AddCell(cellLugar);

                //table.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla_contenido.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                //table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //			table.DefaultCell.FixedHeight = 70;

                table.AddCell(tabla_contenido);
            }

            document.Add(table);
            document.Close();

        }

    }
}

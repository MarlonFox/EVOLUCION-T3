using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
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

        public void generaBarcodePDF(String ruta, List<EDatos> listaDatos, int columnas)
        {
            //creo el documento y le asigno margenes
            ruta = ruta + Guid.NewGuid() + ".pdf";
            Document document = new Document(PageSize.A4, 20, 20, 20, 20);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(ruta, FileMode.Create));
            document.Open();
            PdfContentByte pdfContentByte = pdfWriter.DirectContent;

            PdfPTable table = new PdfPTable(columnas)
            {
                WidthPercentage = 100
            };

            for (int i = 0; i < listaDatos.Count; i++)
            {
                PdfPTable tabla_contenido = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };
                // Barcode 128 EAN
                Image imageEan = GeneraBarcode128(pdfContentByte, listaDatos.ElementAt(i).codigo, false, Barcode.EAN13);
                tabla_contenido.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla_contenido.AddCell(new Phrase(new Chunk(imageEan, 0, 0)));
                PdfPCell cellEmpresa = new PdfPCell(new Phrase(listaDatos.ElementAt(i).cliente, new Font(Font.HELVETICA, 6f, Font.NORMAL)));
                PdfPCell cellDireccion = new PdfPCell(new Phrase(listaDatos.ElementAt(i).direccion, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                PdfPCell cellLugar = new PdfPCell(new Phrase(listaDatos.ElementAt(i).ciudad, new Font(Font.HELVETICA, 6f, Font.NORMAL)));
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

            for (int k = 0; k < columnas - 1; k++)
            {
                PdfPTable tabla_contenido = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };
                // Barcode 128 EAN
                Image imageEan = GeneraBarcode128(pdfContentByte, "", false, Barcode.EAN13);
                tabla_contenido.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla_contenido.AddCell(new Phrase(new Chunk(imageEan, 0, 0)));
                table.AddCell(tabla_contenido);
            }

            document.Add(table);
            document.Close();

        }
       
        public Image GeneraBarcode128(PdfContentByte pdfContentByte, string codigo, bool extendido, int tipoCodigo)
        {
            Barcode128 code128 = new Barcode128 { Code = codigo, Extended = extendido, CodeType = tipoCodigo };
            return code128.CreateImageWithBarcode(pdfContentByte, null, null);
        }



    }
}

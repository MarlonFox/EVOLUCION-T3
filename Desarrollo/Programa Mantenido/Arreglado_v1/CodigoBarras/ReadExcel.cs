using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoBarras
{
    public class ReadExcel
    {
        private static ReadExcel _instancia;
        public static ReadExcel Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new ReadExcel();
                return _instancia;
            }
        }
        protected ReadExcel() { }

        public DataSet obtenerDatos(String NombreHoja, String RutaArchivo)
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

                data = NombreHoja;
                ExcelPath = RutaArchivo.ToLower();
                int caracteresRuta = (RutaArchivo.Trim().ToLower()).Length;
                String extension = (RutaArchivo.Trim().ToLower()).Substring(caracteresRuta - 4);

                if (extension == ".xls")
                    conexion.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelPath + "; Extended Properties= \"Excel 8.0;HDR=YES;IMEX=1\"";
                else
                    conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelPath + ";Extended Properties=" + Convert.ToString((char)34) + "Excel 12.0 Xml;HDR=YES;IMEX=1" + Convert.ToString((char)34);


                conexion.Open();
                comando.CommandText = "SELECT * FROM [" + data + "$] where valido=1";
                comando.Connection = conexion;
                adaptador.SelectCommand = comando;
                adaptador.Fill(dsexcel);
                conexion.Close();
                return dsexcel;

            }
            catch (Exception ex)
            {

                String asd = ex.Message;
                throw;
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorExcel
{
    public class LeeXLS : ILeerFormato
    {
        public DataSet extraerDatos(String NombreHoja, String RutaArchivo)
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
                conexion.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelPath + "; Extended Properties= \"Excel 8.0;HDR=YES;IMEX=1\"";
                conexion.Open();
                comando.CommandText = "SELECT * FROM [" + data + "$] where valido=1";
                comando.Connection = conexion;
                adaptador.SelectCommand = comando;
                adaptador.Fill(dsexcel);
                conexion.Close();
                return dsexcel;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

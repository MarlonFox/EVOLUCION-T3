using System;
using System.Data;
namespace LectorExcel
{
    public interface ILeerFormato
    {
         DataSet extraerDatos(String NombreHoja, String RutaArchivo);
    }
}

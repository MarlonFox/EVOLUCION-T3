using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorExcel
{
    public class GestionarExcel
    {
        // Formato puede ser .xls o .xlsx
        public DataSet obtenerData(string formato,string nombreHoja, string rutaArchivo)
        {
            ILeerFormato estrategiaLector = FabricaEstrategia.Instancia.crearEstrategiaLector(formato);

          
            return estrategiaLector.extraerDatos(nombreHoja,rutaArchivo);

        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorExcel
{
    public class FabricaEstrategia
    {
        //--- Singleton ---
        private static FabricaEstrategia _instancia;
        public static FabricaEstrategia Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new FabricaEstrategia();
                return _instancia;
            }
        }
        protected FabricaEstrategia() { }
        //--- Singleton ---

        public ILeerFormato crearEstrategiaLector(string formato)
        {
            string claseEstrategia=string.Empty;
            //Aqui se podria implementar con property
            ////StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/ruta/archivo.txt"));
            if (formato==".xls")
	        {
                ILeerFormato leerFormato = new LeeXLS();
                return leerFormato;
	        }
            else if(formato==".xlsx")
            {
                ILeerFormato leerFormato = new LeeXLSX();
                return leerFormato;
            }
            else
            {
                return null;
            }            
        }

    }
}

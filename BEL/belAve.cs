using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belAve : belCarne
    {
        public belAve(object[] array)
        {
            Id = array[0].ToString();
            Nombre = array[1].ToString();
            PrecioKG = decimal.Parse(array[2].ToString());
        }
        public belAve(string pId, string pNombre, decimal pPrecio)
        {
            Id = pId;
            Nombre = pNombre;
            PrecioKG = pPrecio;
        }
    }
}

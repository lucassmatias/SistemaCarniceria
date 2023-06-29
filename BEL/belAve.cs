using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belAve : belCarne
    {
        public belAve(string pNombre, decimal pPrecio)
        {
            Nombre = pNombre;
            PrecioKG = pPrecio;
        }
    }
}

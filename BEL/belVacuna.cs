using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belVacuna : belCarne
    {
        public belVacuna(string pNombre, decimal pPrecio)
        {
            Nombre = pNombre;
            PrecioKG = pPrecio;
        }
    }
}

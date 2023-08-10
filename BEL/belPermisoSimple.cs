using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belPermisoSimple : belPermiso
    {
        public belPermisoSimple(string pNombre)
        {
            Nombre = pNombre;
        }
        public belPermisoSimple(object[] array)
        {
            Id = array[0].ToString();
            Nombre = array[1].ToString();
        }
    }
}

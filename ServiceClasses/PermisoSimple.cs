using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class PermisoSimple : Permiso
    {
        public PermisoSimple(string pNombre)
        {
            Nombre = pNombre;
        }
        public PermisoSimple(object[] array)
        {
            Id = array[0].ToString();
            Nombre = array[1].ToString();
        }
    }
}

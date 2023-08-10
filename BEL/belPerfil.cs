using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belPerfil : IEntity
    {
        public belPerfil(string pNombre, belPermiso pPermiso)
        {
            Nombre = pNombre;
            Permiso = pPermiso;
        }
        public belPerfil(object[] array)
        {
            Id = array[0].ToString();
            Nombre = array[1].ToString();
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public belPermiso Permiso { get; set; }
    }
}

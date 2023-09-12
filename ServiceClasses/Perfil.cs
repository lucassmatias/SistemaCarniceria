using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class Perfil : IEntity
    {
        public Perfil(string pNombre, Permiso pPermiso)
        {
            Nombre = pNombre;
            Permiso = pPermiso;
        }
        public Perfil(object[] array)
        {
            Id = array[0].ToString();
            Nombre = array[1].ToString();
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public Permiso Permiso { get; set; }
    }
}

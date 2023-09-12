
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace ServiceClasses
{
    public class Idioma : IEntity
    {
        public Idioma() { }
        public Idioma(string pId, string pNombre)
        {
            Id = pId;
            Nombre = pNombre;
            ListaEtiquetas = new List<Etiqueta>();
        }
        public Idioma(object[] array)
        {
            Id = array[0].ToString();
            Nombre = array[1].ToString();
            ListaEtiquetas = new List<Etiqueta>();
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public List<Etiqueta> ListaEtiquetas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace ServiceClasses
{
    public class Etiqueta : IEntity
    {
        public Etiqueta(string pTag, string pTexto, Idioma pIdioma)
        {
            Tag = pTag;
            Texto = pTexto;
            Id = pIdioma.Id;
        }
        public Etiqueta(object[] array)
        {
            Id = array[0].ToString(); 
            Tag = array[1].ToString();
            Texto = array[2].ToString();
        }
        public string Tag { get; set; }
        public string Texto { get; set; }
        public string Id { get; set; }
    }
}

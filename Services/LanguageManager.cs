using BEL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LanguageManager
    {
        List<ITraducible> Lista;
        belIdioma Idioma;
        public void Suscribir(ITraducible pObject)
        {
            Lista.Add(pObject);
        }
        public void CambiarIdioma(belIdioma pIdioma)
        {
            Idioma = pIdioma;
            foreach(ITraducible i in Lista)
            {
                i.Update();
            }
        }
        public void DetectarIdioma(belUsuario pUsuario)
        {

        }
    }
}

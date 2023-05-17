using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
namespace BLL
{
    public class bllUsuario : IABMC<belUsuario>
    {
        public void Alta(belUsuario pItem)
        {
            throw new NotImplementedException();
        }

        public void Baja(belUsuario pId)
        {
            throw new NotImplementedException();
        }

        public List<belUsuario> Consulta()
        {
            throw new NotImplementedException();
        }

        public belUsuario Consulta(string pId)
        {
            throw new NotImplementedException();
        }

        public List<belUsuario> ConsultaDesdeHasta(string pStringDesde, string pStringHasta)
        {
            throw new NotImplementedException();
        }

        public List<belUsuario> ConsultaIncremental(string pString)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belUsuario pItem)
        {
            throw new NotImplementedException();
        }
    }
}

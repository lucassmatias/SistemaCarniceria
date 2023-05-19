using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
using Mappers;
namespace BLL
{
    public class bllUsuario : IABMC<belUsuario>
    {
        Mapper_Usuario map = new Mapper_Usuario();
        public void Alta(belUsuario pItem)
        {
            map.Alta(pItem);
        }

        public void Baja(string pId)
        {
            map.Baja(pId);
        }

        public List<belUsuario> Consulta()
        {
            return map.Consulta();
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
            map.Modificacion(pItem);
        }
    }
}

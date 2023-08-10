using BEL;
using Interfaces;
using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllPerfil : IABMC<belPerfil>
    {
        Mapper_Perfil map = new Mapper_Perfil();
        public void Alta(belPerfil pItem)
        {
            map.Alta(pItem);
        }

        public void Baja(string pId)
        {
            throw new NotImplementedException();
        }

        public List<belPerfil> Consulta()
        {
            return map.Consulta();
        }

        public List<belPerfil> ConsultaCondicional(string pId)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belPerfil pItem)
        {
            throw new NotImplementedException();
        }
    }
}

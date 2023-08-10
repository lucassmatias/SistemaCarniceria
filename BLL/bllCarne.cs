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
    public class bllCarne : IABMC<belCarne>
    {
        Mapper_Carne map = new Mapper_Carne();
        public void Alta(belCarne pItem)
        {
            map.Alta(pItem);
        }

        public void Baja(string pId)
        {
            map.Baja(pId);
        }

        public List<belCarne> Consulta()
        {
            return map.Consulta();
        }

        public List<belCarne> ConsultaCondicional(string pId)
        {
            return map.ConsultaCondicional(pId);
        }

        public void Modificacion(belCarne pItem)
        {
            map.Modificacion(pItem);
        }
    }
}

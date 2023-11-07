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
    public class bllPedidoCompraCarne : IABMC<belPedidoCompraCarne>
    {
        Mapper_PedidoCompraCarne map = new Mapper_PedidoCompraCarne();
        public void Alta(belPedidoCompraCarne pItem)
        {
            map.Alta(pItem);
        }

        public void Baja(string pId)
        {
            map.Baja(pId);
        }

        public List<belPedidoCompraCarne> Consulta()
        {
            throw new NotImplementedException();
        }

        public List<belPedidoCompraCarne> ConsultaCondicional(string pId)
        {
            return map.ConsultaCondicional(pId);
        }

        public void Modificacion(belPedidoCompraCarne pItem)
        {
            throw new NotImplementedException();
        }
    }
}

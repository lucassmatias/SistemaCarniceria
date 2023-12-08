using BEL;
using Interfaces;
using Mappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllPedidoCompra : IABMC<belPedidoCompra>
    {
        Mapper_PedidoCompra map = new Mapper_PedidoCompra();
        public void Alta(belPedidoCompra pItem)
        {
            map.Alta(pItem);
        }

        public void Baja(string pId)
        {
            map.Baja(pId);
        }

        public List<belPedidoCompra> Consulta()
        {
            return map.Consulta();
        }

        public List<belPedidoCompra> ConsultaCondicional(string pId)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belPedidoCompra pItem)
        {
            throw new NotImplementedException();
        }
        public void Cancelar(string pId)
        {
            map.Cancelar(pId);
        }
        public void Recibir(string pId)
        {
            map.Recibir(pId);
        }
        public List<belPedidoCompra> ConsultaVerificacion()
        {
            return map.ConsultaVerificacion();
        }
    }
}

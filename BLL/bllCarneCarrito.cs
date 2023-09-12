using BEL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mappers;
namespace BLL
{
    public class bllCarneCarrito : IABMC<belCarneCarrito>
    {
        Mapper_CarneCarrito map = new Mapper_CarneCarrito();
        public void Alta(belCarneCarrito pItem)
        {
            map.Alta(pItem);
        }

        public void Baja(string pId)
        {
            map.Baja(pId);
        }

        public List<belCarneCarrito> Consulta()
        {
            throw new NotImplementedException();
        }

        public List<belCarneCarrito> ConsultaCondicional(string pId)
        {
            return map.ConsultaCondicional(pId);
        }

        public void Modificacion(belCarneCarrito pItem)
        {
            throw new NotImplementedException();
        }
        public void ModificaciónCarneCarrito(belCarneCarrito pItem, string pCodigoAnterior)
        {
            map.ModificacionCarneCarrito(pItem, pCodigoAnterior);
        }
    }
}

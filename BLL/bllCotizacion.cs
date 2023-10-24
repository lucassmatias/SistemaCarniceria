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
    public class bllCotizacion : IABMC<belCotizacion>
    {
        Mapper_Cotizacion map = new Mapper_Cotizacion();
        public void Alta(belCotizacion pItem)
        {
            map.Alta(pItem);
        }

        public void Baja(string pId)
        {
            map.Baja(pId);
        }

        public List<belCotizacion> Consulta()
        {
            throw new NotImplementedException();
        }

        public List<belCotizacion> ConsultaCondicional(string pId)
        {
            return map.ConsultaCondicional(pId);
        }

        public void Modificacion(belCotizacion pItem)
        {
            map.Modificacion(pItem);
        }
    }
}

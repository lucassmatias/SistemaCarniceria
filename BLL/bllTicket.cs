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
    public class bllTicket : IABMC<belTicket>
    {
        Mapper_Ticket map = new Mapper_Ticket();
        public void Alta(belTicket pItem)
        {
            map.Alta(pItem);
        }

        public void Baja(string pId)
        {
            map.Baja(pId);
        }

        public List<belTicket> Consulta()
        {
            return map.Consulta();
        }

        public List<belTicket> ConsultaCondicional(string pId)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belTicket pItem)
        {
            throw new NotImplementedException();
        }
        public void AgregarCodigo(belTicket pObject)
        {
            pObject.Id = (map.ConsultaCodigo() + 1).ToString();
        }
        public List<belTicket> ConsultaVerificacion()
        {
            return map.ConsultaVerificacion();
        }
    }
}

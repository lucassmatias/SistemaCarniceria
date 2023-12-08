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
    public class bllProveedor : IABMC<belProveedor>
    {
        Mapper_Proveedor map = new Mapper_Proveedor();
        public void Alta(belProveedor pItem)
        {
            map.Alta(pItem);
        }

        public void Baja(string pId)
        {
            map.Baja(pId);
        }

        public List<belProveedor> Consulta()
        {
            return map.Consulta();
        }

        public List<belProveedor> ConsultaCondicional(string pId)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belProveedor pItem)
        {
            map.Modificacion(pItem);
        }
        public List<belProveedor> ConsultaVerificacion()
        {
            return map.ConsultaVerificacion();
        }
    }
}

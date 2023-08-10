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
    public class bllPermiso : IABMC<belPermiso>
    {
        Mapper_Permiso map = new Mapper_Permiso();
        public void Alta(belPermiso pItem)
        {
            throw new NotImplementedException();
        }
        public void AltaConRelacion(belPermiso pItem, belPermiso pItemPadre = null)
        {
            if(pItemPadre != null)
            {
                map.AltaPermisoConRelacion(pItem, pItemPadre);
            }
            else
            {
                map.AltaPermisoConRelacion(pItem, null);
            }
        }
        public void Baja(string pId)
        {
            throw new NotImplementedException();
        }

        public List<belPermiso> Consulta()
        {
            return map.Consulta();
        }

        public List<belPermiso> ConsultaCondicional(string pId)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belPermiso pItem)
        {
            throw new NotImplementedException();
        }
    }
}

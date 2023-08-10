using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belPermisoCompuesto : belPermiso
    {
        public List<belPermiso> ListaPermiso;
        public belPermisoCompuesto(string pNombre)
        {
            Nombre = pNombre;
            ListaPermiso = new List<belPermiso>(); 
        }
        public belPermisoCompuesto(object[] array)
        {
            Id = array[0].ToString();
            Nombre = array[1].ToString();
            ListaPermiso = new List<belPermiso>();
        }
        public void AgregarPermiso(belPermiso pObject)
        {
            ListaPermiso.Add(pObject);
        }
        public void EliminarPermiso(belPermiso pObject)
        {
            ListaPermiso.Remove(pObject);
        }
        public belPermiso BuscarPermisoNombre(string pNombre, belPermisoCompuesto pPermisoActual, belPermiso pPermiso)
        {
            if (pPermisoActual.ListaPermiso.Count > 0)
            {
                foreach (belPermiso per in pPermisoActual.ListaPermiso)
                {
                    if (per.Nombre == pNombre)
                    {
                        pPermiso = per;
                    }
                    else
                    {
                        if(per is belPermisoCompuesto)
                        {
                            pPermiso = (per as belPermisoCompuesto).BuscarPermisoNombre(pNombre, (per as belPermisoCompuesto), pPermiso);
                        }                    
                    }
                }
            }
            return pPermiso;
        }
        public belPermiso BuscarPermisoId(string pId, belPermisoCompuesto pPermisoActual, belPermiso pPermiso)
        {
            if (pPermisoActual.ListaPermiso.Count > 0)
            {
                foreach (belPermiso per in pPermisoActual.ListaPermiso)
                {
                    if (per.Id == pId)
                    {
                        pPermiso = per;
                    }
                    else
                    {
                        if (per is belPermisoCompuesto)
                        {
                            pPermiso = (per as belPermisoCompuesto).BuscarPermisoId(pId, (per as belPermisoCompuesto), pPermiso);
                        }
                    }
                }
            }
            return pPermiso;
        }
        public void RetornaArrayPermisos(belPermisoCompuesto pPermisoActual, List<belPermiso> pLista)
        {
            foreach(belPermiso per in pPermisoActual.ListaPermiso)
            {
                pLista.Add(per);
                if(per is belPermisoCompuesto)
                {
                    RetornaArrayPermisos(per as belPermisoCompuesto, pLista);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class PermisoCompuesto : Permiso
    {
        public List<Permiso> ListaPermiso;
        public PermisoCompuesto(string pNombre)
        {
            Nombre = pNombre;
            ListaPermiso = new List<Permiso>(); 
        }
        public PermisoCompuesto(object[] array)
        {
            Id = array[0].ToString();
            Nombre = array[1].ToString();
            ListaPermiso = new List<Permiso>();
        }
        public void AgregarPermiso(Permiso pObject)
        {
            ListaPermiso.Add(pObject);
        }
        public void EliminarPermiso(Permiso pObject)
        {
            ListaPermiso.Remove(pObject);
        }
        public Permiso BuscarPermisoNombre(string pNombre, PermisoCompuesto pRaiz)
        {
            return BuscarPermisoNombreRecursiva(pNombre, pRaiz, null);
        }
        private Permiso BuscarPermisoNombreRecursiva(string pNombre, PermisoCompuesto pPermisoActual, Permiso pPermiso)
        {
            if (pPermisoActual.ListaPermiso.Count > 0)
            {
                foreach (Permiso per in pPermisoActual.ListaPermiso)
                {
                    if (per.Nombre == pNombre)
                    {
                        pPermiso = per;
                    }
                    else
                    {
                        if(per is PermisoCompuesto)
                        {
                            pPermiso = (per as PermisoCompuesto).BuscarPermisoNombreRecursiva(pNombre, (per as PermisoCompuesto), pPermiso);
                        }                    
                    }
                }
            }
            return pPermiso;
        }
        public Permiso BuscarPermisoId(string pId, PermisoCompuesto pRaiz)
        {
            return BuscarPermisoIdRecursiva(pId, pRaiz, null);
        }
        private Permiso BuscarPermisoIdRecursiva(string pId, PermisoCompuesto pPermisoActual, Permiso pPermiso)
        {
            if (pPermisoActual.ListaPermiso.Count > 0)
            {
                foreach (Permiso per in pPermisoActual.ListaPermiso)
                {
                    if (per.Id == pId)
                    {
                        pPermiso = per;
                    }
                    else
                    {
                        if (per is PermisoCompuesto)
                        {
                            pPermiso = (per as PermisoCompuesto).BuscarPermisoIdRecursiva(pId, (per as PermisoCompuesto), pPermiso);
                        }
                    }
                }
            }
            return pPermiso;
        }
        public void RellenaArrayPermisos(PermisoCompuesto pPermisoActual, List<Permiso> pLista)
        {
            foreach(Permiso per in pPermisoActual.ListaPermiso)
            {
                pLista.Add(per);
                if(per is PermisoCompuesto)
                {
                    RellenaArrayPermisos(per as PermisoCompuesto, pLista);
                }
            }
        }
    }
}

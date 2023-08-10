using BEL;
using DAL;
using Interfaces;
using Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public class Mapper_Permiso : IABMC<belPermiso>
    {
        ArrayList al;
        DAO dao = new DAO();
        public void Alta(belPermiso pItem)
        {
            throw new NotImplementedException();
        }
        public void AltaPermisoConRelacion(belPermiso pItem, belPermiso pItemPadre = null)
        {
            string storedProcedure = "S_Permiso_Crear";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@nom";
            p1.Value = pItem.Nombre;
            p1.SqlDbType = SqlDbType.NVarChar;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@bool";
            p2.SqlDbType = SqlDbType.Bit;
            if (pItem is belPermisoSimple)
            {
                p2.Value = 0;
            }
            else
            {
                p2.Value = 1;
            }
            al.Add(p2);
            dao.Escribir(storedProcedure, al);
            if(pItemPadre != null)
            {
                al.Clear();
                storedProcedure = "S_PermisoPermiso_Crear";
                al = new ArrayList();
                SqlParameter p3 = new SqlParameter();
                p3.ParameterName = "@com";
                p3.Value = pItemPadre.Id;
                p3.SqlDbType = SqlDbType.Int;
                al.Add(p3);
                SqlParameter p4 = new SqlParameter();
                p4.ParameterName = "@sim";
                p4.Value = RetornaUltimoId();
                p4.SqlDbType = SqlDbType.Int;
                al.Add(p4);
                dao.Escribir(storedProcedure, al);
            }
        }
        private string RetornaUltimoId()
        {
            string storedProcedure = "S_Permiso_ListarUltimoID";
            DataTable dt = dao.Leer(storedProcedure);
            string id = dt.Rows[0].ItemArray[0].ToString();
            return id;
        }
        public void Baja(string pId)
        {
            throw new NotImplementedException();
        }

        public List<belPermiso> Consulta()
        {
            string storedProcedure = "S_Permiso_Listar";
            DataTable dt = dao.Leer(storedProcedure);
            List<belPermiso> lPermiso = new List<belPermiso>();
            List<belPermiso> lArbol = new List<belPermiso>();
            foreach (DataRow dr in dt.Rows)
            {
                if (bool.Parse(dr[2].ToString()) == false)
                {
                    belPermisoSimple permiso = new belPermisoSimple(dr.ItemArray);
                    lPermiso.Add(permiso);
                }
                else
                {
                    belPermisoCompuesto permiso = new belPermisoCompuesto(dr.ItemArray);
                    lPermiso.Add(permiso);
                }
            }
            storedProcedure = "S_PermisoPermiso_ListarTodo";
            DataTable dt2 = dao.Leer(storedProcedure);
            belPermisoCompuesto aux = new belPermisoCompuesto("Raiz");
            foreach (belPermiso per in lPermiso)
            {
                if (per is belPermisoCompuesto)
                {
                    ArmarRelaciones(per as belPermisoCompuesto, dt2, lPermiso);
                    aux.AgregarPermiso(per);
                }
                else
                {
                    aux.AgregarPermiso(per);
                }
            }
            lArbol.Add(aux);
            return lArbol;
        }
        public void ArmarRelaciones(belPermisoCompuesto permiso, DataTable relaciones, List<belPermiso> lista)
        {
            foreach(DataRow dr in relaciones.Rows)
            {
                if (dr[0].ToString() == permiso.Id)
                {
                    permiso.AgregarPermiso(lista.Find(x => x.Id == dr[1].ToString()));
                }
            }
        }
        public void Modificacion(belPermiso pItem)
        {
            throw new NotImplementedException();
        }

        public List<belPermiso> ConsultaCondicional(string pId)
        {
            throw new NotImplementedException();
        }
    }
}

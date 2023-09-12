using BEL;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public static class ProfileManager
    {
        static DAO dao = new DAO();
        static ArrayList al;
        public static List<Perfil> ListaPerfil;
        public static PermisoCompuesto PermisoRaiz;
        public static void InicializarServicio()
        {
            PermisoRaiz = ConsultaPermiso()[0] as PermisoCompuesto;
            ListaPerfil = ConsultaPerfil();
        }
        public static Perfil Perfil(string pId)
        {
            return ListaPerfil.Find(x => x.Id == pId);
        }
        private static void ActualizaListaPerfil()
        {
            ListaPerfil = ConsultaPerfil();
        }
        private static void ActualizaPermisoRaiz()
        {
            PermisoRaiz = ConsultaPermiso()[0] as PermisoCompuesto;
        }
        public static void AltaPerfil(Perfil pItem)
        {
            string storedProcedure = "S_Perfil_Crear";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@nom";
            p1.Value = pItem.Nombre;
            p1.SqlDbType = SqlDbType.NVarChar;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@per";
            p2.Value = pItem.Permiso.Id;
            p2.SqlDbType = SqlDbType.Int;
            al.Add(p2);
            dao.Escribir(storedProcedure, al);
            ActualizaListaPerfil();
        }

        public static void BajaPerfil(string pId)
        {
            string storedProcedure = "S_Perfil_Eliminar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@id";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
            ActualizaListaPerfil();
        }
        public static List<Perfil> ConsultaPerfil()
        {
            string storedProcedure = "S_Perfil_Listar";
            DataTable dt = dao.Leer(storedProcedure);
            List<Perfil> lPerfil = new List<Perfil>();
            foreach(DataRow dr in dt.Rows)
            {
                Perfil aux = new Perfil(dr.ItemArray);
                aux.Permiso = PermisoRaiz.BuscarPermisoId(dr[2].ToString(), PermisoRaiz);
                lPerfil.Add(aux);
            }
            return lPerfil;
        }
        public static void AltaPermisoConRelacion(Permiso pItem, Permiso pItemPadre = null)
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
            if (pItem is PermisoSimple)
            {
                p2.Value = 0;
            }
            else
            {
                p2.Value = 1;
            }
            al.Add(p2);
            dao.Escribir(storedProcedure, al);
            if (pItemPadre != null)
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
                p4.Value = RetornaUltimoIdPermiso();
                p4.SqlDbType = SqlDbType.Int;
                al.Add(p4);
                dao.Escribir(storedProcedure, al);
            }
            ActualizaPermisoRaiz();
        }
        private static string RetornaUltimoIdPermiso()
        {
            string storedProcedure = "S_Permiso_ListarUltimoID";
            DataTable dt = dao.Leer(storedProcedure);
            string id = dt.Rows[0].ItemArray[0].ToString();
            return id;
        }
        public static void BajaPermiso(string pId)
        {
            string storedProcedure = "S_Permiso_Eliminar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@id";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
            storedProcedure = "S_PermisoPermiso_Eliminar";
            dao.Escribir(storedProcedure, al);
            ActualizaPermisoRaiz();
        }
        public static List<Permiso> ConsultaPermiso()
        {
            string storedProcedure = "S_Permiso_Listar";
            DataTable dt = dao.Leer(storedProcedure);
            List<Permiso> lPermiso = new List<Permiso>();
            List<Permiso> lArbol = new List<Permiso>();
            foreach (DataRow dr in dt.Rows)
            {
                if (bool.Parse(dr[2].ToString()) == false)
                {
                    PermisoSimple permiso = new PermisoSimple(dr.ItemArray);
                    lPermiso.Add(permiso);
                }
                else
                {
                    PermisoCompuesto permiso = new PermisoCompuesto(dr.ItemArray);
                    lPermiso.Add(permiso);
                }
            }
            storedProcedure = "S_PermisoPermiso_ListarTodo";
            DataTable dt2 = dao.Leer(storedProcedure);
            PermisoCompuesto aux = new PermisoCompuesto("Raiz");
            foreach (Permiso per in lPermiso)
            {
                if (per is PermisoCompuesto)
                {
                    ArmarRelaciones(per as PermisoCompuesto, dt2, lPermiso);
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
        public static void ArmarRelaciones(PermisoCompuesto permiso, DataTable relaciones, List<Permiso> lista)
        {
            foreach (DataRow dr in relaciones.Rows)
            {
                if (dr[0].ToString() == permiso.Id)
                {
                    permiso.AgregarPermiso(lista.Find(x => x.Id == dr[1].ToString()));
                }
            }
        }
    }
}

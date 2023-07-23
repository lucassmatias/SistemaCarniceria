using BEL;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace Services
{
    public class LanguageManager
    {
        private static LanguageManager instance;
        private static object _lock = new object();
        private LanguageManager() { Lista = new List<ITraducible>(); }
        static List<ITraducible> Lista;
        public static LanguageManager GetInstance
        {
            get
            {
                if (instance == null) throw new Exception("Instancia no creada");
                return instance;
            }
        }
        public static void Suscribir(ITraducible pObject)
        {
            Lista.Add(pObject);
        }
        public static void Desuscribir(ITraducible pObject)
        {
            Lista.Remove(pObject);
        }
        public Idioma ConsultaIdiomaNombre(string pString)
        {
            DAO dao = new DAO();
            string storedProcedure = "S_Idioma_SeleccionarNombre";
            ArrayList al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@nom";
            p1.Value = pString;
            p1.SqlDbType = SqlDbType.VarChar;
            al.Add(p1);
            DataTable dt = dao.Leer(storedProcedure, al);
            Idioma idioma = new Idioma();
            foreach (DataRow dr in dt.Rows)
            {
                idioma = null;
                idioma = new Idioma(dr.ItemArray);
            }
            storedProcedure = "S_Etiqueta_Listar";
            DataTable dt2 = dao.Leer(storedProcedure, al);
            foreach (DataRow dr in dt2.Rows)
            {
                Etiqueta etiqueta = new Etiqueta(dr.ItemArray);
                idioma.ListaEtiquetas.Add(etiqueta);
            }
            return idioma;
        }
        public Idioma ConsultaIdiomaUsuario(belUsuario pUsuario = null)
        {
            int x = 1;
            if (pUsuario != null) x = int.Parse(pUsuario.Idioma.Id);
            DAO dao = new DAO();
            string storedProcedure = "S_Idioma_Seleccionar";
            ArrayList al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = x;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            DataTable dt = dao.Leer(storedProcedure, al);
            Idioma idioma = new Idioma();
            foreach (DataRow dr in dt.Rows)
            {
                idioma = null;
                idioma = new Idioma(dr.ItemArray);
            }
            storedProcedure = "S_Etiqueta_Listar";
            DataTable dt2 = dao.Leer(storedProcedure, al);
            foreach(DataRow dr in dt2.Rows)
            {
                Etiqueta etiqueta = new Etiqueta(dr.ItemArray);
                idioma.ListaEtiquetas.Add(etiqueta);
            }
            return idioma;
        }
        public Idioma ConsultaIdiomaCodigo(int pCodigo)
        {
            DAO dao = new DAO();
            string storedProcedure = "S_Idioma_Seleccionar";
            ArrayList al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pCodigo;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            DataTable dt = dao.Leer(storedProcedure, al);
            Idioma idioma = new Idioma();
            foreach (DataRow dr in dt.Rows)
            {
                idioma = null;
                idioma = new Idioma(dr.ItemArray);
            }
            storedProcedure = "S_Etiqueta_Listar";
            DataTable dt2 = dao.Leer(storedProcedure, al);
            foreach (DataRow dr in dt2.Rows)
            {
                Etiqueta etiqueta = new Etiqueta(dr.ItemArray);
                idioma.ListaEtiquetas.Add(etiqueta);
            }
            return idioma;
        }
        public void CambiarIdioma(Idioma pIdioma) 
        {
            foreach (ITraducible i in Lista)
            {
                i.Update(pIdioma);
            }
        }
        public static void CrearInstancia()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new LanguageManager();
                }
                else
                {
                    throw new Exception("Sesión ya está iniciada");
                }
            }
        }
        public static void EliminarInstancia()
        {
            lock (_lock)
            {
                if (instance != null)
                {
                    instance = null;
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }
            }
        }
    }
}

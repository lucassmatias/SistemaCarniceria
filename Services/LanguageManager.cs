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
using ServiceClasses;

namespace Services
{
    public static class LanguageManager
    {
        static List<ITraducible> ListaSuscriptores;
        public static List<Idioma> ListaIdioma;
        public static void Suscribir(ITraducible pObject)
        {
            if(ListaSuscriptores == null) { ListaSuscriptores = new List<ITraducible>(); }
            ListaSuscriptores.Add(pObject);
        }
        public static void Desuscribir(ITraducible pObject)
        {
            ListaSuscriptores.Remove(pObject); 
        }
        public static Idioma ConsultaIdiomaCodigo(int pCodigo)
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
        public static void InicializarServicio()
        {
            ListaIdioma = new List<Idioma>();
            DAO dao = new DAO();
            string storedProcedure = "S_Idioma_SeleccionaIDs";
            DataTable dt = dao.Leer(storedProcedure);
            foreach(DataRow dr in dt.Rows)
            {
                if (dr[0] != null)
                {
                    ListaIdioma.Add(ConsultaIdiomaCodigo(int.Parse(dr[0].ToString())));
                }
            }
        }
        public static void CambiarIdioma(string pCodigoIdioma) 
        {
            foreach (ITraducible i in ListaSuscriptores)
            {
                i.Update(pCodigoIdioma);
            }
        }
        public static Idioma Idioma(string pId)
        {
            return ListaIdioma.Find(x => x.Id == pId);
        }
        public static void AltaEtiqueta(string pIdiomaCodigo, string pTag)
        {
            DAO dao = new DAO();
            string storedProcedure = "S_Etiqueta_Crear";
            ArrayList al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@id";
            p1.Value = pIdiomaCodigo;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@tag";
            p2.Value = pTag;
            p2.SqlDbType = SqlDbType.NVarChar;
            al.Add(p2);
            dao.Escribir(storedProcedure, al);
        }
        public static void ModificarEtiqueta(string pIdiomaCodigo, string pTag, string pTexto)
        {
            DAO dao = new DAO();
            string storedProcedure = "S_Etiqueta_Modificar";
            ArrayList al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@id";
            p1.Value = pIdiomaCodigo;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@tag";
            p2.Value = pTag;
            p2.SqlDbType = SqlDbType.NVarChar;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@txt";
            p3.Value = pTexto;
            p3.SqlDbType = SqlDbType.NVarChar;
            al.Add(p3);
            dao.Escribir(storedProcedure, al);
            ListaIdioma[int.Parse(pIdiomaCodigo) - 1] = ConsultaIdiomaCodigo(int.Parse(pIdiomaCodigo));
        }
    }
}

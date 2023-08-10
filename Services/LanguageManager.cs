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
        static List<ITraducible> Lista;
        public static void Suscribir(ITraducible pObject)
        {
            if(Lista == null) { Lista = new List<ITraducible>(); }         
            Lista.Add(pObject);
        }
        public static void Desuscribir(ITraducible pObject)
        {
            Lista.Remove(pObject); 
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
        public static void CambiarIdioma(Idioma pIdioma) 
        {
            foreach (ITraducible i in Lista)
            {
                i.Update(pIdioma);
            }
        }
    }
}

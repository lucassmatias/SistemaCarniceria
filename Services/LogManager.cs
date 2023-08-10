using BEL;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LogManager
    {
        static DAO dao = new DAO();
        public static void Add(string sLog, belUsuario pUsuario = null)
        {
            ArrayList al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@fec";
            p1.Value = DateTime.Now;
            p1.SqlDbType = SqlDbType.DateTime;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@txt";
            p2.Value = sLog;
            p2.SqlDbType = SqlDbType.NVarChar;
            al.Add(p2);
            string storedProcedure = "";
            if(pUsuario != null)
            {
                storedProcedure = "S_Bitacora_Crear";
                SqlParameter p3 = new SqlParameter();
                p3.ParameterName = "@user";
                p3.Value = pUsuario.Username;
                p3.SqlDbType = SqlDbType.NVarChar;
                al.Add(p3);
                dao.Escribir(storedProcedure, al);
            }
            else
            {
                storedProcedure = "S_Bitacora_CrearSinUsuario";
                dao.Escribir(storedProcedure, al);
            }
        }
        public static List<Array> RetornaBitacora()
        {
            List<Array> lBitacora = new List<Array>();
            string storedProcedure = "S_Bitacora_Listar";
            DataTable dt = dao.Leer(storedProcedure);
            foreach(DataRow dr in dt.Rows )
            {
                Array aux = dr.ItemArray;
                lBitacora.Add(aux);
            }
            return lBitacora;
        } 
    }
}

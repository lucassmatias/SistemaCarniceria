using BEL;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
        public static void AgregarLogEvento(string sLog, int pCriticidad, belUsuario pUsuario = null)
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
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@cri";
            p3.Value = pCriticidad;
            p3.SqlDbType = SqlDbType.Int;
            al.Add(p3);
            string storedProcedure = "";
            if(pUsuario != null)
            {
                storedProcedure = "S_Bitacora_Crear";
                SqlParameter p4 = new SqlParameter();
                p4.ParameterName = "@user";
                p4.Value = pUsuario.Username;
                p4.SqlDbType = SqlDbType.NVarChar;
                al.Add(p4);
                dao.Escribir(storedProcedure, al);
            }
            else
            {
                storedProcedure = "S_Bitacora_CrearSinUsuario";
                dao.Escribir(storedProcedure, al);
            }
        }
        public static void AgregarLogCambio(belCarne carne, belUsuario pUsuario)
        {
            string storedProcedure = "S_CambioCarne_Crear";
            ArrayList al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = carne.Id;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@nom";
            p2.Value = carne.Nombre;
            p2.SqlDbType = SqlDbType.VarChar;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@pre";
            p3.Value = carne.PrecioKG;
            p3.SqlDbType = SqlDbType.Decimal;
            al.Add(p3);
            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@tip";
            p4.Value = DevolverIntCarne(carne);
            p4.SqlDbType = SqlDbType.Int;
            al.Add(p4);
            SqlParameter p5 = new SqlParameter();
            p5.ParameterName = "@sto";
            p5.Value = carne.StockKG;
            p5.SqlDbType = SqlDbType.Decimal;
            al.Add(p5);
            SqlParameter p6 = new SqlParameter();
            p6.ParameterName = "@fec";
            p6.Value = DateTime.Now;
            p6.SqlDbType = SqlDbType.DateTime;
            al.Add(p6);
            SqlParameter p7 = new SqlParameter();
            p7.ParameterName = "@usu";
            p7.Value = pUsuario.Id;
            p7.SqlDbType = SqlDbType.Int;
            al.Add(p7);
            dao.Escribir(storedProcedure, al);
        }
        public static List<Array> RetornaBitacoraEvento()
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
        public static List<object[]> RetornaBitacoraCambio()
        {
            List<object[]> lCambio = new List<object[]>();
            string storedProcedure = "S_CambioCarne_Listar";
            DataTable dt = dao.Leer(storedProcedure);
            foreach(DataRow dr in dt.Rows)
            {
                object[] aux = dr.ItemArray;
                lCambio.Add(aux);
            }
            return lCambio;
        }
        public static void CambiarEstado(string pId, bool pBool)
        {
            string storedProcedure = "S_CambioCarne_CambiarEstado";
            ArrayList al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@act";
            p2.Value = pBool;
            p2.SqlDbType = SqlDbType.Bit;
            al.Add(p2);
            dao.Escribir(storedProcedure, al);
        }
        private static int DevolverIntCarne(belCarne pCarne)
        {
            if(pCarne is belAve) { return 1; }
            else if(pCarne is belPorcina) { return 2; }
            else{ return 3; }
        }

    }
}

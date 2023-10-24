using DAL;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class VerificatorManager
    {
        static DAO dao = new DAO();
        public static string GenerarDVH(IEntity entity)
        {
            Type t = entity.GetType();
            string dvh = string.Empty;
            var props = t.GetProperties();
            var attrs = t.GetCustomAttributes(false);
            foreach (var attr in props)
            {
                if (attr.PropertyType.FullName.Equals(typeof(DateTime).FullName))
                {
                    DateTime dt = (DateTime)attr.GetValue(entity);
                    dvh += dt.ToString("ddmmyyyyhhmmss");
                }
                else
                {
                    dvh += attr.GetValue(entity).ToString();
                }
            }
            return CryptoManager.Encrypt(dvh);
        }
        public static string GenerarTotalDVH(List<IEntity> pList)
        {
            string dvt = string.Empty;
            foreach(IEntity e in pList)
            {
                dvt += GenerarDVH(e);
            }
            return CryptoManager.Encrypt(dvt);
        }
        #region
        public static bool CompararTotalDVH(List<IEntity> pList)
        {
            string Total1 = GenerarTotalDVH(pList);
            string storedProcedure = "S_DVH_RetornaDVTotal";
            string TotalDB = dao.Leer(storedProcedure).Rows[0].ItemArray[0].ToString(); 
            return Total1 == TotalDB ? true : false;
        }
        public static void AltaDVH(IEntity entity)
        {
            string dvh = GenerarDVH(entity);
            bool existeCarne = false;
            string storedProcedure = "S_DVH_RetornaCodigos";
            DataTable dt = dao.Leer(storedProcedure);
            foreach(DataRow dr in dt.Rows)
            {
                if (dr.ItemArray[0].ToString() == entity.Id) { existeCarne = true; }
            }
            ArrayList al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@id";
            p1.Value = entity.Id;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@dvh";
            p2.Value = dvh;
            p2.SqlDbType = SqlDbType.NVarChar;
            al.Add(p2);
            if (!existeCarne)
            {
                storedProcedure = "S_DVH_Agregar";
                dao.Escribir(storedProcedure, al);
            }
            else
            {
                storedProcedure = "S_DVH_Modificar";
                dao.Escribir(storedProcedure, al);
            }
        }
        public static void BajaDVH(string pCodigo)
        {
            string storedProcedure = "S_DVH_Eliminar";
            ArrayList al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@dvh";
            p1.Value = pCodigo;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }
        public static void ModificarTotalDVH(List<IEntity> pList)
        {
            string dvtotal = GenerarTotalDVH(pList);
            string storedProcedure = "S_DVH_ModificarTotal";
            ArrayList al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@dvh";
            p1.Value = dvtotal;
            p1.SqlDbType = SqlDbType.NVarChar;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }
    }
}
#endregion
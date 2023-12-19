using BEL;
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
            foreach (var attr in props)
            {
                if(attr.GetValue(entity) != null)
                {
                    if (attr.PropertyType.FullName.Equals(typeof(DateTime).FullName))
                    {
                        DateTime dt = (DateTime)attr.GetValue(entity);
                        dvh += dt.ToString("yyyymmddhhmmss");
                    }
                    else
                    {
                        dvh += attr.GetValue(entity).ToString();
                    }
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
        public static bool CompararTotalDVH(List<IEntity> pList, string tableName)
        {
            string Total1;
            if(pList.Count == 0)
            {
                Total1 = "0";
            }
            else
            {
                Total1 = GenerarTotalDVH(pList);
            }
            string storedProcedure = $"DVH_{tableName}_RetornaDVTotal";
            string TotalDB = dao.Leer(storedProcedure).Rows[0].ItemArray[0].ToString(); 
            return Total1 == TotalDB ? true : false;
        }
        public static void AltaDVH(List<IEntity> entity, string tableName)
        {
            ArrayList al = new ArrayList();
            SqlParameter p0;
            SqlParameter p1;
            SqlParameter p2;
            string storedProcedure = $"DVH_{tableName}_Eliminar";
            foreach(IEntity e in entity)
            {
                p0 = new SqlParameter();
                p0.ParameterName = "@id";
                p0.Value = e.Id;
                p0.SqlDbType = SqlDbType.Int;
                al.Add(p0);
                dao.Escribir(storedProcedure, al);
                al.Clear();
            }
            storedProcedure = $"DVH_{tableName}_Crear";
            foreach (IEntity e in entity)
            {
                p1 = new SqlParameter();
                p1.ParameterName = "@id";
                p1.Value = e.Id;
                p1.SqlDbType = SqlDbType.Int;
                al.Add(p1);
                p2 = new SqlParameter();
                p2.ParameterName = "@dvh";
                p2.Value = GenerarDVH(e);
                p2.SqlDbType = SqlDbType.NVarChar;
                al.Add(p2);
                dao.Escribir(storedProcedure , al);
                al.Clear();
            }
            ModificaciónTotalDVH(tableName);
        }
        public static void BajaDVH(List<IEntity> entity, string tableName)
        {
            string storedProcedure = $"DVH_{tableName}_Eliminar";
            ArrayList al = new ArrayList();
            SqlParameter p0;
            foreach (IEntity e in entity)
            {
                p0 = new SqlParameter();
                p0.ParameterName = "@id";
                p0.Value = e.Id;
                p0.SqlDbType = SqlDbType.Int;
                al.Add(p0);
                dao.Escribir(storedProcedure, al);
                al.Clear();
            }
            ModificaciónTotalDVH(tableName);
        }
        public static void ModificaciónTotalDVH(string tableName)
        {
            string storedProcedure = $"DVH_{tableName}_Consulta";
            DataTable dt = dao.Leer(storedProcedure);
            string dvtotal = string.Empty;
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    dvtotal += dr.ItemArray[0].ToString();
                }
                dvtotal = CryptoManager.Encrypt(dvtotal);
            }
            else
            {
                dvtotal = "0";
            }
            storedProcedure = $"DVH_{tableName}_ModificarTotal";
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DAL
{
    public class DAO
    {
        SqlConnectionStringBuilder cs;
        SqlCommand com;
        SqlTransaction tra;
        public DataTable Leer(string pStoredProcedure, ArrayList pParams = null)
        {
            cs = new SqlConnectionStringBuilder();
            cs.DataSource = ".";
            cs.InitialCatalog = "dbCarniceria";
            cs.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString;

            DataTable dt = new DataTable();
            SqlDataAdapter da;
            com = new SqlCommand(pStoredProcedure, con);
            com.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();
                da = new SqlDataAdapter(com);
                if(pParams != null)
                {
                    foreach(SqlParameter p in pParams)
                    {
                        com.Parameters.AddWithValue(p.ParameterName, p.Value);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            da.Fill(dt);
            return dt;
        }
        public int Escribir(string pStoredProcedure, ArrayList pParams = null)
        {
            cs = new SqlConnectionStringBuilder();
            cs.DataSource = ".";
            cs.InitialCatalog = "dbCarniceria";
            cs.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cs.ConnectionString;

            try
            {
                con.Open();
                tra = con.BeginTransaction();
                com = new SqlCommand(pStoredProcedure, con, tra);
                com.CommandType = CommandType.StoredProcedure;
                if (pParams != null)
                {
                    foreach (SqlParameter p in pParams)
                    {
                        com.Parameters.AddWithValue(p.ParameterName, p.Value);
                    }
                }
                int returnValue = com.ExecuteNonQuery();
                tra.Commit();
                return returnValue;
            }
            catch (SqlException)
            {             
                tra.Rollback();
                return -1;
            }
            catch (Exception)
            {
                tra.Rollback();
                return -1;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}

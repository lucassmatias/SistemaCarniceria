using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
using Interfaces;
using DAL;
using System.Data;

namespace Mappers
{
    public class Mapper_Usuario : IABMC<belUsuario>
    {
        ArrayList al;
        DAO dao = new DAO();
        public void Alta(belUsuario pItem)
        {
            string storedProcedure = "S_Usuario_Crear";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@nam";
            p1.Value = pItem.Name;
            p1.SqlDbType = SqlDbType.VarChar;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@pas";
            p2.Value = pItem.Password;
            p2.SqlDbType = SqlDbType.NVarChar;
            al.Add(p2);
            dao.Escribir(storedProcedure, al);
        }

        public void Baja(string pId)
        {
            string storedProcedure = "S_Usuario_Eliminar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@id";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }

        public List<belUsuario> Consulta()
        {
            string storedProcedure = "S_Usuario_Listar";
            DataTable dt = dao.Leer(storedProcedure);
            List<belUsuario> lUsuario = new List<belUsuario>();
            foreach(DataRow dr in dt.Rows)
            {
                belUsuario aux = new belUsuario(dr.ItemArray);
                lUsuario.Add(aux);
            }
            return lUsuario;
        }

        public List<belUsuario> ConsultaDesdeHasta(string pStringDesde, string pStringHasta)
        {
            throw new NotImplementedException();
        }

        public List<belUsuario> ConsultaIncremental(string pString)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belUsuario pItem)
        {
            string storedProcedure = "S_Usuario_Modificar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@nom";
            p1.Value = pItem.Name;
            p1.SqlDbType = SqlDbType.VarChar;
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@pas";
            p2.Value = pItem.Password;
            p2.SqlDbType = SqlDbType.NVarChar;
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@blo";
            p3.Value = pItem.Blocked;
            p3.SqlDbType = SqlDbType.Bit;
            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@id";
            p4.Value = pItem.Id;
            p4.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            al.Add(p2);
            al.Add(p3);
            al.Add(p4);
            dao.Escribir(storedProcedure, al);
        }
    }
}

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
using Services;

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
            p1.ParameterName = "@dni";
            p1.Value = pItem.DNI;
            p1.SqlDbType = SqlDbType.NVarChar;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@nom";
            p2.Value = pItem.Nombre;
            p2.SqlDbType = SqlDbType.VarChar;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@ape";
            p3.Value = pItem.Apellido;
            p3.SqlDbType = SqlDbType.VarChar;
            al.Add(p3);
            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@nam";
            p4.Value = pItem.Username;
            p4.SqlDbType = SqlDbType.NVarChar;
            al.Add(p4);
            SqlParameter p5 = new SqlParameter();
            p5.ParameterName = "@pas";
            p5.Value = pItem.Password;
            p5.SqlDbType = SqlDbType.NVarChar;
            al.Add(p5);
            SqlParameter p6 = new SqlParameter();
            p6.ParameterName = "@rol";
            p6.Value = pItem.Rol;
            p6.SqlDbType = SqlDbType.NVarChar;
            al.Add(p6);
            SqlParameter p7 = new SqlParameter();
            p7.ParameterName = "@ema";
            p7.Value = pItem.Email;
            p7.SqlDbType = SqlDbType.NVarChar;
            al.Add(p7);
            SqlParameter p8 = new SqlParameter();
            p8.ParameterName = "@idi";
            p8.Value = pItem.Idioma.Id;
            p8.SqlDbType = SqlDbType.Int;
            al.Add(p8);
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
                aux.Idioma = LanguageManager.GetInstance.ConsultaIdiomaCodigo(int.Parse(dr.ItemArray[dr.ItemArray.Length - 1].ToString()));
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
            p1.ParameterName = "@id";
            p1.Value = pItem.Id;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@dni";
            p2.Value = pItem.DNI;
            p2.SqlDbType = SqlDbType.NVarChar;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@nom";
            p3.Value = pItem.Nombre;
            p3.SqlDbType = SqlDbType.VarChar;
            al.Add(p3);
            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@ape";
            p4.Value = pItem.Apellido;
            p4.SqlDbType = SqlDbType.VarChar;
            al.Add(p4);
            SqlParameter p5 = new SqlParameter();
            p5.ParameterName = "@nam";
            p5.Value = pItem.Username;
            p5.SqlDbType = SqlDbType.NVarChar;
            al.Add(p5);
            SqlParameter p6 = new SqlParameter();
            p6.ParameterName = "@pas";
            p6.Value = pItem.Password;
            p6.SqlDbType = SqlDbType.NVarChar;
            al.Add(p6);
            SqlParameter p7 = new SqlParameter();
            p7.ParameterName = "@rol";
            p7.Value = pItem.Rol;
            p7.SqlDbType = SqlDbType.NVarChar;
            al.Add(p7);
            SqlParameter p8 = new SqlParameter();
            p8.ParameterName = "@ema";
            p8.Value = pItem.Email;
            p8.SqlDbType = SqlDbType.NVarChar;
            al.Add(p8);
            SqlParameter p9 = new SqlParameter();
            p9.ParameterName = "@blo";
            p9.Value = pItem.Blocked;
            p9.SqlDbType = SqlDbType.Bit;
            al.Add(p9);
            SqlParameter p10 = new SqlParameter();
            p10.ParameterName = "@act";
            p10.Value = pItem.Activo;
            p10.SqlDbType = SqlDbType.Bit;
            al.Add(p10);
            dao.Escribir(storedProcedure, al);
        }
    }
}

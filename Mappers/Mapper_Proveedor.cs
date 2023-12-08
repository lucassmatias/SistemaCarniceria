using BEL;
using DAL;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mappers
{
    public class Mapper_Proveedor : IABMC<belProveedor>
    {
        ArrayList al;
        DAO dao = new DAO();
        public void Alta(belProveedor pItem)
        {
            string storedProcedure = "S_Proveedor_Crear";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@nom";
            p1.Value = pItem.Nombre;
            p1.SqlDbType = SqlDbType.NVarChar;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }

        public void Baja(string pId)
        {
            string storedProcedure = "S_Proveedor_Eliminar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }

        public List<belProveedor> Consulta()
        {
            List<belProveedor> aux = new List<belProveedor>();
            string storedProcedure = "S_Proveedor_Listar";
            DataTable dt = dao.Leer(storedProcedure);
            if(dt.Rows.Count != 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    Mapper_Cotizacion map = new Mapper_Cotizacion();
                    List<belCotizacion> aux2 = new List<belCotizacion>();
                    aux2 = map.ConsultaCondicional(dr[0].ToString());
                    aux.Add(new belProveedor(dr.ItemArray, aux2));
                }
            }
            return aux;
        }

        public List<belProveedor> ConsultaCondicional(string pId)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belProveedor pItem)
        {
            string storedProcedure = "S_Proveedor_Modificar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@nom";
            p1.Value = pItem.Nombre;
            p1.SqlDbType = SqlDbType.NVarChar;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@loc";
            p2.Value = pItem.Localidad;
            p2.SqlDbType = SqlDbType.NVarChar;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@dir";
            p3.Value = pItem.Direccion;
            p3.SqlDbType = SqlDbType.NVarChar;
            al.Add(p3);
            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@tel";
            p4.Value = pItem.Telefono;
            p4.SqlDbType = SqlDbType.NVarChar;
            al.Add(p4);
            SqlParameter p5 = new SqlParameter();
            p5.ParameterName = "@mai";
            p5.Value = pItem.Mail;
            p5.SqlDbType = SqlDbType.NVarChar;
            al.Add(p5);
            SqlParameter p6 = new SqlParameter();
            p6.ParameterName = "@cos";
            p6.Value = pItem.CostoEnvio;
            p6.SqlDbType = SqlDbType.Decimal;
            al.Add(p6);
            SqlParameter p7 = new SqlParameter();
            p7.ParameterName = "@cod";
            p7.Value = pItem.Id;
            p7.SqlDbType = SqlDbType.Int;
            al.Add(p7);
            dao.Escribir(storedProcedure, al);
        }
        public List<belProveedor> ConsultaVerificacion()
        {
            string storedProcedure = "S_Proveedor_ConsultaVerificacion";
            List<belProveedor> l = new List<belProveedor>();
            DataTable dt = dao.Leer(storedProcedure);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    l.Add(new belProveedor(dr.ItemArray));
                }
            }
            return l;
        }
    }
}

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
    public class Mapper_Cotizacion : IABMC<belCotizacion>
    {
        ArrayList al;
        DAO dao = new DAO();
        public void Alta(belCotizacion pItem)
        {
            string storedProcedure = "S_Cotizacion_Crear";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@pro";
            p1.Value = pItem.Id;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@car";
            p2.Value = pItem.Carne.Id;
            p2.SqlDbType = SqlDbType.Int;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@can";
            p3.Value = pItem.Cantidad;
            p3.SqlDbType = SqlDbType.Decimal;
            al.Add(p3);
            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@pre";
            p4.Value = pItem.Precio;
            p4.SqlDbType = SqlDbType.Decimal;
            al.Add(p4);
            dao.Escribir(storedProcedure, al);
        }

        public void Baja(string pId)
        {
            string storedProcedure = "S_Cotizacion_Eliminar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }

        public List<belCotizacion> Consulta()
        {
            throw new NotImplementedException();
        }

        public List<belCotizacion> ConsultaCondicional(string pId)
        {
            List<belCotizacion> aux = new List<belCotizacion>();
            string storedProcedure = "S_Cotizacion_ListarId";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            DataTable dt = dao.Leer(storedProcedure, al);
            if(dt.Rows.Count != 0)
            {
                Mapper_Carne map = new Mapper_Carne();
                foreach (DataRow dr in dt.Rows)
                {
                    belCarne carne = map.ConsultaCondicional(dr[1].ToString())[0];
                    aux.Add(new belCotizacion(dr.ItemArray, carne));
                }
            }           
            return aux;
        }

        public void Modificacion(belCotizacion pItem)
        {
            string storedProcedure = "S_Cotizacion_Modificar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@can";
            p1.Value = pItem.Cantidad;
            p1.SqlDbType = SqlDbType.Decimal;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@pre";
            p2.Value = pItem.Precio;
            p2.SqlDbType = SqlDbType.Decimal;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@cod";
            p3.Value = pItem.Id;
            p3.SqlDbType = SqlDbType.Int;
            al.Add(p3);
            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@car";
            p4.Value = pItem.Carne.Id;
            p4.SqlDbType = SqlDbType.Int;
            al.Add(p4);
            dao.Escribir(storedProcedure, al);
        }
    }
}

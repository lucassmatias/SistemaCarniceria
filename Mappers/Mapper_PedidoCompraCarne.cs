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
    public class Mapper_PedidoCompraCarne : IABMC<belPedidoCompraCarne>
    {
        DAO dao = new DAO();
        ArrayList al;
        public void Alta(belPedidoCompraCarne pItem)
        {
            al = new ArrayList();
            string storedProcedure = "S_PedidoCompraCarne_Crear";
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = int.Parse(pItem.Id);
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@car";
            p2.Value = pItem.CarneNombre;
            p2.SqlDbType = SqlDbType.NVarChar;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@can";
            p3.Value = pItem.Cantidad;
            p3.SqlDbType = SqlDbType.Decimal;
            al.Add(p3);
            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@pre";
            p4.Value = pItem.PrecioUnitario;
            p4.SqlDbType = SqlDbType.Decimal;
            al.Add(p4);
            dao.Escribir(storedProcedure, al);
        }

        public void Baja(string pId)
        {
            al = new ArrayList();
            string storedProcedure = "S_PedidoCompraCarne_Eliminar";
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }

        public List<belPedidoCompraCarne> Consulta()
        {
            throw new NotImplementedException();
        }

        public List<belPedidoCompraCarne> ConsultaCondicional(string pId)
        {
            al = new ArrayList();
            string storedProcedure = "S_PedidoCompraCarne_ListarId";
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            List<belPedidoCompraCarne> aux = new List<belPedidoCompraCarne>();
            DataTable dt = dao.Leer(storedProcedure, al);
            foreach(DataRow dr in dt.Rows)
            {
                aux.Add(new belPedidoCompraCarne(dr.ItemArray));
            }
            return aux;
        }

        public void Modificacion(belPedidoCompraCarne pItem)
        {
            throw new NotImplementedException();
        }

        public List<belPedidoCompraCarne> ConsultaVerificacion()
        {
            string storedProcedure = "S_PedidoCompraCarne_ConsultaVerificacion";
            List<belPedidoCompraCarne> l = new List<belPedidoCompraCarne>();
            DataTable dt = dao.Leer(storedProcedure);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    l.Add(new belPedidoCompraCarne(dr.ItemArray));
                }
            }
            return l;
        }
    }
}

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
    public class Mapper_PedidoCompra : IABMC<belPedidoCompra>
    {
        ArrayList al;
        DAO dao = new DAO();
        public void Alta(belPedidoCompra pItem)
        {
            al = new ArrayList();
            string storedProcedure = "S_PedidoCompra_Crear";
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@pro";
            p1.Value = pItem.proveedor.Id;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@pre";
            p2.Value = pItem.PrecioTotal;
            p2.SqlDbType = SqlDbType.Decimal;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@fec";
            p3.Value = pItem.Fecha;
            p3.SqlDbType = SqlDbType.DateTime;
            al.Add(p3);
            dao.Escribir(storedProcedure, al);
        }

        public void Baja(string pId)
        {
            al = new ArrayList();
            string storedProcedure = "S_PedidoCompra_Eliminar";
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }

        public List<belPedidoCompra> Consulta()
        {
            string storedProcedure = "S_PedidoCompra_Listar";
            DataTable dt = dao.Leer(storedProcedure);
            List<belPedidoCompra> aux = new List<belPedidoCompra>();
            if(dt.Rows.Count > 0)
            {
                Mapper_Proveedor map = new Mapper_Proveedor();
                foreach (DataRow dr in dt.Rows)
                {
                    belProveedor pro = map.Consulta().Find(x => x.Id == dr.ItemArray[1].ToString());
                    aux.Add(new belPedidoCompra(dr.ItemArray, pro));
                }
            }
            return aux;
        }

        public List<belPedidoCompra> ConsultaCondicional(string pId)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belPedidoCompra pItem)
        {
            throw new NotImplementedException();
        }
        public void Cancelar(string pId)
        {
            al = new ArrayList();
            string storedProcedure = "S_PedidoCompra_Cancelar";
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }
        public void Recibir(string pId)
        {
            al = new ArrayList();
            string storedProcedure = "S_PedidoCompra_Pagar";
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }
    }
}

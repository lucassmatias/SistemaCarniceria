using BEL;
using DAL;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Security.Cryptography;

namespace Mappers
{
    public class Mapper_CarneCarrito : IABMC<belCarneCarrito>
    {
        ArrayList al;
        DAO dao = new DAO();
        public void Alta(belCarneCarrito pItem)
        {
            string storedProcedure = "S_CarneCarrito_Crear";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@codCar";
            p1.Value = pItem.Carrito.Id;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@idPro";
            p2.Value = pItem.Carne.Id;
            p2.SqlDbType = SqlDbType.Int;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@pebru";
            p3.Value = pItem.PesoBruto;
            p3.SqlDbType = SqlDbType.Decimal;
            al.Add(p3);
            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@penet";
            p4.Value = pItem.PesoNeto;
            p4.SqlDbType = SqlDbType.Decimal;
            al.Add(p4);
            SqlParameter p5 = new SqlParameter();
            p5.ParameterName = "@prenet";
            p5.Value = pItem.PrecioNeto;
            p5.SqlDbType = SqlDbType.Decimal;
            al.Add(p5);
            dao.Escribir(storedProcedure, al);
        }

        public void Baja(string pId)
        {
            string storedProcedure = "S_CarneCarrito_Eliminar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@id";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }

        public List<belCarneCarrito> Consulta()
        {
            throw new NotImplementedException();
        }

        public List<belCarneCarrito> ConsultaCondicional(string pId)
        {
            Mapper_Carne map = new Mapper_Carne();
            string storedProcedure = "S_CarneCarrito_Listar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@codCar";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            DataTable dt = dao.Leer(storedProcedure, al);
            List<belCarneCarrito> lCarneCarrito = new List<belCarneCarrito>();
            foreach (DataRow dr in dt.Rows)
            {
                List<belCarne> listCarne = map.ConsultaCondicional(dr.ItemArray[1].ToString());
                belCarneCarrito aux = new belCarneCarrito(dr.ItemArray, listCarne[0]);
                lCarneCarrito.Add(aux);
            }
            return lCarneCarrito;
        }

        public void Modificacion(belCarneCarrito pItem)
        {
            throw new NotImplementedException();
        }
        public void ModificacionCarneCarrito(belCarneCarrito pItem, string pCodigoAnterior)
        {
            string storedProcedure = "S_CarneCarrito_CambiarCodigo";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pItem.Id;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@codAnt";
            p2.Value = pCodigoAnterior;
            p2.SqlDbType = SqlDbType.Int;
            al.Add(p2);
            dao.Escribir(storedProcedure, al);
        }
    }
}

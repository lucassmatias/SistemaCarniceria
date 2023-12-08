using BEL;
using DAL;
using Interfaces;
using Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public class Mapper_Ticket : IABMC<belTicket>
    {
        ArrayList al;
        DAO dao = new DAO();
        Mapper_CarneCarrito map = new Mapper_CarneCarrito();
        public void Alta(belTicket pItem)
        {
            string storedProcedure = "S_Ticket_Crear";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pItem.Id;
            p1.SqlDbType = SqlDbType.NVarChar;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@fec";
            p2.Value = pItem.Fecha;
            p2.SqlDbType = SqlDbType.DateTime;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@tot";
            p3.Value = pItem.Total;
            p3.SqlDbType = SqlDbType.Decimal;
            al.Add(p3);
            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@totPag";
            p4.Value = pItem.CantidadPagada;
            p4.SqlDbType = SqlDbType.Decimal;
            al.Add(p4);
            SqlParameter p5 = new SqlParameter();
            p5.ParameterName = "@totVue";
            p5.Value = pItem.CantidadVuelto;
            p5.SqlDbType = SqlDbType.Decimal;
            al.Add(p5);
            dao.Escribir(storedProcedure, al);
        }

        public void Baja(string pId)
        {
            string storedProcedure = "S_Ticket_Eliminar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.NVarChar;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }

        public List<belTicket> Consulta()
        {
            string storedProcedure = "S_Ticket_Listar";
            DataTable dt = dao.Leer(storedProcedure);
            List<belTicket> lTicket = new List<belTicket>();
            foreach (DataRow dr in dt.Rows)
            {
                belTicket aux = new belTicket(dr.ItemArray);
                List<belCarneCarrito> lCarne = map.ConsultaCondicional(aux.Id);
                foreach(belCarneCarrito c in lCarne)
                {
                    aux.ListaCarne.Add(c);
                }
                lTicket.Add(aux);
            }
            return lTicket;
        }

        public List<belTicket> ConsultaCondicional(string pId)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belTicket pItem)
        {
            throw new NotImplementedException();
        }
        public int ConsultaCodigo()
        {
            string storedProcedure = "S_Ticket_ListarUltimo";
            DataTable dt = dao.Leer(storedProcedure);
            if(dt.Rows.Count != 0)
            {
                return int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            else
            {
                return 10000000;
            }
        }
        public List<belTicket> ConsultaVerificacion()
        {
            string storedProcedure = "S_Ticket_ConsultaVerificacion";
            List<belTicket> l = new List<belTicket>();
            DataTable dt = dao.Leer(storedProcedure);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    l.Add(new belTicket(dr.ItemArray));
                }
            }
            return l;
        }
    }
}

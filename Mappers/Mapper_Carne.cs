using BEL;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Security.Policy;

namespace Mappers
{
    public class Mapper_Carne : IABMC<belCarne>
    {
        ArrayList al;
        DAO dao = new DAO();
        public void Alta(belCarne pItem)
        {
            string storedProcedure = "S_Carne_Crear";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@nom";
            p1.Value = pItem.Nombre;
            p1.SqlDbType = SqlDbType.VarChar;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@pkg";
            p2.Value = pItem.PrecioKG;
            p2.SqlDbType = SqlDbType.Float;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@tipo";
            int x = 0;
            if (pItem is belAve) x = 1;
            else if (pItem is belPorcina) x = 2;
            else if (pItem is belVacuna) x = 3;
            p3.Value = x;
            p3.SqlDbType = SqlDbType.Int;
            al.Add(p3);
            dao.Escribir(storedProcedure, al);
        }

        public void Baja(string pId)
        {
            string storedProcedure = "S_Carne_Eliminar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@id";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }

        public List<belCarne> Consulta()
        {
            string storedProcedure = "S_Carne_Listar";
            DataTable dt = dao.Leer(storedProcedure);
            List<belCarne> lCarne = new List<belCarne>();
            foreach (DataRow dr in dt.Rows)
            {
                if (int.Parse(dr[3].ToString()) == 1)
                {
                    belAve aux = new belAve(dr.ItemArray);
                    lCarne.Add(aux);
                }
                if (int.Parse(dr[3].ToString()) == 2)
                {
                    belPorcina aux = new belPorcina(dr.ItemArray);
                    lCarne.Add(aux);
                }
                if (int.Parse(dr[3].ToString()) == 3)
                {
                    belVacuna aux = new belVacuna(dr.ItemArray);
                    lCarne.Add(aux);
                }
            }
            return lCarne;
        }

        public List<belCarne> ConsultaDesdeHasta(string pStringDesde, string pStringHasta)
        {
            throw new NotImplementedException();
        }

        public List<belCarne> ConsultaIncremental(string pString)
        {
            string storedProcedure = "S_CarneListarUno";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@id";
            p1.Value = pString;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            DataTable dt = dao.Leer(storedProcedure, al);
            List<belCarne> lCarne = new List<belCarne>();
            foreach (DataRow dr in dt.Rows)
            {
                if (int.Parse(dr[3].ToString()) == 1)
                {
                    belAve aux = new belAve(dr.ItemArray);
                    lCarne.Add(aux);
                }
                if (int.Parse(dr[3].ToString()) == 2)
                {
                    belPorcina aux = new belPorcina(dr.ItemArray);
                    lCarne.Add(aux);
                }
                if (int.Parse(dr[3].ToString()) == 3)
                {
                    belVacuna aux = new belVacuna(dr.ItemArray);
                    lCarne.Add(aux);
                }
            }
            return lCarne;
        }

        public void Modificacion(belCarne pItem)
        {
            string storedProcedure = "S_Carne_Modificar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@nom";
            p1.Value = pItem.Nombre;
            p1.SqlDbType = SqlDbType.VarChar;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@pre";
            p2.Value = pItem.PrecioKG;
            p2.SqlDbType = SqlDbType.Float;
            al.Add(p2);
            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@id";
            p3.Value = pItem.Id;
            p3.SqlDbType = SqlDbType.Int;
            al.Add(p3);
            dao.Escribir(storedProcedure, al);
        }
    }
}

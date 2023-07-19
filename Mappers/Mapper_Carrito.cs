﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
using DAL;
using Interfaces;
using System.Data;

namespace Mappers
{
    public class Mapper_Carrito : IABMC<belCarrito>
    {
        ArrayList al;
        DAO dao = new DAO();
        public void Alta(belCarrito pItem)
        {
            string storedProcedure = "S_Carrito_Crear";
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
            p4.ParameterName = "@tot";
            p4.Value = pItem.ImporteBruto;
            p4.SqlDbType = SqlDbType.Float;
            al.Add(p4);
            dao.Escribir(storedProcedure, al);
        }

        public void Baja(string pId)
        {
            string storedProcedure = "S_Carrito_Eliminar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@cod";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            al.Add(p1);
            dao.Escribir(storedProcedure, al);
        }

        public List<belCarrito> Consulta()
        {
            Mapper_CarneCarrito map = new Mapper_CarneCarrito();
            string storedProcedure = "S_Carrito_Listar";
            DataTable dt = dao.Leer(storedProcedure);   
            List<belCarrito> lCarrito = new List<belCarrito>();
            foreach (DataRow dr in dt.Rows)
            {
                belCarrito aux = new belCarrito(dr.ItemArray);
                List<belCarneCarrito> lCarne = map.ConsultaIncremental(aux.Id);
                aux.Productos.AddRange(lCarne);
                lCarrito.Add(aux);
            }
            return lCarrito;
        }

        public List<belCarrito> ConsultaDesdeHasta(string pStringDesde, string pStringHasta)
        {
            throw new NotImplementedException();
        }

        public List<belCarrito> ConsultaIncremental(string pString)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belCarrito pItem)
        {
            throw new NotImplementedException();
        }
    }
}

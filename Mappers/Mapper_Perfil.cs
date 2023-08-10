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
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public class Mapper_Perfil : IABMC<belPerfil>
    {
        DAO dao = new DAO();
        Mapper_Permiso map = new Mapper_Permiso();
        ArrayList al;
        public void Alta(belPerfil pItem)
        {
            string storedProcedure = "S_Perfil_Crear";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@nom";
            p1.Value = pItem.Nombre;
            p1.SqlDbType = SqlDbType.NVarChar;
            al.Add(p1);
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@per";
            p2.Value = pItem.Permiso.Id;
            p2.SqlDbType = SqlDbType.Int;
            al.Add(p2);
            dao.Escribir(storedProcedure, al);
        }

        public void Baja(string pId)
        {
            string storedProcedure = "S_Perfil_Eliminar";
            al = new ArrayList();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@id";
            p1.Value = pId;
            p1.SqlDbType = SqlDbType.Int;
            dao.Escribir(storedProcedure, al);
        }

        public List<belPerfil> Consulta()
        {
            string storedProcedure = "S_Perfil_Listar";
            DataTable dt = dao.Leer(storedProcedure);
            List<belPerfil> lPerfil = new List<belPerfil>();
            List<belPermiso> lPermisos = map.Consulta();
            foreach (DataRow dr in dt.Rows)
            {
                belPerfil aux = new belPerfil(dr.ItemArray);
                belPermiso permiso = (lPermisos[0] as belPermisoCompuesto).BuscarPermisoId(dr[2].ToString(), (lPermisos[0] as belPermisoCompuesto), null);
                aux.Permiso = permiso;
                lPerfil.Add(aux);
            }
            return lPerfil;
        }

        public List<belPerfil> ConsultaCondicional(string pId)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belPerfil pItem)
        {
            throw new NotImplementedException();
        }
    }
}

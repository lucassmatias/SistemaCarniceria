﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace BEL
{
    public class belUsuario : IEntity
    {
        public belUsuario(string pDNI, string pName, string pPassword, string pNombre, string pApellido, string pEmail, string pRol)
        {
            DNI = pDNI;
            Username = pName;
            Password = pPassword;
            Blocked = false;
            Intentos = 3;
            Nombre = pNombre;
            Apellido = pApellido;
            Email = pEmail;
            Rol = pRol;
            Activo = true;
        }
        public belUsuario(object[] array)
        {
            DNI = array[0].ToString();
            Nombre = array[1].ToString();
            Apellido = array[2].ToString();
            Username = array[3].ToString();
            Password = array[4].ToString();
            Rol = array[5].ToString();
            Email = array[6].ToString();
            Blocked = bool.Parse(array[7].ToString());
            Activo = bool.Parse(array[8].ToString());
            Intentos = 3;
            Id = array[9].ToString();
        }
        public string Id { get; set; }
        public string DNI { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Blocked { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
        public int Intentos { get; set; }
    }
}

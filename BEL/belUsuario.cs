using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace BEL
{
    public class belUsuario : IEntity
    {
        public belUsuario(string pName, string pPassword)
        {
            Name = pName;
            Password = pPassword;
            Blocked = false;
            Intentos = 3;
        }
        public belUsuario(object[] array)
        {
            Name = array[0].ToString();
            Password = array[1].ToString();
            Blocked = bool.Parse(array[2].ToString());
            Intentos = 3;
            Id = array[3].ToString();
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Blocked { get; set; }
        public int Intentos { get; set; }
        public string Id { get; set; }
    }
}

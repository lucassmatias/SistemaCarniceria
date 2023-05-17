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
        public belUsuario(string name, string password, bool blocked, int intentos, string id)
        {
            Name = name;
            Password = password;
            Blocked = blocked;
            Intentos = intentos;
            Id = id;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public bool Blocked { get; set; }
        public int Intentos { get; set; }
        public string Id { get; set; }
    }
}

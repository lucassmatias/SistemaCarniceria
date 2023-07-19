using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belIdioma : IEntity
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }
}

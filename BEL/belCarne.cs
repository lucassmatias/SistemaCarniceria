using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BEL
{
    public abstract class belCarne : IEntity
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioKG { get; set; }
    }
}

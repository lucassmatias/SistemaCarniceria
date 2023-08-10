using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belCarrito : IEntity, IDisposable
    {
        public belCarrito(object[] array)
        {
            Id = array[0].ToString();
            DNI = array[1].ToString();
            Nombre = array[2].ToString();
            Apellido = array[3].ToString();
            ImporteBruto = decimal.Parse(array[4].ToString());
            Productos = new List<belCarneCarrito>();
        }
        public belCarrito() { Productos = new List<belCarneCarrito>(); }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<belCarneCarrito> Productos { get;set; }
        public decimal ImporteBruto { get; set; }
        public string Id { get; set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}

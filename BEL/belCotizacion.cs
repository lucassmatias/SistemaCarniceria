using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belCotizacion : IEntity
    {
        public belCotizacion(belProveedor pProveedor, string pCarne, decimal pCantidad, decimal pPrecio)
        {
            Id = pProveedor.Id;
            Carne = pCarne;
            Cantidad = pCantidad;
            Precio = pPrecio;
        }
        public belCotizacion(object[] array)
        {
            Id = array[0].ToString();
            Carne = array[1].ToString();
            Cantidad = decimal.Parse(array[2].ToString());
            Precio = decimal.Parse(array[3].ToString());
        }
        public string Id { get; set; }
        public string Carne { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}

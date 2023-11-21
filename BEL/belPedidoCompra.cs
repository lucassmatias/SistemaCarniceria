using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belPedidoCompra : IEntity
    {
        public string Id { get; set; }
        public belProveedor proveedor { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public bool Recibido { get;set; }
        public bool Cancelado { get; set; }
        public belPedidoCompra(belProveedor proveedor, decimal precioTotal, DateTime fecha, bool recibido, bool cancelado)
        {
            this.proveedor = proveedor;
            PrecioTotal = precioTotal;
            Fecha = fecha;
            Recibido = recibido;
            Cancelado = cancelado;
        }
        public belPedidoCompra(object[] array, belProveedor pProveedor)
        {
            Id = array[0].ToString();
            proveedor = pProveedor;
            PrecioTotal = decimal.Parse(array[2].ToString());
            Fecha = DateTime.Parse(array[3].ToString());
            Recibido = bool.Parse(array[4].ToString());
            Cancelado = bool.Parse(array[5].ToString());
        }
    }
}

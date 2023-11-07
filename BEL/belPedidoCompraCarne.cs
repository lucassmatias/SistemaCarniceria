using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belPedidoCompraCarne : IEntity
    {
        public string Id { get; set; }
        public string CarneNombre { get;set; }
        public decimal Cantidad { get;set; }
        public decimal PrecioUnitario { get;set; }
        public belPedidoCompraCarne(string pCarneNombre, decimal pCantidad, decimal pPrecioUnitario)
        {
            CarneNombre = pCarneNombre;
            Cantidad = pCantidad;
            PrecioUnitario = pPrecioUnitario;
        }
        public belPedidoCompraCarne(object[] array)
        {
            Id = array[0].ToString();
            CarneNombre = array[1].ToString();
            Cantidad = decimal.Parse(array[2].ToString());
            PrecioUnitario = decimal.Parse(array[3].ToString());
        }
    }
}

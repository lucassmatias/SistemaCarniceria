using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belTicket : IEntity
    {
        public belTicket(DateTime pFecha, decimal pTotal, decimal pCantidadPagada) 
        {
            Fecha = pFecha;
            Total = pTotal;
            CantidadPagada = pCantidadPagada;
            CantidadVuelto = pCantidadPagada > pTotal ? pCantidadPagada - pTotal : 0;
            ListaCarne = new List<belCarneCarrito>();
        }
        public belTicket(object[] array)
        {
            Id = array[0].ToString();
            Fecha = DateTime.Parse(array[1].ToString());
            Total = decimal.Parse(array[2].ToString());
            CantidadPagada = decimal.Parse(array[3].ToString());
            CantidadVuelto = decimal.Parse(array[4].ToString());
        }
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public decimal CantidadPagada { get; set; }
        public decimal CantidadVuelto { get; set; }
        public List<belCarneCarrito> ListaCarne { get; set; }
    }
}

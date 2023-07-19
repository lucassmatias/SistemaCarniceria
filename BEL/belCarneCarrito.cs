using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belCarneCarrito : IEntity
    {
        public belCarneCarrito(object[] array, belCarne pCarne)
        {
            Carne = pCarne;
            PesoBruto = decimal.Parse(array[2].ToString());
            PesoNeto = decimal.Parse(array[3].ToString());
            PrecioNeto = decimal.Parse(array[4].ToString());
        }
        public belCarneCarrito(belCarne pCarne, decimal pPesoBruto, decimal pPesoNeto, belCarrito pCarrito)
        {
            Carne = pCarne;
            PesoBruto = pPesoBruto;
            PesoNeto = pPesoNeto;
            PrecioNeto = CalcularPrecioNeto(pPesoNeto);
            Carrito = pCarrito;
        }
        public belCarne Carne { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoNeto { get; set; }
        public decimal PrecioNeto { get; }
        public string Id { get; set; }
        public belCarrito Carrito { get; set;}

        private decimal CalcularPrecioNeto(decimal pPesoNeto) 
        {
            return pPesoNeto * Carne.PrecioKG;
        }
    }
}

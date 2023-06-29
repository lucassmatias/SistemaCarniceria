using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belCarneCarrito
    {
        public belCarneCarrito(belCarne pCarne, decimal pPesoBruto, decimal pPesoNeto) 
        {
            Carne = pCarne;
            PesoBruto = pPesoBruto;
            PesoNeto = pPesoNeto;
            PrecioNeto = CalcularPrecioNeto(pPesoNeto);
        }
        public belCarne Carne { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoNeto { get; set; }
        public decimal PrecioNeto { get; }
        private decimal CalcularPrecioNeto(decimal pPesoNeto) 
        {
            return pPesoNeto * Carne.PrecioKG;
        }
    }
}

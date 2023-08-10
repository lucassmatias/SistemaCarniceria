using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BEL
{
    public abstract class belCarne : IEntity, IComparable<belCarne>
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioKG { get; set; }
        public decimal StockKG { get; set; }
        public int CompareTo(belCarne pCarne)
        {
            if(pCarne == null) return 1;
            else return this.Nombre.CompareTo(pCarne.Nombre);
        }

        public int OrdenPorNombre(belCarne pCarne1, belCarne pCarne2)
        {
            return (pCarne1.Nombre).CompareTo(pCarne2.Nombre);
        }
        public void QuitarStock(decimal pStock)
        {
            this.StockKG -= pStock;
        }
        public void ReponerStock(decimal pStock)
        {
            this.StockKG += pStock;
        }
    }
}

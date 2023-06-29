using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
namespace BLL
{
    public static class bllCarrito
    {
        public static void AgregarProducto(belCarrito carrito, belCarne producto, decimal pPesoBruto, decimal pPesoNeto)
        {
            belCarneCarrito aux = new belCarneCarrito(producto, pPesoBruto, pPesoNeto);
            carrito.Productos.Add(aux);
        }
        public static void QuitarProducto(belCarrito carrito, string productoId)
        {
            carrito.Productos.Remove(carrito.Productos.Find(x => x.Carne.Id == productoId));
        }
    }
}

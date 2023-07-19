using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
using Interfaces;
using Mappers;
namespace BLL
{
    public class bllCarrito : IABMC<belCarrito>
    {
        Mapper_Carrito map = new Mapper_Carrito();
        public void AgregarProducto(belCarrito carrito, belCarne producto, decimal pPesoBruto, decimal pPesoNeto)
        {
            belCarneCarrito aux = new belCarneCarrito(producto, pPesoBruto, pPesoNeto, carrito);
            carrito.Productos.Add(aux);
        }
        public void QuitarProducto(belCarrito carrito, string productoId)
        {
            carrito.Productos.Remove(carrito.Productos.Find(x => x.Carne.Id == productoId));
        }

        public void Alta(belCarrito pItem)
        {
            map.Alta(pItem);
        }

        public void Baja(string pId)
        {
            map.Baja(pId);
        }

        public List<belCarrito> Consulta()
        {
            return map.Consulta();
        }

        public List<belCarrito> ConsultaDesdeHasta(string pStringDesde, string pStringHasta)
        {
            throw new NotImplementedException();
        }

        public List<belCarrito> ConsultaIncremental(string pString)
        {
            throw new NotImplementedException();
        }

        public void Modificacion(belCarrito pItem)
        {
            throw new NotImplementedException();
        }
    }
}

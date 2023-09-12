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
        public void AgregarDatos(belCarrito carrito, string pDNI, string pNombre, string pApellido)
        {
            carrito.DNI = pDNI;
            carrito.Nombre = pNombre;
            carrito.Apellido = pApellido;
        }
        public void AgregarImporte(belCarrito carrito)
        {
            decimal importe = 0;
            foreach(belCarneCarrito x in carrito.Productos)
            {
                importe += x.Carne.PrecioKG * x.PesoBruto;
            }
            carrito.ImporteBruto = importe;
        }
        public void AgregarID(belCarrito carrito)
        {
            List<belCarrito> aux = map.Consulta();
            if(aux.Count != 0)
            {
                string LastId = aux[aux.Count - 1].Id;
                int LastIDPlus = int.Parse(LastId) + 1;
                carrito.Id = LastIDPlus.ToString();
            }
            else
            {
                carrito.Id = "1";
            }
        }
        public void ClearProductos(belCarrito carrito)
        {
            carrito.DNI = "";
            carrito.Nombre = "";
            carrito.Apellido = "";
            carrito.Productos.Clear();
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

        public void Modificacion(belCarrito pItem)
        {
            throw new NotImplementedException();
        }

        public List<belCarrito> ConsultaCondicional(string pId)
        {
            throw new NotImplementedException();
        }
    }
}

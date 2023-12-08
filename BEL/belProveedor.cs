using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belProveedor : IEntity
    {
        public belProveedor(){}
        public belProveedor(object[] array, List<belCotizacion> pLista)
        {
            Id = array[0].ToString();
            Nombre = array[1].ToString();
            Localidad = array[2].ToString();
            Direccion = array[3].ToString();
            Telefono = array[4].ToString();
            Mail = array[5].ToString(); 
            CostoEnvio = decimal.Parse(array[6].ToString());
            ListaCotización = pLista;
        }
        public belProveedor(object[] array)
        {
            Id = array[0].ToString();
            Nombre = array[1].ToString();
            Localidad = array[2].ToString();
            Direccion = array[3].ToString();
            Telefono = array[4].ToString();
            Mail = array[5].ToString();
            CostoEnvio = decimal.Parse(array[6].ToString());
            ListaCotización = null;
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Localidad { get;set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public decimal CostoEnvio { get; set; }
        public List<belCotizacion> ListaCotización { get; set; }
    }
}

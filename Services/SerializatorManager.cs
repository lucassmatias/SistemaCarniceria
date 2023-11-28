using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using BEL;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Services
{
    public static class SerializatorManager
    {
        public static void Serializar(object pObject)
        {
            string jsonString = JsonConvert.SerializeObject(pObject);
            StreamWriter sw = new StreamWriter("Serializacion.json");
            sw.WriteLine(jsonString);
            sw.Close();
        }
        public static List<belPedidoCompraCarne> DeserializarPedidoCompraCarne()
        {
            string text = File.ReadAllText("Serializacion.json");
            belPedidoCompraCarne aux = (belPedidoCompraCarne)JsonConvert.DeserializeObject(text,typeof(belPedidoCompraCarne));
            List<belPedidoCompraCarne> l = new List<belPedidoCompraCarne>();
            l.Add(aux);
            return l;
        }
        public static void LimpiarSerial()
        {
            StreamWriter sw = new StreamWriter("Serializacion.txt");
            sw.Write(string.Empty);
            sw.Close();
        }
    }
}

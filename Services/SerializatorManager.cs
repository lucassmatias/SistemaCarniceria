using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using BEL;

namespace Services
{
    public static class SerializatorManager
    {
        public static void Serializar(object pObject)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string jsonString = JsonSerializer.Serialize(pObject, options);
            StreamWriter sw = new StreamWriter("Serializacion.txt");
            sw.WriteLine(jsonString);
            sw.Close();
        }
        public static belPedidoCompra DeserializarPedidoCompra()
        {
            StreamReader sr = new StreamReader("Serializacion.txt");
            string text = sr.ReadToEnd();
            belPedidoCompra aux = JsonSerializer.Deserialize<belPedidoCompra>(text);
            return aux;
        }
    }
}

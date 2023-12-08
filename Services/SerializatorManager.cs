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
using System.Collections;

namespace Services
{
    public static class SerializatorManager
    {
        public static void Serializar(List<belPedidoCompraCarne> pObject)
        {
            LimpiarSerial();
            string jsonString = JsonConvert.SerializeObject(pObject);
            StreamWriter sw = new StreamWriter("Serializacion.json");
            sw.WriteLine(jsonString);
            sw.Close();
        }
        public static List<belPedidoCompraCarne> DeserializarPedidoCompraCarne()
        {
            List<belPedidoCompraCarne> l = JsonConvert.DeserializeObject<List<belPedidoCompraCarne>>(File.ReadAllText("Serializacion.json"));
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LogManager
    {
        private static string Path = @"C:\Users\lukit\OneDrive\Escritorio\Recursos UAI\3er Año - 1er Cuatrimestre\Ingeniería de software\Código\LogSistema.txt";
        public static void Add(string sLog)
        {
            CreateDirectory();
            string cadena;
            using (StreamReader sr = new StreamReader(Path))
            {
                cadena = sr.ReadToEnd();
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.Write(cadena + DateTime.Now + " - " + sLog + Environment.NewLine);
                sw.Close();
            }
        }
        private static void CreateDirectory()
        {
            try
            {
                if (Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

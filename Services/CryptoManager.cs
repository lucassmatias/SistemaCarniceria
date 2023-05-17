using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CryptoManager
    {
        public static string Encrypt(string pString)
        {
            UnicodeEncoding uCode = new UnicodeEncoding();
            byte[] byteSourceText = uCode.GetBytes(pString);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(byteSourceText);
            return Convert.ToBase64String(result);
        }
        public static int Compare(string pString, string pStringEncrypted)
        {      
            if (Encrypt(pString) == pStringEncrypted) { return 1; }
            else { return 0; }
        }
    }
}

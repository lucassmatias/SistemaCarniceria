using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
namespace Services
{
    public class SessionManager
    {
        private static SessionManager instance;
        public belUsuario user { get; set; }
        public DateTime initialDate { get; set; }
        private static object _lock = new Object();
        private SessionManager() { }
        public static SessionManager GetInstance
        {
            get
            {
                if (instance == null) throw new Exception("Sesión no iniciada");
                return instance;
            }
        }
        public static void Login(belUsuario pUser)
        {
            lock (_lock)
            {
                if(instance == null)
                {
                    instance = new SessionManager();
                    instance.user = pUser;
                    instance.initialDate = DateTime.Now;
                }
                else
                {
                    throw new Exception("Sesión ya está iniciada");
                }
            }
        }
        public static void Logout()
        {
            lock (_lock)
            {
                if(instance != null)
                {
                    instance = null;
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }
            }
        }
    }
}

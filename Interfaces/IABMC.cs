using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IABMC<T> where T: IEntity
    {
        void Alta(T pItem);
        void Baja(string pId);
        void Modificacion(T pItem);
        List<T> Consulta();
        List<T> ConsultaIncremental(string pString);
        List<T> ConsultaDesdeHasta(string pStringDesde, string pStringHasta);
    }
}

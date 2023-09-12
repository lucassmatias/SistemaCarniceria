﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class belVacuna : belCarne
    {
        public belVacuna(object[] array)
        {
            Id = array[0].ToString();
            Nombre = array[1].ToString();
            PrecioKG = decimal.Parse(array[2].ToString());
            StockKG = decimal.Parse(array[4].ToString());
        }
        public belVacuna(string pNombre, decimal pPrecio, decimal pStock)
        {
            Nombre = pNombre;
            PrecioKG = pPrecio;
            StockKG = pStock;
        }
    }
}

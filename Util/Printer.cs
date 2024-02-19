using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tamaño = 10)
        {
            Console.WriteLine("".PadLeft(tamaño, '='));
        }
    }
}

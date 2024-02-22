using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Interfaces
{
    public interface ILugar
    {
        string Dirección { get; set; }

        void LimpiarLugar();
    }
}

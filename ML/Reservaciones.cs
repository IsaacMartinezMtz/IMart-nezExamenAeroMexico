using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Reservaciones
    {
        public int IdReservaciones { get; set; }
        public ML.Usuario Usuario { get; set; } 
        public ML.Vuelos Vuelos { get; set; }

        public List<object> Usuarios { get; set; }

    }
}

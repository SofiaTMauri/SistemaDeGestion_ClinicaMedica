using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Medicos_X_Dias
    {
        private string Legajo;
        private DayOfWeek Dia;
        private DateTime hora;
        
        public Medicos_X_Dias() { }

        public string Legajo1 { get => Legajo; set => Legajo = value; }
        public DayOfWeek Dia1 { get => Dia; set => Dia = value; }
        public DateTime Hora { get => hora; set => hora = value; }
    }
}

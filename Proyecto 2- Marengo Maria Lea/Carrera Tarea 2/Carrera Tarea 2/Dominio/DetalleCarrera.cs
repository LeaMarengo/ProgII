using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera_Tarea_2.Dominio
{
    public class DetalleCarrera
    {
        public DateTime AñoCursado { get; set; }
        public int Cuatrimestre { get; set; }
        public Asignatura Asignatura { get; set; }


        public DetalleCarrera(DateTime añoCursado, int cuatrimestre, Asignatura asignatura)
        {
            this.Asignatura = asignatura;
            this.AñoCursado = añoCursado;
            this.Cuatrimestre = cuatrimestre;

        }
    }
}

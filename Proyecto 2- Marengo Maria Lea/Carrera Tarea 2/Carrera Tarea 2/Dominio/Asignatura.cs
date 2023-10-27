using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera_Tarea_2.Dominio
{
    public class Asignatura
    {
        public int IdAsignatura { get; set; }
        public string NomAsignatura { get; set; }

        public Asignatura()
        {
            IdAsignatura = 0;
            NomAsignatura = string.Empty;
        }
        public Asignatura(int idAsignatura, string nomAsignatura)
        {
            IdAsignatura = idAsignatura;
            NomAsignatura = nomAsignatura;
        }
        public override string ToString()
        {
            return NomAsignatura;
        }
    }
}

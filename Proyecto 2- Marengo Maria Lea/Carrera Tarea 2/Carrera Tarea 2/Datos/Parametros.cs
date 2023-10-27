using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera_Tarea_2.Datos
{
    public class Parametros
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }

        public Parametros(string nombre, Object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}

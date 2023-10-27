using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera_Tarea_2.Dominio
{
    public class Carrera
    {
        public int IdCarrera { get; set; }
        public string NomCarrera { get; set; }
        public List<DetalleCarrera> ListaDetalle { get; set; }
        public Carrera(int idCarrera, string nomCarrera, List<DetalleCarrera> ListaDettale)
        {
            IdCarrera = idCarrera;
            NomCarrera = nomCarrera;
            ListaDetalle = new List<DetalleCarrera>();
        }

        public Carrera()
        {
            IdCarrera = 0;
            NomCarrera = string.Empty;
            ListaDetalle = new List<DetalleCarrera>();
        }


        public void AgregarDetalle(DetalleCarrera detalleCarrera)
        {
            ListaDetalle.Add(detalleCarrera);
        }
        public void QuitarDetalle(int indice)
        {
            ListaDetalle.RemoveAt(indice);
        }
    }
}

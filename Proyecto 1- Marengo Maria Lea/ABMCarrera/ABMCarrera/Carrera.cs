using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMCarrera
{
    public class Carrera
    {
        public int IdCarrera { get; set; }
        public string NomCarrera { get; set; }
        public List<DetalleCarrera> ListaDetalle { get; set; }
        public Carrera(int idCarrera, string nomCarrera)
        {
            IdCarrera= idCarrera;
            NomCarrera= nomCarrera;
            ListaDetalle= new List<DetalleCarrera>();
        }

        public Carrera()
        {
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

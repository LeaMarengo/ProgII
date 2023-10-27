using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Entidades
{
    public class OrdenRetiro
    {
        public int NroOrden { get; set; }
        public DateTime Fecha { get; set; }
        public string Responsable { get; set; }
        public List<DetalleOrden> lDetalle { get; set; }

        public OrdenRetiro()
        {
            lDetalle= new List<DetalleOrden>();
        }
        public void AgregarDetalle(DetalleOrden detalle) 
        {
            lDetalle.Add(detalle);
        }
        public void QuitarDetalle(int posicion)
        {
            lDetalle.RemoveAt(posicion);
        }
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Entidades
{
    public class DetalleOrden
    {
       
        public int Cantidad { get; set; }
        public Material Material { get; set; }

        public DetalleOrden(int cantidad,Material material) 
        {
           
            Cantidad=cantidad;
            Material=material;
        }
    }
}

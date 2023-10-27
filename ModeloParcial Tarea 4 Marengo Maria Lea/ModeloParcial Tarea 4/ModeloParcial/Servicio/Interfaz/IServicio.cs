using ModeloParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Servicio.Interfaz
{
    public interface IServicio
    {
        List<Material> TraerMaterial();
        bool CrearOrdenRetiro(OrdenRetiro oOrdenRetiro);
        bool ActualizarOrden(OrdenRetiro ordenRetiro);
        bool BorrarOrden(int nroOrden);
    }
}

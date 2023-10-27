using ModeloParcial.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Servicio
{
    public class IFabricaServicio : FabricaServicio
    {
        public override IServicio CrearServicio()
        {
            return new Servicio.Implementacion.Servicio();
        }
    }
}

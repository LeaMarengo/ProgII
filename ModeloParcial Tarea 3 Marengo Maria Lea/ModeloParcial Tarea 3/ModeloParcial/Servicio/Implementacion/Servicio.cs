using ModeloParcial.Datos.Implementacion;
using ModeloParcial.Datos.Interfaz;
using ModeloParcial.Entidades;
using ModeloParcial.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Servicio.Implementacion
{
    public class Servicio : IServicio
    {
        private IOrdenRetiroDao dao;
        public Servicio() 
        {
            dao = new OrdenRetiroDao();
        }
        public bool CrearOrdenRetiro(OrdenRetiro oOrdenRetiro)
        {
            return dao.Crear(oOrdenRetiro);
        }

        public List<Material> TraerMaterial()
        {
            return dao.ObtenerMaterial();
        }
    }
}

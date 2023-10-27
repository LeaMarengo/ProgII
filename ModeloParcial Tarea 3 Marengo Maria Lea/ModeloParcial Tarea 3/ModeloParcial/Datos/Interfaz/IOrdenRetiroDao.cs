using ModeloParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Datos.Interfaz
{
    public interface IOrdenRetiroDao
    {
        List<Material> ObtenerMaterial();
        bool Crear(OrdenRetiro ordenRetiro);
        bool Actualizar(OrdenRetiro ordenRetiro);
        bool Borrar(int numero);
    }
}

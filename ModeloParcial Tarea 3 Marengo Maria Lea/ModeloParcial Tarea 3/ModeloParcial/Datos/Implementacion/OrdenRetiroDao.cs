using ModeloParcial.Datos.Interfaz;
using ModeloParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Datos.Implementacion
{
    public class OrdenRetiroDao : IOrdenRetiroDao
    {
        public bool Actualizar(OrdenRetiro ordenRetiro)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(int numero)
        {
            throw new NotImplementedException();
        }

        public bool Crear(OrdenRetiro ordenRetiro)
        {
            bool resultado = true;
            SqlConnection conexion = new HelperDao().ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_ORDEN";
                comando.Parameters.AddWithValue("@fecha_orden", ordenRetiro.Fecha);
                comando.Parameters.AddWithValue("@responsable", ordenRetiro.Responsable);
                

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@prox_orden";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                int nro =(int)parametro.Value;
                int detalleNro = 1;
                SqlCommand cmdDetalle;
                foreach (DetalleOrden dp in ordenRetiro.lDetalle)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion,t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_orden", nro);
                    cmdDetalle.Parameters.AddWithValue("@id_detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@material", dp.Material.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dp.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    detalleNro++;
                }
                t.Commit();


            }
            catch 
            {
                if (t !=null)
                {
                    t.Rollback();
                    resultado= false;
                }
                
            }
            finally 
            {
                if (conexion !=null &&conexion.State==ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resultado;
        }

        public List<Material> ObtenerMaterial()
        {
            List<Material> lMaterial = new List<Material>();
            DataTable tabla = new HelperDao().ObtenerInstancia().Consultar("SP_CONSULTAR_MATERIALES");
            foreach (DataRow fila in tabla.Rows)
            {
                int codigo = int.Parse(fila["id_material"].ToString());
                string nombre = fila["nom_material"].ToString();
                double stock = double.Parse(fila["stock_material"].ToString());
                Material m = new Material(codigo, nombre, stock);
                lMaterial.Add(m);
            }
            return lMaterial;
        }
    }
}

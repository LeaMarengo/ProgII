using ModeloParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Datos
{
    public class HelperDao
    {
        private  HelperDao instancia;
        private SqlConnection conexion;

        public HelperDao() 
        {
            conexion= new SqlConnection(Properties.Resources.CadenaConexion);
        }

        public  HelperDao ObtenerInstancia()
        {
            if (instancia==null)
            {
                instancia=new HelperDao();
            }
            return instancia;
        }
        public SqlConnection ObtenerConexion() 
        {
            return this.conexion;
        }
        public DataTable Consultar(string nombreSP)
        {
            conexion.Open();
            SqlCommand comando=new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText= nombreSP;
            DataTable tabla =new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }
        public DataTable ConsultaSQL(string spNombre, List<Parametro> values)
        {
            DataTable tabla = new DataTable();

            conexion.Open();
            SqlCommand cmd = new SqlCommand(spNombre, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
            {
                foreach (Parametro oParametro in values)
                {
                    cmd.Parameters.AddWithValue(oParametro.Nombre, oParametro.Valor);
                }
            }
            tabla.Load(cmd.ExecuteReader());
            conexion.Close();

            return tabla;
        }
        public int EjecutarSQL(string strSql, List<Parametro> values)
        {
            int afectadas = 0;
            SqlTransaction t = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                conexion.Open();
                t = conexion.BeginTransaction();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSql;
                cmd.Transaction = t;

                if (values != null)
                {
                    foreach (Parametro param in values)
                    {
                        cmd.Parameters.AddWithValue(param.Nombre, param.Valor);
                    }
                }

                afectadas = cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null) { t.Rollback(); }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();

            }

            return afectadas;
        }
        public bool ModificarOrden(OrdenRetiro oOrdenRetiro)
        {
            bool resultado = true;
            SqlTransaction t = null;
            SqlConnection conexion = new HelperDao().ObtenerInstancia().ObtenerConexion();

            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ACTUALIZAR_ORDEN";
                //comando.Parameters.AddWithValue("@id_orden", oOrdenRetiro.NroOrden);
                comando.Parameters.AddWithValue("@fecha_orden", oOrdenRetiro.Fecha);
                comando.Parameters.AddWithValue("@responsable", oOrdenRetiro.Responsable);
                comando.ExecuteNonQuery();

                //int detalleNro = 1;
                
                SqlCommand cmdDetalle;
                foreach (DetalleOrden dor in oOrdenRetiro.lDetalle)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_orden", oOrdenRetiro.NroOrden);
                   // cmdDetalle.Parameters.AddWithValue("@id_detalle",detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@material", dor.Material.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dor.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    //detalleNro++;
                }
                t.Commit();
            }
            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }

            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return resultado;
        }

    }
}

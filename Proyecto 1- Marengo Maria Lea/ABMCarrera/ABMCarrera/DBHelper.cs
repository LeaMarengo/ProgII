using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ABMCarrera
{
    internal class DBHelper
    {
        private SqlConnection conexion;
        private string cadenaConexion = @"Data Source=DESKTOP-KQDVDBG\MYSQLSERVER19;Initial Catalog=Carrera1;Integrated Security=True";

        public DBHelper() 
        {
            conexion = new SqlConnection(cadenaConexion);
        }
        public int ProximaCarrera()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "Sp_ProximaCarrera";
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "@next";
            parametro.SqlDbType = SqlDbType.Int;
            parametro.Direction = ParameterDirection.Output;
            comando.Parameters.Add(parametro);
            comando.ExecuteNonQuery();
            conexion.Close();

            return (int)parametro.Value;
        }

        internal bool ConfirmarCarrera(Carrera carrera)
        {
            bool resultado = true;
            SqlTransaction t = null;

            try
            { 
                conexion.Open(); 
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_MAESTRO";

                comando.Parameters.AddWithValue("@nom_carrera", carrera.NomCarrera);

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@id_Carrera";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;

                comando.Parameters.Add(parametro);
                comando.ExecuteNonQuery();

                int idCarrera = (int)parametro.Value;

                SqlCommand cmdDetalle;
                foreach (DetalleCarrera dc in carrera.ListaDetalle)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@id_Carrera", idCarrera);
                    cmdDetalle.Parameters.AddWithValue("@anioCursado", dc.AñoCursado);
                    cmdDetalle.Parameters.AddWithValue("@Cuatrimestre", dc.Cuatrimestre);
                    cmdDetalle.Parameters.AddWithValue("@id_asignatura", dc.Asignatura.IdAsignatura);

                    cmdDetalle.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch
            {
                t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion!=null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return resultado;
        }
        

    }
}

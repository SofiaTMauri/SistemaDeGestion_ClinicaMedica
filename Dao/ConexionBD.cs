using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Dao
{
    public class ConexionBD
    {
        private readonly string rutaBD = "Data Source=localhost\\sqlexpress;Initial Catalog=TPINT_GRUPO_14_PR3;Integrated Security=True";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaBD);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private SqlDataAdapter ObtenerAdaptador(string consulta)
        {
            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, ObtenerConexion());
                return adaptador;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener adaptador: {ex.Message}");
                return null;
            }
        }



        public bool existe(string consulta)
        {
            bool estado = false;
            SqlConnection conexion = ObtenerConexion();
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                SqlDataReader datos = cmd.ExecuteReader();
                estado = datos.Read();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar existencia: {ex.Message}");
            }
            finally
            {
                conexion.Close();
            }
            return estado;
        }

        public int EjecutarConsulta(string consulta)
        {
            int filasAfectadas = 0;
            SqlConnection conexion = ObtenerConexion();
            try
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar consulta: {ex.Message}");
            }
            finally
            {
                conexion.Close();
            }
            return filasAfectadas;
        }

        public DataTable ObtenerTabla(string nombre, string consulta)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conexion = ObtenerConexion();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                adaptador.Fill(ds, nombre);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener tabla: {ex.Message}");
            }
            return ds.Tables[nombre];
        }

        public int ObtenerMaximo(string consulta)
        {
            int maximo = 0;
            SqlConnection conexion = ObtenerConexion();
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                SqlDataReader datos = cmd.ExecuteReader();
                if (datos.Read())
                {
                    maximo = Convert.ToInt32(datos[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener máximo: {ex.Message}");
            }
            finally
            {
                conexion.Close();
            }
            return maximo;
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand comando, string nombreSP)
        {
            int filasAfectadas = 0;
            SqlConnection conexion = null;
            try
            {
                conexion = ObtenerConexion();
                if (conexion == null)
                {
                    throw new Exception("No se pudo obtener la conexión.");
                }

                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSP;
                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar procedimiento almacenado: {ex.Message}");
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return filasAfectadas;
        }
    }
    }


using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Entidades;

namespace Dao
{
    public class DaoMedicos
    {
        private string ConsultaSQLTablaMedicos = "SELECT Legajo_MED, Dni_MED, Nombre_MED, Apellido_MED, Sexo.Nombre_S AS Sexo,Id_Sexo_MED,Fecha_Nacimiento_MED,Direccion_MED, Nacionalidad.Nombre_NAC AS Nacionalidad,Id_Nacionalidad_MED,Localidades.Nombre_LO AS Localidad,Cod_Localidad_MED,Provincias.Nombre_PROV AS Provincia,Cod_Provincia_MED,Correo_Electronico_MED, Telefono_MED, Especialidades.Nombre_ES AS Especialidad,Id_Especialidad_MED FROM Medicos INNER JOIN Sexo ON Medicos.Id_Sexo_MED = Sexo.Id_Sexo_S INNER JOIN Nacionalidad ON Medicos.Id_Nacionalidad_MED = Nacionalidad.Id_Nacionalidad_NAC INNER JOIN Provincias ON Medicos.Cod_Provincia_MED = Provincias.Id_Provincia_PROV INNER JOIN Localidades ON Medicos.Cod_Localidad_MED = Localidades.Id_Localidades_LO INNER JOIN Especialidades ON Medicos.Id_Especialidad_MED = Especialidades.Id_Especialidad_ES WHERE Medicos.Estado_MED = 1";
        ConexionBD cn = new ConexionBD();

        public bool ActualizarMedico(Medicos med)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMed(ref comando, med);
            int filasInsertadas = cn.EjecutarProcedimientoAlmacenado(comando, "spActualizarMedico");
            if (filasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public DataTable TablaMedicos()
        {
            ConexionBD cn = new ConexionBD();
            SqlConnection conexion = cn.ObtenerConexion();
            SqlDataAdapter adaptador = new SqlDataAdapter(ConsultaSQLTablaMedicos, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            return dt;
        }

        private void ArmarParametrosMed(ref SqlCommand comando, Medicos m)
        {
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@Legajo_MED", m.getLegajo_MED());
            //comando.Parameters.AddWithValue("@Dni_MED", m.getDni_MED());
            comando.Parameters.AddWithValue("@Nombre_MED", m.getNombre_MED());
            comando.Parameters.AddWithValue("@Apellido_MED", m.getApellido_MED());
            comando.Parameters.AddWithValue("@Id_Sexo_MED", m.getId_Sexo_MED());
            comando.Parameters.AddWithValue("@Id_Nacionalidad_MED", m.getId_Nacionalidad_MED());
            //comando.Parameters.AddWithValue("@Fecha_Nacimiento_MED", m.getFecha_Nacimiento_MED());
            comando.Parameters.AddWithValue("@Direccion_MED", m.getDireccion_MED());
            comando.Parameters.AddWithValue("@Cod_Localidad_MED", m.getCod_Localidad_MED());
            comando.Parameters.AddWithValue("@Cod_Provincia_MED", m.getCod_Provincia_MED());
            comando.Parameters.AddWithValue("@Correo_Electronico_MED", m.getCorreo_Electronico_MED());
            comando.Parameters.AddWithValue("@Telefono_MED", m.getTelefono_MED());
            comando.Parameters.AddWithValue("@Id_Especialidad_MED", m.getId_Especialidad_MED());
            //comando.Parameters.AddWithValue("@Estado_MED", m.getEstado_MED());
        }

        public DataTable BuscarMedico(string IDDNI)
        {
            ConexionBD cn = new ConexionBD();
            SqlConnection conexion = null;

            try
            {
                conexion = cn.ObtenerConexion();
                string consultaSQL = ConsultaSQLTablaMedicos + " ana Dni_MED = @Dni_MED";
                SqlCommand cmd = new SqlCommand(consultaSQL, conexion);
                cmd.Parameters.AddWithValue("@Dni_MED", IDDNI);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                return dt;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


        public DataTable BuscarMedxSexo(string sexoseleccionado)
        {
            ConexionBD cn = new ConexionBD();
            SqlConnection conexion = null;

            try
            {
                conexion = cn.ObtenerConexion();
                string consultaSQL = ConsultaSQLTablaMedicos + " and Id_Sexo_MED = @Id_Sexo_MED";
                SqlCommand cmd = new SqlCommand(consultaSQL, conexion);
                cmd.Parameters.AddWithValue("@Id_Sexo_MED", sexoseleccionado);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                return dt;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


        public DataTable BuscarMedxProvincia(string provinciaseleccionada)
        {
            ConexionBD cn = new ConexionBD();
            SqlConnection conexion = null;

            try
            {
                conexion = cn.ObtenerConexion();
                string consultaSQL = ConsultaSQLTablaMedicos + " and Cod_Provincia_MED = @Cod_Provincia_MED";
                SqlCommand cmd = new SqlCommand(consultaSQL, conexion);
                cmd.Parameters.AddWithValue("@Cod_Provincia_MED", provinciaseleccionada);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                return dt;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public DataTable BuscarMedxEspecialidad(string EspecialidadSeleccionada)
        {
            ConexionBD cn = new ConexionBD();
            SqlConnection conexion = null;

            try
            {
                conexion = cn.ObtenerConexion();
                string consultaSQL = ConsultaSQLTablaMedicos + " and Id_Especialidad_MED = @Id_Especialidad_MED";
                SqlCommand cmd = new SqlCommand(consultaSQL, conexion);
                cmd.Parameters.AddWithValue("@Id_Especialidad_MED", EspecialidadSeleccionada);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                return dt;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public int agregarMedico(Medicos med)
        {
            ConexionBD cn = new ConexionBD();
            SqlConnection conexion = null;

            try
            {
                conexion = cn.ObtenerConexion();
                SqlCommand comando = new SqlCommand();
                ArmarParametrosMedicos(ref comando, med);
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "spAgregarMedico";

                return comando.ExecuteNonQuery();
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private void ArmarParametrosMedicos(ref SqlCommand Comando, Medicos med)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = Comando.Parameters.Add("@Legajo_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getLegajo_MED();
            sqlParametros = Comando.Parameters.Add("@Dni_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getDni_MED();
            sqlParametros = Comando.Parameters.Add("@Nombre_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getNombre_MED();
            sqlParametros = Comando.Parameters.Add("@Apellido_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getApellido_MED();
            sqlParametros = Comando.Parameters.Add("@Id_Sexo_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getId_Sexo_MED();
            sqlParametros = Comando.Parameters.Add("@Id_Nacionalidad_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getId_Nacionalidad_MED();
            sqlParametros = Comando.Parameters.Add("@Fecha_Nacimiento_MED", SqlDbType.DateTime);
            sqlParametros.Value = med.getFecha_Nacimiento_MED();
            sqlParametros = Comando.Parameters.Add("@Direccion_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getDireccion_MED();
            sqlParametros = Comando.Parameters.Add("@Cod_Localidad_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getCod_Localidad_MED();
            sqlParametros = Comando.Parameters.Add("@Cod_Provincia_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getCod_Provincia_MED();
            sqlParametros = Comando.Parameters.Add("@Correo_Electronico_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getCorreo_Electronico_MED();
            sqlParametros = Comando.Parameters.Add("@Telefono_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getTelefono_MED();
            sqlParametros = Comando.Parameters.Add("@Id_Especialidad_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getId_Especialidad_MED();
            sqlParametros = Comando.Parameters.Add("@Usuario_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getUsuario_MED();
            sqlParametros = Comando.Parameters.Add("@Tipo_Usuario_MED", SqlDbType.VarChar);
            sqlParametros.Value = med.getTipo_Usuario_MED();
            sqlParametros = Comando.Parameters.Add("@Estado_MED", SqlDbType.Bit);
            sqlParametros.Value = med.getEstado_MED();
        }

        public bool existeUsuarioMED(Medicos med)
        {
            ConexionBD cn = new ConexionBD();
            SqlConnection conexion = null;

            try
            {
                conexion = cn.ObtenerConexion();
                string consulta = "SELECT COUNT(*) FROM Medicos WHERE DNI_MED = @DNI_MED";
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.Parameters.AddWithValue("@DNI_MED", med.getDni_MED());

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void BajaLogicaMedico(string LEG)
        {
            string consultaSQL = "Update Medicos Set Estado_MED = 0 where Legajo_MED ='" + LEG + "'";
            cn.EjecutarConsulta(consultaSQL);
        }

    }
}

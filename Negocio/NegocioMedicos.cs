using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;

namespace Negocio
{
  public  class NegocioMedicos
    {
        DaoMedicos dm = new DaoMedicos();

        public DataTable ObtenerTablaMedicos()
        {
            return dm.TablaMedicos();
        }
        public bool Actualizar(Medicos medico)
        {
          return  dm.ActualizarMedico(medico);
        }

        public DataTable BuscarMed(string IDDNI)
        {

            return dm.BuscarMedico(IDDNI);
        }

        public DataTable BuscarMedxSexo(string sexoseleccionado)
        {
            return dm.BuscarMedxSexo(sexoseleccionado);
        }

        public DataTable buscarMedxProvincia(string provincia)
        {
            return dm.BuscarMedxProvincia(provincia);
        }

        public DataTable buscarMedXEspecialidad(string especialidad)
        {
            return dm.BuscarMedxEspecialidad(especialidad);
        }

        public void BajaLogica(string LEG)
        {
            dm.BajaLogicaMedico(LEG);
        }

        public bool agregarMedico(string legajo, string dni, string nombre, string apellido, string sexo, string nacionalidad,
                          DateTime fechaNacimiento, string direccion, string codLocalidad, string codProvincia,
                          string correoElectronico, string telefono, string especialidad, string usuario, string tipousuario)
        {
            int cantFilas = 0;

            Medicos medico = new Medicos();
            medico.setLegajo_MED(legajo);
            medico.setDni_MED(dni);
            medico.setNombre_MED(nombre);
            medico.setApellido_MED(apellido);
            medico.setId_Sexo_MED(sexo);
            medico.setId_Nacionalidad_MED(nacionalidad);
            medico.setFecha_Nacimiento_MED(fechaNacimiento);
            medico.setDireccion_MED(direccion);
            medico.setCod_Localidad_MED(codLocalidad);
            medico.setCod_Provincia_MED(codProvincia);
            medico.setCorreo_Electronico_MED(correoElectronico);
            medico.setTelefono_MED(telefono);
            medico.setId_Especialidad_MED(especialidad);
            medico.setUsuario_MED(usuario);
            medico.setTipo_Usuario_MED(tipousuario);
            medico.setEstado_MED(true);

            DatosClinica dao = new DatosClinica();


            cantFilas = dm.agregarMedico(medico);

            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

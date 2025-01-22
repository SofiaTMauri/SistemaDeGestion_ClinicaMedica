using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class AgregarMedico : System.Web.UI.Page
    {

        NegocioMedicos nm = new NegocioMedicos();
        Medicos med = new Medicos();
        NegocioEspecialidad negEsp = new NegocioEspecialidad();
        NegocioLocalidad negLoc = new NegocioLocalidad();
        NegocioNacionalidad negNac = new NegocioNacionalidad();
        NegocioSexo negSex = new NegocioSexo();
        NegocioProvincia negProv = new NegocioProvincia();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Datos Usuario"] != null)
            {
                LblUsuarioLogueado.Text = Session["Datos Usuario"].ToString();
            }
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                LlenarDDLs();
            }
        }

        protected void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            Boolean estado = false;

            string sexo = ddlSexo.SelectedValue;
            string legajo = txtLegajo.Text;
            string dni = txtDNI.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string nacionalidad = ddlNac.SelectedValue;
            DateTime fechaNacimiento = DateTime.Parse(txtFechaNac.Text);
            string direccion = textDomicilio.Text;
            string localidad = ddlLocalidad.SelectedValue;
            string provincia = ddlProv.SelectedValue;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            string especialidad = ddlEspecialidad.SelectedValue;
            string usuario = txtUsuario.Text;
            string tipousuario = "Medico";

            estado = nm.agregarMedico(legajo, dni, nombre, apellido, sexo, nacionalidad, fechaNacimiento,
                                           direccion, localidad, provincia, correo, telefono, especialidad, usuario, tipousuario);

            if (estado==true)
            {
                lblAviso.Text = "Médico agregado!";
            }
            else
            {
                lblAviso.Text = "Error al agregar médico.";
            }

            txtLegajo.Text = "";
            txtDNI.Text = "";
            ddlEspecialidad.SelectedIndex = 0;
            ddlNac.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlProv.SelectedIndex = 0;
            ddlSexo.SelectedIndex = 0;
            txtNombre.Text = "";
            txtNuevoUsuario.Text = "";
            txtApellido.Text = "";
            txtFechaNac.Text = "";
            textDomicilio.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
        }

        protected void LlenarDDLs()
        {
            negEsp.ObtenerTablaEspecialidad(ddlEspecialidad);
            ddlEspecialidad.Items.Insert(0, "---Seleccionar---");
            negLoc.ObtenerTablaLocalidad(ddlLocalidad);
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            negNac.ObtenerTablaNacionalidad(ddlNac);
            ddlNac.Items.Insert(0, "---Seleccionar---");
            negProv.ObtenerTablaProvincias(ddlProv);
            ddlProv.Items.Insert(0, "---Seleccionar---");
            negSex.ObtenerTablaSexo(ddlSexo);
            ddlSexo.Items.Insert(0, "---Seleccionar---"); 
        }
    }
}
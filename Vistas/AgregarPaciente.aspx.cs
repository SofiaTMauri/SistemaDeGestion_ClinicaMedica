using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace Vistas
{
    public partial class AgregarPaciente : System.Web.UI.Page
    {
        NegocioPacientes neg = new NegocioPacientes();
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

        protected void LlenarDDLs()
        {
            negLoc.ObtenerTablaLocalidad(ddlLocalidad);
            ddlLocalidad.Items.Insert(0,"--Seleccionar--");
            negNac.ObtenerTablaNacionalidad(ddlNac);
            ddlNac.Items.Insert(0, "---Seleccionar---");
            negProv.ObtenerTablaProvincias(ddlProv);
            ddlProv.Items.Insert(0, "---Seleccionar---");
            negSex.ObtenerTablaSexo(ddlSexo);
            ddlSexo.Items.Insert(0, "---Seleccionar---");

        }

        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            Boolean estado = false;
            string dni = txtDNI.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string sexo = ddlSexo.SelectedValue;
            string nacionalidad = ddlNac.SelectedValue;
            //DateTime fechaNac = DateTime.Parse(txtFechaNac.Text);
            string fechaNac = txtFechaNac.Text;
            string direccion = txtDireccion.Text;
            string localidad = ddlLocalidad.SelectedValue;
            string provincia = ddlProv.SelectedValue;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;

            //estado = neg.agregarPaciente(dni, nombre, apellido, sexo, nacionalidad, fechaNac, direccion, localidad, provincia, correo, telefono);

            lblaviso.Text = localidad;

            if (estado == true)
            {
                lblaviso.Text = "Paciente agregado!";
            }


        }
    }
}
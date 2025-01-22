using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using System.Windows;

namespace Vistas
{
    public partial class Medicos : System.Web.UI.Page
    {
        
        NegocioProvincia negProv = new NegocioProvincia();
        NegocioEspecialidad negEsp = new NegocioEspecialidad();
        NegocioMedicos negMed = new NegocioMedicos();
        NegocioSexo negSe = new NegocioSexo();
        NegocioLocalidad negLoc = new NegocioLocalidad();
        NegocioNacionalidad negNac = new NegocioNacionalidad();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (Session["Datos Usuario"] != null)
            {
                LblUsuarioLogueado.Text = Session["Datos Usuario"].ToString();
            }
            if (IsPostBack == false)
            {
                LlenarDDLProvincias();
                LlenarDDLEspecialidades();
                mostrarTabla();
            }
        }

        protected void LlenarDDLProvincias()
        {
            negProv.ObtenerTablaProvincias(ddlProvincias);
            ddlProvincias.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }

        protected void LlenarDDLEspecialidades()
        {
            negEsp.ObtenerTablaEspecialidad(ddlEspecialidades);
            ddlEspecialidades.Items.Insert(0,new ListItem("--Seleccionar--", "0"));
        }

        protected void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMedico.aspx");
        }

   

        protected void mostrarTabla()
        {
            DataTable tabla = negMed.ObtenerTablaMedicos();
            gvMedicos.DataSource = tabla;
            gvMedicos.DataBind();


        }


        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            ddlEspecialidades.SelectedIndex = 0;
            ddlProvincias.SelectedIndex = 0;
            mostrarTabla();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ddlEspecialidades.SelectedIndex = 0;
            ddlProvincias.SelectedIndex = 0;
            if (txtBuscarMed.Text == "")
            {
                lblaviso.Text = "Debe ingresar un Nombre";
                return;
            }
            else
            {
                lblaviso.Text = "";
            }
            string DNI = txtBuscarMed.Text;

            gvMedicos.DataSource = negMed.BuscarMed(DNI);
            gvMedicos.DataBind();

            txtBuscarMed.Text = "";
        }

        protected void rbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sexoSeleccionado = rbSexo.SelectedValue;
            gvMedicos.DataSource = negMed.BuscarMedxSexo(sexoSeleccionado);
            gvMedicos.DataBind();
            ddlEspecialidades.SelectedIndex = 0;
            ddlProvincias.SelectedIndex = 0;
        }

        protected void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string provinciaSeleccionada = ddlProvincias.SelectedValue;
            gvMedicos.DataSource = negMed.buscarMedxProvincia(provinciaSeleccionada);
            gvMedicos.DataBind();
            ddlEspecialidades.SelectedIndex = 0;
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string especialidadSeleccionada = ddlEspecialidades.SelectedValue;
            gvMedicos.DataSource = negMed.buscarMedXEspecialidad(especialidadSeleccionada);
            gvMedicos.DataBind();
            ddlProvincias.SelectedIndex = 0;
        }


        protected void gvMedicos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {
                // Obtener los datos de la fila desde el GridView
                DataRowView rowView = e.Row.DataItem as DataRowView;
                if (rowView != null)
                {
                    // Acceder a los datos de la fila, por ejemplo, el campo "pais"
                    string sexo = rowView["Sexo"].ToString();
                    string nacionalidad = rowView["Nacionalidad"].ToString();
                    string localidad = rowView["Localidad"].ToString();
                    string provincia = rowView["Provincia"].ToString();
                    string especialidad = rowView["Especialidad"].ToString();

                    // Encontrar el control DropDownList en la fila que se está editando
                    DropDownList DDLS = e.Row.FindControl("dllElegirSexo") as DropDownList;
                    DropDownList DDLN = e.Row.FindControl("dllElegirNacionalidad") as DropDownList;
                    DropDownList DDLL = e.Row.FindControl("dllElegirLocalidad") as DropDownList;
                    DropDownList DDLP = e.Row.FindControl("dllElegirProvincia") as DropDownList;
                    DropDownList DDLE = e.Row.FindControl("dllElegirEspecialidad") as DropDownList;

                    string seAct = ((Label)e.Row.FindControl("lbl_ed_it_sexo")).Text;
                    string nacAct = ((Label)e.Row.FindControl("lbl_ed_it_Nac")).Text;
                    string locAct = ((Label)e.Row.FindControl("lbl_ed_it_Loc")).Text;
                    string provAct = ((Label)e.Row.FindControl("lbl_ed_it_Prov")).Text;
                    string espAct = ((Label)e.Row.FindControl("lbl_ed_it_Esp")).Text;

                    if (DDLS != null && DDLN != null && DDLL != null && DDLP != null && DDLP != null)
                    {
                        // Llenar el DropDownList con datos
                        negSe.ObtenerTablaSeReg(DDLS, seAct);
                        negNac.ObtenerTablaNacReg(DDLN, nacAct);
                        negLoc.ObtenerTablaLocReg(DDLL, locAct);
                        negProv.ObtenerTablaProvReg(DDLP, provAct);
                        negEsp.ObtenerTablaEspReg(DDLE, espAct);
                    }
                }
            }
        }

        protected void gvMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMedicos.EditIndex = e.NewEditIndex;
            mostrarTabla();
        }

        protected void gvMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMedicos.EditIndex =-1;
            mostrarTabla();
        }

        protected void gvMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obtener los datos editados del GridView

            string legajo = ((Label)gvMedicos.Rows[e.RowIndex].FindControl("lblLegajo")).Text;
            //string dni = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtDni")).Text;
            string nombre = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtNombre")).Text;
            string apellido = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtApellido")).Text;
            
            DropDownList DDLS = gvMedicos.Rows[e.RowIndex].FindControl("dllElegirSexo") as DropDownList;
            string sexo = DDLS.SelectedValue;

            DropDownList DDLN = gvMedicos.Rows[e.RowIndex].FindControl("dllElegirNacionalidad") as DropDownList;
            string nacionalidad = DDLN.SelectedValue;

            //string nacionalidad = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtNacionalidad")).Text;

            //DateTime fechaNacimiento;
            //DateTime.TryParse(((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtFechaNac")).Text, out fechaNacimiento);
            string direccion = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtDireccion")).Text;

            DropDownList DDLL = gvMedicos.Rows[e.RowIndex].FindControl("dllElegirLocalidad") as DropDownList;
            string localidad = DDLL.SelectedValue;

            //string localidad = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtLocalidad")).Text;

            DropDownList DDLP = gvMedicos.Rows[e.RowIndex].FindControl("dllElegirProvincia") as DropDownList;
            string provincia = DDLP.SelectedValue;
            //string provincia = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtProvincia")).Text;

            string correoElectronico = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtCorreoElectronico")).Text;
            string telefono = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtTelefono")).Text;


            DropDownList DDLE = gvMedicos.Rows[e.RowIndex].FindControl("dllElegirEspecialidad") as DropDownList;
            string especialidad = DDLE.SelectedValue;
            //string especialidad = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtEspecialidad")).Text;

            //bool estado = true;

            // Crear objeto Medico con los datos editados
            Entidades.Medicos medico = new Entidades.Medicos();
            medico.setLegajo_MED(legajo);
            //medico.setDni_MED(dni);
            medico.setNombre_MED(nombre);
            medico.setApellido_MED(apellido);
            medico.setId_Sexo_MED(sexo);
            medico.setId_Nacionalidad_MED(nacionalidad);
            //medico.setFecha_Nacimiento_MED(fechaNacimiento);
            medico.setDireccion_MED(direccion);
            medico.setCod_Localidad_MED(localidad);
            medico.setCod_Provincia_MED(provincia);
            medico.setCorreo_Electronico_MED(correoElectronico);
            medico.setTelefono_MED(telefono);
            medico.setId_Especialidad_MED(especialidad);
            //medico.setEstado_MED(estado);

            //Actualizar en la base de datos usando SqlParameter y una capa DAL

            negMed.Actualizar(medico);

            // Salir del modo de edición y actualizar la tabla
            gvMedicos.EditIndex = -1;
            mostrarTabla(); // Esta función debería actualizar el GridView
        }

        protected void gvMedicos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eventoEliminar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string LEG = ((Label)gvMedicos.Rows[fila].FindControl("lblLegajo")).Text;

                string resultado = (MessageBox.Show("Desea eliminar el registro?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning)).ToString();
                if (resultado == "Yes")
                {
                    negMed.BajaLogica(LEG);
                    MessageBox.Show("Se ha eliminado el registro");
                    mostrarTabla();
                }
            }
        }
    }
}
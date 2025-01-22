﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Threading.Tasks;
using System.Windows;

namespace Vistas
{
    public partial class Pacientes : System.Web.UI.Page
    {
        NegocioPacientes neg = new NegocioPacientes();
        NegocioLocalidad negLoc = new NegocioLocalidad();
        NegocioSexo negSe = new NegocioSexo();
        NegocioNacionalidad negNac = new NegocioNacionalidad();
        NegocioProvincia negProv = new NegocioProvincia();


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["Datos Usuario"] != null)
            {
                lblUsuarioLogueado.Text = Session["Datos Usuario"].ToString();
            }
            if (IsPostBack == false)
            {
                LlenarDDLLocalidad();
                mostrarTabla();
            }
        }

        protected void LlenarDDLLocalidad()
        {
            negLoc.ObtenerTablaLocalidad(DropDownList1);
            DropDownList1.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }


        protected void mostrarTabla()
        {
            DataTable tabla = neg.ObtenerTablaPacientes();
            GridView1.DataSource = tabla;
            GridView1.DataBind();
        }

        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPaciente.aspx");
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            DropDownList1.SelectedIndex = 0;
            mostrarTabla();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DropDownList1.SelectedIndex = 0;
            if (txtBuscar.Text == "")
            {
                lblaviso.Text = "Debe ingresar un DNI";
                return;
            }
            else
            {
                lblaviso.Text = "";
            }
            string DNI = txtBuscar.Text;
            GridView1.DataSource = neg.BuscarPac(DNI);
            GridView1.DataBind();

            txtBuscar.Text = "";
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sexoSeleccionado = RadioButtonList1.SelectedValue;
            GridView1.DataSource = neg.BuscarPacxSexo(sexoSeleccionado);
            GridView1.DataBind();
            DropDownList1.SelectedIndex = 0;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string localidadSeleccionada = DropDownList1.SelectedValue;
            GridView1.DataSource = neg.BuscarPacxLocalidad(localidadSeleccionada);
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eventoEliminar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string DNI = ((Label)GridView1.Rows[fila].FindControl("lbl_it_DNI")).Text;

                string resultado = (MessageBox.Show("Desea eliminar el registro?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning)).ToString() ;
                if (resultado == "Yes")
                {
                    neg.BajaLogica(DNI);
                    MessageBox.Show("Se ha eliminado el registro");
                    mostrarTabla();
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {
                DataRowView rowView = e.Row.DataItem as DataRowView;
                // Obtener los datos de la fila desde el GridView
                if (rowView != null)
                {
                    // Acceder a los datos de la fila, por ejemplo, el campo "pais"
                    string sexo = rowView["Sexo"].ToString();
                    string nacionalidad = rowView["Nacionalidad"].ToString();
                    string localidad = rowView["Localidad"].ToString();
                    string provincia = rowView["Provincia"].ToString();

                    // Encontrar el control DropDownList en la fila que se está editando
                    DropDownList DDLS = e.Row.FindControl("dllElegirSexo") as DropDownList;
                    DropDownList DDLN = e.Row.FindControl("dllElegirNacionalidad") as DropDownList;
                    DropDownList DDLL = e.Row.FindControl("ddlElegirLocalidad") as DropDownList;
                    DropDownList DDLP = e.Row.FindControl("ddlElegirProv") as DropDownList;

                    string seAct = ((Label)e.Row.FindControl("lbl_ed_it_sexo")).Text;
                    string nacAct = ((Label)e.Row.FindControl("lbl_ed_it_nac")).Text;
                    string locAct = ((Label)e.Row.FindControl("lbl_ed_it_loc")).Text;
                    string provAct = ((Label)e.Row.FindControl("lbl_ed_it_Prov")).Text;

                    if (DDLS != null && DDLN != null && DDLL != null && DDLP != null)
                    {
                        // Llenar el DropDownList con datos
                        negSe.ObtenerTablaSeReg(DDLS,seAct);
                        negNac.ObtenerTablaNacReg(DDLN,nacAct);
                        negLoc.ObtenerTablaLocReg(DDLL,locAct);
                        negProv.ObtenerTablaProvReg(DDLP,provAct);
                    }
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            mostrarTabla();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obtener los datos editados del GridView

            string dni = ((Label)GridView1.Rows[e.RowIndex].FindControl("lbl_ed_it_DNI")).Text;
            string nombre = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_ed_it_Nombre")).Text;
            string apellido = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_ed_it_Apellido")).Text;

            DropDownList DDLS = GridView1.Rows[e.RowIndex].FindControl("dllElegirSexo") as DropDownList;
            string sexo = DDLS.SelectedValue;

            DropDownList DDLN = GridView1.Rows[e.RowIndex].FindControl("dllElegirNacionalidad") as DropDownList;
            string nacionalidad = DDLN.SelectedValue;

            string direccion = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_ed_it_Direccion")).Text;

            DropDownList DDLL = GridView1.Rows[e.RowIndex].FindControl("ddlElegirLocalidad") as DropDownList;
            string localidad = DDLL.SelectedValue;

            DropDownList DDLP = GridView1.Rows[e.RowIndex].FindControl("ddlElegirProv") as DropDownList;
            string provincia = DDLP.SelectedValue;

            string correoElectronico = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_ed_it_Correo")).Text;
            string telefono = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_ed_it_Telefono")).Text;

            // Crear objeto Pacientes con los datos editados
            Entidades.Pacientes pac = new Entidades.Pacientes();
            pac.setDNIPaci(dni);
            pac.setNombrePaci(nombre);
            pac.setApellidoPaci(apellido);
            pac.setIDSexoPaci(sexo);
            pac.setIDNacPaci(nacionalidad);
            pac.setDireccionPaci(direccion);
            pac.setCodLocPaci(localidad);
            pac.setCodProvPaci(provincia);
            pac.setCorreoElectPaci(correoElectronico);
            pac.setTelefonoPaci(telefono);

            //Actualizar en la base de datos usando SqlParameter y una capa DAL

            neg.Actualizar(pac);

            // Salir del modo de edición y actualizar la tabla
            GridView1.EditIndex = -1;
            mostrarTabla(); // Esta función debería actualizar el GridView
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            mostrarTabla();
        }
    }
}
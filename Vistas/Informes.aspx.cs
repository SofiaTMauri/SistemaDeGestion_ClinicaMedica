using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Informes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                ddlMesInicio.Items.Insert(0, "---Seleccionar---");
                ddlMesFinal.Items.Insert(0, "---Seleccionar---");
                ddlAñoInicio.Items.Insert(0, "---Seleccionar---");
                ddlAñoFinal.Items.Insert(0, "---Seleccionar---");
                ddlSexo.Items.Insert(0, "---Seleccionar---");
            }
        }

    }
}
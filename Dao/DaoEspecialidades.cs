using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Dao
{
    public class DaoEspecialidades
    {
        string ConsultaSQLTablaEspecialidades = "SELECT * FROM Especialidades";
        ConexionBD cn = new ConexionBD();

        public DropDownList CargarEspecialidades(DropDownList Lista)
        {
            Lista.DataSource = cn.ObtenerTabla("Especialidades", ConsultaSQLTablaEspecialidades);
            Lista.DataTextField = "Nombre_ES";
            Lista.DataValueField = "Id_Especialidad_ES";
            Lista.DataBind();
         
            return Lista;
        }

        public DropDownList CargarEspecialidadessReg(DropDownList Lista, string registro)
        {
            Lista.DataSource = cn.ObtenerTabla("Especialidades", ConsultaSQLTablaEspecialidades + " ORDER BY CASE WHEN Id_Especialidad_ES = " + registro + " THEN 0 ELSE 1 END; ");
            Lista.DataTextField = "Nombre_ES";
            Lista.DataValueField = "Id_Especialidad_ES";
            Lista.DataBind();

            return Lista;
        }
    }
}

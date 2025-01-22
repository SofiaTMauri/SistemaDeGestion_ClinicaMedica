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
    public class DaoLocalidades
    {
        string ConsultaSQLTablaLocalidades = "SELECT * FROM Localidades";
        ConexionBD cn = new ConexionBD();

        public DropDownList CargarLocalidades(DropDownList Lista)
        {
            Lista.DataSource = cn.ObtenerTabla("Localidades", ConsultaSQLTablaLocalidades);
            Lista.DataTextField = "Nombre_LO";
            Lista.DataValueField = "Id_Localidades_LO";
            Lista.DataBind();
            
            return Lista;
        }

        public DropDownList CargarLocalidadesReg(DropDownList Lista,string registro)
        {
            Lista.DataSource = cn.ObtenerTabla("Localidades", ConsultaSQLTablaLocalidades + " ORDER BY CASE WHEN Id_Localidades_LO = "+ registro +" THEN 0 ELSE 1 END; ");
            Lista.DataTextField = "Nombre_LO";
            Lista.DataValueField = "Id_Localidades_LO";
            Lista.DataBind();

            return Lista;
        }

    }

}

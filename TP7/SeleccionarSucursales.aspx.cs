using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TP7
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        public string consulta = "SELECT Id_Sucursal, NombreSucursal, DescripcionSucursal, URL_Imagen_Sucursal FROM Sucursal ";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Trim()!="")
            {
                consulta+= "WHERE NombreSucursal LIKE '" + txtNombre.Text.Trim() + "%'; ";
                SqlDataSource1.SelectCommand = consulta;
                SqlDataSource1.DataBind();
                lvSucursales.DataBind();
            }
            else
            {
                SqlDataSource1.SelectCommand = consulta;
                SqlDataSource1.DataBind();
                lvSucursales.DataBind();
            }
            txtNombre.Text = "";
        }

        protected void btnProvincia_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSeleccionar")
            {
                consulta += "WHERE Id_ProvinciaSucursal = '" + e.CommandArgument.ToString() + "'; ";
                SqlDataSource1.SelectCommand = consulta;
                SqlDataSource1.DataBind();
                lvSucursales.DataBind();
            }
        }

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            string datos = "";
            if (e.CommandName == "eventoSeleccionar")
            {
                datos = e.CommandArgument.ToString();
            }

            cargarTablaSession(datos);
        }

        void cargarTablaSession(string elementos)
        {
            Tabla ts = new Tabla();
            if (Session["Tabla"] == null)
            {
                Session["Tabla"] = ts.CrearTabla();
            }

            String[] elementos2 = elementos.Split(',');

            ts.NuevaSucursal((DataTable)Session["Tabla"], elementos2[0], elementos2[1], elementos2[2]);
        }
    }
}
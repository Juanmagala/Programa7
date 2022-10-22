﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TP7
{
    public partial class ListadoSucursalesSeleccionados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Tabla"]!=null)
            {
                lblSeleccion.Visible = false;
                grdSucursales.DataSource = (DataTable)Session["Tabla"];
                grdSucursales.DataBind();
            }
            else
            {
                lblSeleccion.Visible = true;
            }
        }
    }
}
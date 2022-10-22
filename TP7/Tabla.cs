using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TP7
{
    public class Tabla
    {
        public DataTable CrearTabla()
        {
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("ID_SUCURSAL", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            columna = new DataColumn("NOMBRE", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            columna = new DataColumn("DESCRIPCION", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            
            return dt;
        }

        public void NuevaSucursal(DataTable tabla, string idSucursal, string Nombre, string Descripcion)
        {
            foreach(DataRow dr1 in tabla.Rows)
            {
                if(dr1["ID_SUCURSAL"].ToString()==idSucursal)
                {
                    return;
                }
            }

            DataRow dr = tabla.NewRow();
            dr["ID_SUCURSAL"] = idSucursal;
            dr["NOMBRE"] = Nombre;
            dr["DESCRIPCION"] = Descripcion;
            tabla.Rows.Add(dr);
        }
    }
}
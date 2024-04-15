using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SistemaVerduleria
{
    public partial class MantenimientoTipoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Variables necesarias para las alertas
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string cstext = "";

            //Valida que todos los campos estén completados
            if ((!string.IsNullOrEmpty(txtNombreProducto.Text)) && (!string.IsNullOrEmpty(txtNombreProducto.Text)) &&
                   (!string.IsNullOrEmpty(txtCantidad.Text)) && (ListaTipoPrecio.SelectedValue != "---Seleccione una Opción---") && (ListaTipoProducto.SelectedValue != "---Seleccione una Opción---"))
            {
                string TipoProductoTemp = ListaTipoProducto.SelectedValue.ToString();
                string TipoPrecioTemp = ListaTipoPrecio.Text.ToString();
                int CantidadTemp = Convert.ToInt32(txtCantidad.Text);
                decimal PrecioTemp = Convert.ToDecimal(txtPrecio.Text);

                //Valida que el tipo de producto ya exista
                MantenimientoTipoProductoBLL ValidaTipoProductoBLL = new MantenimientoTipoProductoBLL();
                bool Validacion = ValidaTipoProductoBLL.ValidaExistenciaProducto(txtNombreProducto.Text);


                if (Validacion == true)
                {
                    //Actualiza el tipo de producto
                    MantenimientoTipoProductoBLL TipoProductoBLL = new MantenimientoTipoProductoBLL();
                    TipoProductoBLL.ActualizaTipoProducto(txtNombreProducto.Text, TipoProductoTemp, TipoPrecioTemp, CantidadTemp, PrecioTemp);

                    LimpiaCampos();

                    cstext = "alert('Producto Actualizado Exitosamente');";
                    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);

                }
                else
                {
                    //Registra tipo de producto nuevo
                    MantenimientoTipoProductoBLL TipoProductoBLL = new MantenimientoTipoProductoBLL();
                    TipoProductoBLL.InsertaTipoProducto(txtNombreProducto.Text, TipoProductoTemp, TipoPrecioTemp, CantidadTemp, PrecioTemp);

                    LimpiaCampos();

                    cstext = "alert('Se ha agregado correctamente un nuevo producto');";
                    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                }
            }
            cstext = "alert('Debe completar todos los campos para poder almacenar la información');";
            cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);

        }
        private void LimpiaCampos()
        {
            //limpia los campos posterior al procesamiento
            txtNombreProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            ListaTipoPrecio.SelectedValue = "---Seleccione una Opción---";
            ListaTipoProducto.SelectedValue = "---Seleccione una Opción---";
        }
    }
}
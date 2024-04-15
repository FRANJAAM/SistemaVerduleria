using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SistemaVerduleria
{
    public partial class MantenimientoTipoProducto : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CamposCompletados())
            {
                string tipoProducto = ListaTipoProducto.SelectedValue.ToString();
                string tipoPrecio = ListaTipoPrecio.Text.ToString();
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                decimal precio = Convert.ToDecimal(txtPrecio.Text);

                MantenimientoTipoProductoBLL tipoProductoBLL = new MantenimientoTipoProductoBLL();

                if (tipoProductoBLL.ValidaExistenciaProducto(txtNombreProducto.Text))
                {
                    tipoProductoBLL.ActualizaTipoProducto(txtNombreProducto.Text, tipoProducto, tipoPrecio, cantidad, precio);
                    MostrarMensaje("Producto Actualizado Exitosamente");
                }
                else
                {
                    tipoProductoBLL.InsertaTipoProducto(txtNombreProducto.Text, tipoProducto, tipoPrecio, cantidad, precio);
                    MostrarMensaje("Se ha agregado correctamente un nuevo producto");
                }

                LimpiaCampos();
            }
            else
            {
                MostrarMensaje("Debe completar todos los campos para poder almacenar la información");
            }
        }

        private bool CamposCompletados()
        {
            return !string.IsNullOrEmpty(txtNombreProducto.Text) &&
                   !string.IsNullOrEmpty(txtCantidad.Text) &&
                   ListaTipoPrecio.SelectedValue != "---Seleccione una Opción---" &&
                   ListaTipoProducto.SelectedValue != "---Seleccione una Opción---";
        }

        private void MostrarMensaje(string mensaje)
        {
            Type cstype = GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "PopupScript", $"alert('{mensaje}');", true);
        }

        private void LimpiaCampos()
        {
            txtNombreProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            ListaTipoPrecio.SelectedValue = "---Seleccione una Opción---";
            ListaTipoProducto.SelectedValue = "---Seleccione una Opción---";
        }
    }
}
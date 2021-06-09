using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prycarrito.Public.Productos
{
    public partial class wfmProductoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void newProduct()
        {
            lblId.Text = "";
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtStockMaximo.Text = "";
            txtStockMinimo.Text = "";
            
        }

        protected void imgbNuevo_Click(object sender, ImageClickEventArgs e)
        {
            newProduct();

        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            newProduct();
        }

        protected void imgbGuardar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void lnkGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void ImageRegresar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {

        }
    }
}
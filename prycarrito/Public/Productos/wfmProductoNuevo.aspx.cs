using prycarrito.Logica;
using prycarrito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prycarrito.Public.Productos
{
    public partial class wfmProductoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    loadProduct(int.Parse(Request["cod"].ToString()));
                }
            }
        }

        private void loadProduct(int codigoProducto)
        {
            try
            {
                TBL_PRODUCTO dataProducto = new TBL_PRODUCTO();
                var tasProducto = Task.Run(() => logicaProducto.getProductsxId(codigoProducto));
                tasProducto.Wait();
                dataProducto = tasProducto.Result;
                if (dataProducto != null)
                {
                    lblId.Text = dataProducto.pro_id.ToString();
                    txtCodigo.Text = dataProducto.pro_codigo;
                    UC_Categoria1.DropDownList.SelectedValue = dataProducto.cat_id.ToString();
                    txtNombre.Text = dataProducto.pro_nombre;
                    txtDescripcion.Text = dataProducto.pro_descripcion;
                    txtPrecioCompra.Text = dataProducto.pro_preciocompra.ToString("0.00");
                    txtPrecioVenta.Text = dataProducto.pro_precioventa.ToString("0.00");
                    txtStockMinimo.Text = dataProducto.pro_stockminimo.ToString();
                    txtStockMaximo.Text = dataProducto.pro_stockmaximo.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMesagge.Text = ex.Message;
            }
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
            UC_Categoria1.DropDownList.SelectedIndex = 0;
        }

        protected void imgbNuevo_Click(object sender, ImageClickEventArgs e)
        {
            newProduct();

        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            newProduct();
        }


        private void save()
        {
            try
            {
                TBL_PRODUCTO dataProducto = new TBL_PRODUCTO();
                dataProducto.cat_id = Convert.ToInt16(UC_Categoria1.DropDownList.SelectedValue);
                dataProducto.pro_codigo = txtCodigo.Text;
                dataProducto.pro_nombre = txtNombre.Text.ToUpper();
                dataProducto.pro_descripcion = txtDescripcion.Text.ToUpper();
                dataProducto.pro_stockminimo = int.Parse(txtStockMinimo.Text);
                dataProducto.pro_stockmaximo = int.Parse(txtStockMaximo.Text);
                dataProducto.pro_preciocompra = decimal.Parse(txtPrecioCompra.Text);
                dataProducto.pro_precioventa = decimal.Parse(txtPrecioVenta.Text);
                dataProducto.pro_imagen = "C:/image";
                var taskSave = Task.Run(() => logicaProducto.saveProduct(dataProducto));
                taskSave.Wait();
                if (taskSave.Result)
                {
                    lblMesagge.Text = "Producto guardado correctamente";
                    newProduct();
                }
            }
            catch (Exception ex)
            {
                lblMesagge.Text = ex.Message;
            }
        }


        protected void imgbGuardar_Click(object sender, ImageClickEventArgs e)
        {
            save();
        }

        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            save();
        }

        protected void ImageRegresar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {

        }
    }
}
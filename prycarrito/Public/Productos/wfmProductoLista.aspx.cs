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
    public partial class wfmProductoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadProducts();
            }
        }

        private void loadProducts()
        {
            var taskListProducts = Task.Run(() => Logica.logicaProducto.getProducts());
            taskListProducts.Wait();
            var listaProducts = taskListProducts.Result;
            if (listaProducts.Count > 0 && listaProducts != null)
            {
                gdvDatosProductos.DataSource = listaProducts.Select(data => new
                {
                    ID = data.pro_id,
                    CODIGO = data.pro_codigo,
                    NOMBRE = data.pro_nombre,
                    PRECIO_C = data.pro_preciocompra.ToString("0.00"),
                    PRECIO_V = data.pro_precioventa.ToString("0.00"),
                    STOCK_MIN = data.pro_stockminimo,
                    STOCK_MAX = data.pro_stockmaximo,
                    CATEGORIA = data.TBL_CATEGORIA.cat_nombre,
                    ESTADO = data.pro_status
                }).ToList();
                gdvDatosProductos.DataBind();
            }

        }

        protected void gdvDatosProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string codigo = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Modificar")
            {
                //Aplicar un metodo de encriptacion para el codigo que se envía por URL 
                //Encriptar el codigo

                Response.Redirect("wfmProductoNuevo.aspx?cod=" + codigo);

            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    TBL_PRODUCTO dataProducto = new TBL_PRODUCTO();
                    var tasProducto = Task.Run(() => logicaProducto.getProductsxId(int.Parse(codigo)));
                    tasProducto.Wait();
                    dataProducto = tasProducto.Result;
                    if (dataProducto != null)
                    {
                        var taskDelete = Task.Run(() => logicaProducto.deleteProduct(dataProducto));
                        taskDelete.Wait();
                        if (taskDelete.Result)
                        {
                            loadProducts();
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Mensaje de error.   
                }

            }

        }

        private void nuevo()
        {
            Response.Redirect("wfmProductoNuevo.aspx");
        }

        protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
        {
            nuevo();
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }
    }
}
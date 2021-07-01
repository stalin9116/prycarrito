using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prycarrito.Public.Catalogo
{
    public partial class wfmCatalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCatalogo();
            }
        }

        private void loadCatalogo()
        {
            var _taskProducts = Task.Run(() => Logica.logicaProducto.getProducts());
            _taskProducts.Wait();

            var listaProductos = _taskProducts.Result;
            if (listaProductos.Count > 0)
            {
                DataList1.DataSource = listaProductos.Select(data => new
                {
                    ID = data.pro_id,
                    Nombre = data.pro_nombre,
                    Precio = data.pro_precioventa.ToString("0.00"),
                    URL = data.pro_imagen
                }
                ).ToList();
            }

            DataList1.DataBind();

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string codigo = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Comprar")
            {
                //Encriptar url
                Response.Redirect("wfmDetalleProducto?cod=" + codigo);
            }
        }
    }
}
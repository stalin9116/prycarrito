using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prycarrito.UserControls
{
    public partial class ucGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        public void loadData( )
        {
            
            
            
            var taskListProducts = Task.Run(() => Logica.logicaProducto.getProducts());
            taskListProducts.Wait();
            var listaProducts = taskListProducts.Result;
            if (listaProducts.Count > 0 && listaProducts != null)
            {
                GridView1.DataSource = listaProducts.Select(data => new
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
                GridView1.DataBind();
            }
        }

    }
}
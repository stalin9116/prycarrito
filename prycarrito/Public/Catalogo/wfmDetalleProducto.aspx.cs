using prycarrito.Logica;
using prycarrito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prycarrito.Public.Catalogo
{
    public partial class wfmDetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int idProducto = Convert.ToInt32(Request["cod"].ToString());
                    loadProducto(idProducto);
                }
            }
        }

        private void loadProducto(int idProducto)
        {
            TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
            var task = Task.Run(() => logicaProducto.getProductsxId(idProducto));
            task.Wait();
            _infoProducto = task.Result;
            if (_infoProducto != null)
            {
                imgProducto.ImageUrl = _infoProducto.pro_imagen;
                lblNombre.Text = _infoProducto.pro_nombre;
                lblDescripcion.Text = _infoProducto.pro_descripcion;
                lblPrecio.Text = _infoProducto.pro_precioventa.ToString("0.00");
            }
        }

        protected void btnComprar_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
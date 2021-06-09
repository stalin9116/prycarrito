using prycarrito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prycarrito.UserControls
{
    public partial class ucCategoria : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UcCargar();
            }
        }

        private void UcCargar()
        {
            var _taskCategoria = Task.Run(() => Logica.logicaCategoria.getAllCategory());
            _taskCategoria.Wait();

            var listaCategoria = _taskCategoria.Result;

            if (listaCategoria.Count > 0 && listaCategoria != null)
            {
                var data = listaCategoria.OrderBy(categorias => categorias.cat_nombre).ToList();

                data.Insert(0, new TBL_CATEGORIA { cat_nombre = "Seleccione categoria", cat_id = 0 });
                DropDownList1.DataSource = data;
                //Mostrar usuario
                DropDownList1.DataTextField = "cat_nombre";
                //Codigo
                DropDownList1.DataValueField = "cat_id";
                DropDownList1.DataBind();
            }
        }
    }
}
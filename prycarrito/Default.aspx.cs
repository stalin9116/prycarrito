using prycarrito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prycarrito
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    TBL_USUARIO infoUsuario = new TBL_USUARIO();
                    infoUsuario = (TBL_USUARIO)Session["Usuario"];
                    if (infoUsuario != null)
                    {
                        lblRolUsuario.Text = infoUsuario.usu_apellidos+ " " + 
                                             infoUsuario.usu_nombres + " - " + 
                                             infoUsuario.TBL_ROL.rol_descripcion;
                    }
                }
                else
                {
                    Response.Redirect("~/Public/Login/Login.aspx");
                }
            }
        }
    }
}
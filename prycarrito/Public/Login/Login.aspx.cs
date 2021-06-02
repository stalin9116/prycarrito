using prycarrito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace prycarrito.Public.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            string user = txtUser.Text.TrimStart().TrimEnd();
            string password = txtpassword.Text;
            try
            {
                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                {
                    TBL_USUARIO infoUsuario = new TBL_USUARIO();
                    var _taskUser = Task.Run(() => Logica.logicaUsuario.getUserxLogin(user, password));
                    _taskUser.Wait();
                    infoUsuario = _taskUser.Result;
                    if (infoUsuario != null)
                    {
                        Session["Usuario"] = infoUsuario;
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Usuario o clave incorrecta'); </script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Usuario o clave incorrecta'); </script>");
                }
            }
            catch (Exception)
            {

                Response.Write("<script>alert('Error de comunicacion con el servidor'); </script>");
            }

        }
    }
}
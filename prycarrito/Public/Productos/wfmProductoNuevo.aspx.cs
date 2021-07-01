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
                //Imagen
                if (fuImagenProducto.HasFile)
                {
                    try
                    {
                        if (fuImagenProducto.PostedFile.ContentType == "image/png" || fuImagenProducto.PostedFile.ContentType == "image/jpg")
                        {
                            if (fuImagenProducto.PostedFile.ContentLength < 1000000)
                            {
                                string nombreProducto = txtCodigo.Text + ".jpg";
                                fuImagenProducto.SaveAs(Server.MapPath("~/images/product/") + nombreProducto);
                            }
                            else
                            {
                                lblMesagge.Text = "El tamanio de la imagen es de 100 kb";
                                return;
                            }
                        }
                        else
                        {
                            lblMesagge.Text = "Solo se acepta imagenes de tipo png y jpg";
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        lblMesagge.Text = "Error al cargar la imagen";
                    }
                }

                dataProducto.pro_imagen = "~/images/product/" + txtCodigo.Text + ".jpg";
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

        private void update()
        {
            try
            {
                TBL_PRODUCTO dataProducto = new TBL_PRODUCTO();
                var tasProducto = Task.Run(() => logicaProducto.getProductsxId(int.Parse(lblId.Text)));
                tasProducto.Wait();
                dataProducto = tasProducto.Result;
                if (dataProducto != null)
                {
                    dataProducto.cat_id = Convert.ToInt16(UC_Categoria1.DropDownList.SelectedValue);
                    dataProducto.pro_codigo = txtCodigo.Text;
                    dataProducto.pro_nombre = txtNombre.Text.ToUpper();
                    dataProducto.pro_descripcion = txtDescripcion.Text.ToUpper();
                    dataProducto.pro_stockminimo = int.Parse(txtStockMinimo.Text);
                    dataProducto.pro_stockmaximo = int.Parse(txtStockMaximo.Text);
                    dataProducto.pro_preciocompra = decimal.Parse(txtPrecioCompra.Text);
                    dataProducto.pro_precioventa = decimal.Parse(txtPrecioVenta.Text);
                    //Imagen
                    if (fuImagenProducto.HasFile)
                    {
                        try
                        {
                            if (fuImagenProducto.PostedFile.ContentType == "image/png" || fuImagenProducto.PostedFile.ContentType == "image/jpg" || fuImagenProducto.PostedFile.ContentType == "image/jpeg")
                            {
                                if (fuImagenProducto.PostedFile.ContentLength < 1000000)
                                {
                                    string nombreProducto = txtCodigo.Text + ".jpg";
                                    fuImagenProducto.SaveAs(Server.MapPath("~/images/product/") + nombreProducto);
                                }
                                else
                                {
                                    lblMesagge.Text = "El tamanio de la imagen es de 100 kb";
                                    return;
                                }
                            }
                            else
                            {
                                lblMesagge.Text = "Solo se acepta imagenes de tipo png y jpg";
                                return;
                            }
                        }
                        catch (Exception)
                        {
                            lblMesagge.Text = "Error al cargar la imagen";
                        }
                    }

                    dataProducto.pro_imagen = "~/images/product/" + txtCodigo.Text + ".jpg";
                    var taskSave = Task.Run(() => logicaProducto.updateProduct(dataProducto));
                    taskSave.Wait();
                    if (taskSave.Result)
                    {
                        lblMesagge.Text = "Producto guardado correctamente";
                        newProduct();
                    }
                }


            }
            catch (Exception ex)
            {
                lblMesagge.Text = ex.Message;
            }
        }



        protected void imgbGuardar_Click(object sender, ImageClickEventArgs e)
        {
            if (Request["cod"] != null)
            {
                update();
            }
            else
            {
                save();
            }
        }

        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            if (Request["cod"] != null)
            {
                update();
            }
            else
            {
                save();
            }
        }

        private void regresar()
        {
            Response.Redirect("wfmProductoLista.aspx");
        
        }

        protected void ImageRegresar_Click(object sender, ImageClickEventArgs e)
        {
            regresar();
        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
            regresar();
        }
    }
}
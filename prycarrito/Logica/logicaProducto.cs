using prycarrito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace prycarrito.Logica
{
    public class logicaProducto
    {
        private static DBCARRITOEntities dc = new DBCARRITOEntities();
        public static async Task<List<TBL_PRODUCTO>> getProducts()
        {
            try
            {

                return await dc.TBL_PRODUCTO.Where(data => data.pro_status == "A").ToListAsync();
                
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuarios");
            }

        }

        public static async Task<TBL_PRODUCTO> getProductsxId(int idProducto)
        {
            try
            {

                return await dc.TBL_PRODUCTO.FirstOrDefaultAsync(data => data.pro_status == "A"
                                                   && data.pro_id.Equals(idProducto));

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuarios");
            }

        }

        public static async Task<bool> saveProduct(TBL_PRODUCTO dataProducto)
        {
            try
            {

                bool result = false;

                dataProducto.pro_status = "A";
                dataProducto.pro_fechacreacion = DateTime.Now;
                dc.TBL_PRODUCTO.Add(dataProducto);

                result = await dc.SaveChangesAsync() > 0;

                return result;

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al guardar producto");
            }

        }

        public static async Task<bool> updateProduct(TBL_PRODUCTO dataProducto)
        {
            try
            {
                bool result = false;
                dataProducto.pro_fechacreacion = DateTime.Now;
                //commit hacia la base
                result = await dc.SaveChangesAsync() > 0;
                return result;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al modificar producto");
            }

        }

        public static async Task<bool> deleteProduct(TBL_PRODUCTO dataProducto)
        {
            try
            {
                bool result = false;
                dataProducto.pro_status = "I";
                dataProducto.pro_fechacreacion = DateTime.Now;
                //commit hacia la base
                result = await dc.SaveChangesAsync() > 0;

                //forma fisica
                //dc.TBL_PRODUCTO.Remove(dataProducto);

                return result;

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al eliminar producto");
            }

        }


    }
}
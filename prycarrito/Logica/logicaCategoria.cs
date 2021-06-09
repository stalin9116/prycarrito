using prycarrito.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace prycarrito.Logica
{
    public class logicaCategoria
    {
        private static DBCARRITOEntities dc = new DBCARRITOEntities();

        public static async Task<List<TBL_CATEGORIA>> getAllCategory()
        {
            try
            {

                return await dc.TBL_CATEGORIA.Where(data => data.cat_status == "A").ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener categorias");
            }

        }

    }
}
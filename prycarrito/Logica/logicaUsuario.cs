using prycarrito.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace prycarrito.Logica
{
    public class logicaUsuario
    {
        private static DBCARRITOEntities dc = new DBCARRITOEntities();

        public static async Task<TBL_USUARIO> getUserxLogin(string correo, string password)
        {
            try
            {

                return await dc.TBL_USUARIO.FirstOrDefaultAsync(data => data.usu_status == "A"
                                                                && data.usu_correo.Equals(correo)
                                                                && data.usu_password.Equals(password));
                //select * from TBL_USUARIO
                //where usu_status='A' and usu_correo=@correo
                //and usu_password=@password
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuarios");
            }

        }

        public static async Task<List<TBL_USUARIO>> getAllUser2()
        {
            try
            {
                return await dc.TBL_USUARIO.Where(data => data.usu_status == "A").ToListAsync();


            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuarios");
            }

        }



    }
}
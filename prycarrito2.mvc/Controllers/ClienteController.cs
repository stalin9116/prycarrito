using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prycarrito2.mvc.Models;

namespace prycarrito2.mvc.Controllers
{
    public class ClienteController : Controller
    {
        private DBCARRITOEntities db = new DBCARRITOEntities();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.TBL_CLIENTE.ToList());
        }

        
        public ActionResult Details(long? id, string identificacion)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CLIENTE tBL_CLIENTE = db.TBL_CLIENTE.Find(id, identificacion);
            if (tBL_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CLIENTE);
        }

        
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cli_id,cli_identificacion,cli_tipoidentificacion,cli_apellidos,cli_nombres,cli_genero,cli_fechanacimiento,cli_telefono,cli_celurar,cli_email,cli_status,cli_fechacreacion")] TBL_CLIENTE tBL_CLIENTE)
        {
            if (ModelState.IsValid)
            {

                db.TBL_CLIENTE.Add(tBL_CLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_CLIENTE);
        }

        
        public ActionResult Edit(long? id, string identificacion)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CLIENTE tBL_CLIENTE = db.TBL_CLIENTE.Find(id, identificacion);
            if (tBL_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CLIENTE);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cli_id,cli_identificacion,cli_tipoidentificacion,cli_apellidos,cli_nombres,cli_genero,cli_fechanacimiento,cli_telefono,cli_celurar,cli_email,cli_status,cli_fechacreacion")] TBL_CLIENTE tBL_CLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_CLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_CLIENTE);
        }

        
        public ActionResult Delete(long? id, string identificacion)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CLIENTE tBL_CLIENTE = db.TBL_CLIENTE.Find(id, identificacion);
            if (tBL_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CLIENTE);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id, string identificacion)
        {
            TBL_CLIENTE tBL_CLIENTE = db.TBL_CLIENTE.Find(id, identificacion);
            
            db.TBL_CLIENTE.Remove(tBL_CLIENTE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

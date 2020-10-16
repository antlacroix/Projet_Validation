using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelCinema.Models;

namespace WebCinema.Controllers
{
    public class sallesController : Controller
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        // GET: salles
        public ActionResult Index()
        {
            var salles = db.salles.Include(s => s.cinema).Include(s => s.salle_status);
            return View(salles.ToList());
        }

        // GET: salles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salle salle = db.salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        // GET: salles/Create
        public ActionResult Create()
        {
            ViewBag.cinema_id = new SelectList(db.cinemas, "id", "id");
            ViewBag.status_id = new SelectList(db.salle_status, "id", "status");
            return View();
        }

        // POST: salles/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nbr_place,numero_salle,commentaire,status_id,cinema_id")] salle salle)
        {
            if (ModelState.IsValid)
            {
                db.salles.Add(salle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cinema_id = new SelectList(db.cinemas, "id", "id", salle.cinema_id);
            ViewBag.status_id = new SelectList(db.salle_status, "id", "status", salle.status_id);
            return View(salle);
        }

        // GET: salles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salle salle = db.salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            ViewBag.cinema_id = new SelectList(db.cinemas, "id", "id", salle.cinema_id);
            ViewBag.status_id = new SelectList(db.salle_status, "id", "status", salle.status_id);
            return View(salle);
        }

        // POST: salles/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nbr_place,numero_salle,commentaire,status_id,cinema_id")] salle salle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cinema_id = new SelectList(db.cinemas, "id", "id", salle.cinema_id);
            ViewBag.status_id = new SelectList(db.salle_status, "id", "status", salle.status_id);
            return View(salle);
        }

        // GET: salles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salle salle = db.salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        // POST: salles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            salle salle = db.salles.Find(id);
            db.salles.Remove(salle);
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

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
    public class cinemasController : Controller
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        // GET: cinemas
        public ActionResult Index()
        {
            var cinemas = db.cinemas.Include(c => c.contact_info).Include(c => c.user);
            return View(cinemas.ToList());
        }

        // GET: cinemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cinema cinema = db.cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // GET: cinemas/Create
        public ActionResult Create()
        {
            ViewBag.contact_info_id = new SelectList(db.contact_info, "id", "tel_number");
            ViewBag.responsable_user_id = new SelectList(db.users, "id", "login");
            return View();
        }

        // POST: cinemas/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,contact_info_id,responsable_user_id")] cinema cinema)
        {
            if (ModelState.IsValid)
            {
                db.cinemas.Add(cinema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contact_info_id = new SelectList(db.contact_info, "id", "tel_number", cinema.contact_info_id);
            ViewBag.responsable_user_id = new SelectList(db.users, "id", "login", cinema.responsable_user_id);
            return View(cinema);
        }

        // GET: cinemas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cinema cinema = db.cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            ViewBag.contact_info_id = new SelectList(db.contact_info, "id", "tel_number", cinema.contact_info_id);
            ViewBag.responsable_user_id = new SelectList(db.users, "id", "login", cinema.responsable_user_id);
            return View(cinema);
        }

        // POST: cinemas/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,contact_info_id,responsable_user_id")] cinema cinema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contact_info_id = new SelectList(db.contact_info, "id", "tel_number", cinema.contact_info_id);
            ViewBag.responsable_user_id = new SelectList(db.users, "id", "login", cinema.responsable_user_id);
            return View(cinema);
        }

        // GET: cinemas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cinema cinema = db.cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // POST: cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cinema cinema = db.cinemas.Find(id);
            db.cinemas.Remove(cinema);
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

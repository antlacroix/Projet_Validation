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
    public class seancesController : Controller
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        // GET: seances
        public ActionResult Index()
        {
            var seances = db.seances.Include(s => s.film).Include(s => s.salle);
            return View(seances.ToList());
        }

        // GET: seances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seance seance = db.seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        // GET: seances/Create
        public ActionResult Create()
        {
            ViewBag.film_id = new SelectList(db.films, "id", "titre");
            ViewBag.salle_id = new SelectList(db.salles, "id", "commentaire");
            return View();
        }

        // POST: seances/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date_debut,date_fin,titre_seance,salle_id,film_id")] seance seance)
        {
            if (ModelState.IsValid)
            {
                db.seances.Add(seance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.film_id = new SelectList(db.films, "id", "titre", seance.film_id);
            ViewBag.salle_id = new SelectList(db.salles, "id", "commentaire", seance.salle_id);
            return View(seance);
        }

        // GET: seances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seance seance = db.seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            ViewBag.film_id = new SelectList(db.films, "id", "titre", seance.film_id);
            ViewBag.salle_id = new SelectList(db.salles, "id", "commentaire", seance.salle_id);
            return View(seance);
        }

        // POST: seances/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date_debut,date_fin,titre_seance,salle_id,film_id")] seance seance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.film_id = new SelectList(db.films, "id", "titre", seance.film_id);
            ViewBag.salle_id = new SelectList(db.salles, "id", "commentaire", seance.salle_id);
            return View(seance);
        }

        // GET: seances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seance seance = db.seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        // POST: seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            seance seance = db.seances.Find(id);
            db.seances.Remove(seance);
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

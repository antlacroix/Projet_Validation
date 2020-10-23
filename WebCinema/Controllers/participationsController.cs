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
    public class participationsController : Controller
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        // GET: participations
        public ActionResult Index()
        {
            var participations = db.participations.Include(p => p.Movie).Include(p => p.Participant).Include(p => p.Role);
            return View(participations.ToList());
        }

        // GET: participations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participation participation = db.participations.Find(id);
            if (participation == null)
            {
                return HttpNotFound();
            }
            return View(participation);
        }

        // GET: participations/Create
        public ActionResult Create()
        {
            ViewBag.film_id = new SelectList(db.films, "id", "titre");
            ViewBag.participant_id = new SelectList(db.participants, "id", "name");
            ViewBag.role_id = new SelectList(db.role_participant, "id", "role");
            return View();
        }

        // POST: participations/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,participant_id,role_id,film_id")] participation participation)
        {
            if (ModelState.IsValid)
            {
                db.participations.Add(participation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.film_id = new SelectList(db.films, "id", "titre", participation.Movie);
            ViewBag.participant_id = new SelectList(db.participants, "id", "name", participation.Participant);
            ViewBag.role_id = new SelectList(db.role_participant, "id", "role", participation.Role);
            return View(participation);
        }

        // GET: participations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participation participation = db.participations.Find(id);
            if (participation == null)
            {
                return HttpNotFound();
            }
            ViewBag.film_id = new SelectList(db.films, "id", "titre", participation.Movie);
            ViewBag.participant_id = new SelectList(db.participants, "id", "name", participation.Participant);
            ViewBag.role_id = new SelectList(db.role_participant, "id", "role", participation.Role);
            return View(participation);
        }

        // POST: participations/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,participant_id,role_id,film_id")] participation participation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.film_id = new SelectList(db.films, "id", "titre", participation.Movie);
            ViewBag.participant_id = new SelectList(db.participants, "id", "name", participation.Participant);
            ViewBag.role_id = new SelectList(db.role_participant, "id", "role", participation.Role);
            return View(participation);
        }

        // GET: participations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participation participation = db.participations.Find(id);
            if (participation == null)
            {
                return HttpNotFound();
            }
            return View(participation);
        }

        // POST: participations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            participation participation = db.participations.Find(id);
            db.participations.Remove(participation);
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

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
    public class genre_filmController : Controller
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        // GET: genre_film
        public ActionResult Index()
        {
            var genre_film = db.genre_film.Include(g => g.film).Include(g => g.genre);
            return View(genre_film.ToList());
        }

        // GET: genre_film/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            genre_film genre_film = db.genre_film.Find(id);
            if (genre_film == null)
            {
                return HttpNotFound();
            }
            return View(genre_film);
        }

        // GET: genre_film/Create
        public ActionResult Create()
        {
            ViewBag.film_id = new SelectList(db.films, "id", "titre");
            ViewBag.genre_id = new SelectList(db.genres, "id", "genre1");
            return View();
        }

        // POST: genre_film/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,genre_id,film_id")] genre_film genre_film)
        {
            if (ModelState.IsValid)
            {
                db.genre_film.Add(genre_film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.film_id = new SelectList(db.films, "id", "titre", genre_film.film_id);
            ViewBag.genre_id = new SelectList(db.genres, "id", "genre1", genre_film.genre_id);
            return View(genre_film);
        }

        // GET: genre_film/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            genre_film genre_film = db.genre_film.Find(id);
            if (genre_film == null)
            {
                return HttpNotFound();
            }
            ViewBag.film_id = new SelectList(db.films, "id", "titre", genre_film.film_id);
            ViewBag.genre_id = new SelectList(db.genres, "id", "genre1", genre_film.genre_id);
            return View(genre_film);
        }

        // POST: genre_film/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,genre_id,film_id")] genre_film genre_film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre_film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.film_id = new SelectList(db.films, "id", "titre", genre_film.film_id);
            ViewBag.genre_id = new SelectList(db.genres, "id", "genre1", genre_film.genre_id);
            return View(genre_film);
        }

        // GET: genre_film/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            genre_film genre_film = db.genre_film.Find(id);
            if (genre_film == null)
            {
                return HttpNotFound();
            }
            return View(genre_film);
        }

        // POST: genre_film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            genre_film genre_film = db.genre_film.Find(id);
            db.genre_film.Remove(genre_film);
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

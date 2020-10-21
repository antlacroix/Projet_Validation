using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelCinema.Models;
using ModelCinema.Models.DataManager;

namespace WebCinema.Controllers
{
    public class genresController : Controller
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        // GET: genres
        public ActionResult Index()
        {
            ManagerGenre manager = new ManagerGenre();
            return View(manager.GetAllGenre());
        }

        // GET: genres/Details/5
        public ActionResult Details(int? id)
        {
            ManagerGenre manager = new ManagerGenre();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            genre genre = manager.GetGenre(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: genres/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,genre1")] genre genre)
        {
            ManagerGenre manager = new ManagerGenre();
            if (ModelState.IsValid)
            {
                if(manager.PostGenre(genre))
                    return RedirectToAction("Index");
                // TODO
                //Implementer un message d'erreur
            }

            return View(genre);
        }

        // GET: genres/Edit/5
        public ActionResult Edit(int? id)
        {
            ManagerGenre manager = new ManagerGenre();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            genre genre = manager.GetGenre(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: genres/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,genre1")] genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: genres/Delete/5
        public ActionResult Delete(int? id)
        {
            ManagerGenre manager = new ManagerGenre();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            genre genre = manager.GetGenre(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManagerGenre manager = new ManagerGenre();
            if(manager.DeleteGenre(id))
                return RedirectToAction("Index");
            // TODO
            //Implementer un message d'erreur
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

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
    public class filmsController : Controller
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        // GET: films
        public ActionResult Index()
        {
            ManagerFilm manager = new ManagerFilm();
            return View(manager.GetAllFilms());
        }

        // GET: films/Details/5
        public ActionResult Details(int? id)
        {
            ManagerFilm manager = new ManagerFilm();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film film = manager.GetFilm(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: films/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: films/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titre,description,annee_parution,duree,rating,revenu")] film film)
        {
            ManagerFilm manager = new ManagerFilm();
            if (ModelState.IsValid)
            {
                if(manager.PostFilm(film))
                    return RedirectToAction("Index");
                // TODO
                //Implementer un message d'erreur
            }

            return View(film);
        }

        // GET: films/Edit/5
        public ActionResult Edit(int? id)
        {
            ManagerFilm manager = new ManagerFilm();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film film = manager.GetFilm(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: films/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titre,description,annee_parution,duree,rating,revenu")] film film)
        {
            ManagerFilm manager = new ManagerFilm();
            if (ModelState.IsValid)
            {
                if (manager.PutFilm(film))
                    return RedirectToAction("Index");
                // TODO
                //Implementer un message d'erreur
            }
            return View(film);
        }

        // GET: films/Delete/5
        public ActionResult Delete(int? id)
        {
            ManagerFilm manager = new ManagerFilm();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film film = manager.GetFilm(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManagerFilm manager = new ManagerFilm();
            if (manager.DeleteFilm(id))
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

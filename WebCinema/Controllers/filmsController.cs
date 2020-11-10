using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows;
using ModelCinema.ModelExeption;
using ModelCinema.Models;
using ModelCinema.Models.DataManager;

namespace WebCinema.Controllers
{
    public class filmsController : Controller
    {
        [HttpPost]
        public ActionResult Filtre(string titre, int? yearMin, int? yearMax, int? id_type)
        {
            return RedirectToAction("Index", new { titre = titre, yearMin = yearMin, yearMax = yearMax, id_type = id_type });
        }

        // GET: films/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                ManagerFilm manager = new ManagerFilm();
                film film = manager.GetFilm(id);
                return View(film);

            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index");
            }
        }

        // GET: films/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.id_type = new SelectList(new ManagerTypeFilm().GetAllType_film(), "id", "typage");
                ViewBag.id_film = new SelectList(new ManagerFilm().GetAllFilms(), "id", "titre");
                return View();
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index");
            }
        }

        // POST: films/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titre,description,annee_parution,duree,rating,revenu,ranking,votes,metascore,id_type,id_film")] film film)
        {
            try
            {
                ManagerFilm manager = new ManagerFilm();
                if (ModelState.IsValid)
                {
                    if (manager.PostFilm(film))
                        return RedirectToAction("Index");
                }
                else
                    throw new InvalidItemException("film");
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
            }
            ViewBag.id_type = new SelectList(new ManagerTypeFilm().GetAllType_film(), "id", "typage");
            ViewBag.id_film = new SelectList(new ManagerFilm().GetAllFilms(), "id", "titre");
            return View(film);
        }

        // GET: films/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                ManagerFilm manager = new ManagerFilm();
                film film = manager.GetFilm(id);

                ViewBag.id_type = new SelectList(new ManagerTypeFilm().GetAllType_film(), "id", "typage");
                ViewBag.id_film = new SelectList(new ManagerFilm().GetAllFilms(), "id", "titre");

                //ViewBag.id_type = new SelectList(new ManagerTypeFilm().GetAllType_film(), "id", "typage");
                //ViewBag.id_film = new SelectList(new ManagerFilm().GetAllFilms(), "id", "titre");

                return View(film);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index");
            }
        }

        // POST: films/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titre,description,annee_parution,duree,rating,revenu,ranking,votes,metascore,id_type,id_film")] film film)
        {
            try
            {
                ManagerFilm manager = new ManagerFilm();

                if (ModelState.IsValid)
                {
                    if (manager.PutFilm(film))
                        return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
            }
            return View(film);
        }

        // GET: films/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                ManagerFilm manager = new ManagerFilm();
                film film = manager.GetFilm(id);
                return View(film);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index");
            }
        }

        // POST: films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ManagerFilm manager = new ManagerFilm();
				
                //if (new ManagerSeance().GetAllSeance().Where(s => s.film_id == id).Count() != 0)
                //if (new ManagerSeance().GetAllSeance().Count() != 0)
                //    throw new MovieUsedInSeanceException();
                if (manager.DeleteFilm(id))
                    return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index(string titre, int? yearMin, int? yearMax, int? id_type)
        {
            try
            {
                ManagerFilm manager = new ManagerFilm();
                ViewBag.id_type = new SelectList(new ManagerTypeFilm().GetAllType_film(), "id", "typage");
                return View(manager.GetFilmFiltre(titre, yearMin, yearMax, id_type));
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index", "Home");
            }
        }


        protected override void Dispose(bool disposing)
        {

        }
    }
}

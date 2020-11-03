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
        public ActionResult Index()
        {
            try
            {
                //MovieService movieService = new MovieService();
                //return View(movieService.GetMovies());
                ManagerFilm manager = new ManagerFilm();
                return View(manager.GetAllFilmsFrom(DateTime.Now.Year -10));
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index", "Home");
            }
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
        public ActionResult Create([Bind(Include = "id,titre,description,annee_parution,duree,rating,revenu,ranking,votes,metascore")] film film)
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
            return View(film);
        }

        // GET: films/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: films/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titre,description,annee_parution,duree,rating,revenu,ranking,votes,metascore")] film film)
        {
            try
            {
                ManagerFilm manager = new ManagerFilm();

                if (ModelState.IsValid)
                {
                    if (manager.PutFilm(film))
                        return RedirectToAction("Index");
                }
                else
                    throw new InvalidItemException("film");
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

        protected override void Dispose(bool disposing)
        {

        }
    }
}

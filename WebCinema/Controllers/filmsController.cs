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
using ModelCinema.Models;
using ModelCinema.Models.DataManager;
using ModelCinema.Service;

namespace WebCinema.Controllers
{
    public class filmsController : Controller
    {
        //private cinema_dbEntities db = new cinema_dbEntities();

        public ActionResult Index()
        {
            MovieService movieService = new MovieService();
            return View(movieService.GetMovies());
        }
        public ActionResult FlushMovies()
        {
            MovieService movieService = new MovieService();
            movieService.FlushMovies();
            return RedirectToAction("Index");
        }

        public ActionResult UploadMovies()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UploadMovies(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    //Console.WriteLine(Path.GetFileName(file.FileName));
                    MovieService movieService = new MovieService();
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/App_Data/UploadedFiles"), _FileName);

                    file.SaveAs(_path);

                    if (!string.IsNullOrEmpty(_path))
                    {
                        movieService.ImportCSV(_path);
                        if (System.IO.File.Exists(_path))
                        {
                            System.IO.File.Delete(_path);
                        }
                    }
                }
                ViewBag.Message = "Fichier importé avec succès!";
                return View();
                //return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "L'importation du fichier a échoué!";
                return View();
            }
        }





        // GET: films
        //public ActionResult Index()
        //{
        //    ManagerFilm manager = new ManagerFilm();
        //    return View(manager.GetAllFilms());
        //}

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
                try
                {
                    if (manager.PostFilm(film))
                        return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
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
                try
                {
                    if (manager.PutFilm(film))
                        return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
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
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

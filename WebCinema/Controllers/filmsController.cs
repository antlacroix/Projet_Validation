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
using ModelCinema.Service;

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
                return View(manager.GetAllFilms());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return RedirectToAction("Index", "Home");
            }
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
                MessageBox.Show(e.Message);
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
                MessageBox.Show(e.Message);
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
                MessageBox.Show(e.Message);
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
                MessageBox.Show(e.Message);
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
                MessageBox.Show(e.Message);
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
                MessageBox.Show(e.Message);
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
                if (manager.DeleteFilm(id))
                    return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {

        }
    }
}

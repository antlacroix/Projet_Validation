﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using ModelCinema.Models;
using ModelCinema.Models.DataManager;

namespace WebCinema.Controllers
{
    public class seancesController : Controller
    {
        //private cinema_dbEntities db = new cinema_dbEntities();

        [HttpPost]
        protected void Filtre(object sender, EventArgs e)
        {
            RedirectToAction("Index");
        }
        #region
        //public List<seance> GetScheduleData()
        //{
        //    List<seance> appData = new List<seance>();
        //    appData.Add(new seance
        //    {
        //        Id = 1,
        //        Subject = "Explosion of Betelgeuse Star",
        //        StartTime = new DateTime(2020, 2, 11, 9, 30, 0),
        //        EndTime = new DateTime(2020, 2, 11, 11, 0, 0),

        //        IsAllDay = false,
        //        CinemaId = 1,
        //        SalleId = 1
        //    }) ;
        //    appData.Add(new seance
        //    {
        //        Id = 2,
        //        Subject = "Thule Air Crash Report",
        //        StartTime = new DateTime(2020, 2, 12, 12, 0, 0),
        //        EndTime = new DateTime(2020, 2, 12, 14, 0, 0),

        //        IsAllDay = false,
        //        CinemaId = 1,
        //        SalleId = 2
        //    });
        //    appData.Add(new seance
        //    {
        //        Id = 3,
        //        Subject = "Blue Moon Eclipse",
        //        StartTime = new DateTime(2020, 2, 13, 9, 30, 0),
        //        EndTime = new DateTime(2020, 2, 13, 11, 0, 0),

        //        IsAllDay = false,
        //        CinemaId = 2,
        //        SalleId = 1
        //    });
        //    appData.Add(new seance
        //    {
        //        Id = 4,
        //        Subject = "Meteor Showers in 2018",
        //        StartTime = new DateTime(2020, 2, 14, 13, 0, 0),
        //        EndTime = new DateTime(2020, 2, 14, 14, 30, 0),

        //        IsAllDay = false,
        //        CinemaId = 2,
        //        SalleId = 2
        //    });
        //    appData.Add(new seance
        //    {
        //        Id = 5,
        //        Subject = "Milky Way as Melting pot",
        //        StartTime = new DateTime(2020, 2, 15, 12, 0, 0),
        //        EndTime = new DateTime(2020, 2, 15, 14, 0, 0),

        //        IsAllDay = false,
        //        CinemaId = 2,
        //        SalleId = 1
        //    });
        //    return appData;
        //}
        #endregion

        [HttpPost]
        public ActionResult Reccurance(int id, string recurrance, int nbrRecurrance)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                manager.RecurranceSeances(id, recurrance, nbrRecurrance);
                return RedirectToAction("Index", "Home"); 
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

            //public ActionResult Index(int id, string recurrance, int nbrRecurrance)
            //{
            //    try
            //    {
            //        ManagerFilm manager = new ManagerFilm();
            //        return View(manager.GetFilmFiltre(id, recurrance, nbrRecurrance));
            //    }
            //    catch (Exception e)
            //    {
            //        TempData.Add("Alert", e.Message);
            //        return RedirectToAction("Index", "Home");
            //    }
            //}

            // GET: seances
            public ActionResult Index(int id, DateTime? start, DateTime? end)
        {
            #region
            //ManagerCinema managerCinema = new ManagerCinema();
            //ManagerSalle managerSalle = new ManagerSalle();
            //ManagerFilm managerFilm = new ManagerFilm();

            //ViewBag.appointments = managerSeance.GetAllSeance();

            //ViewBag.Film = managerFilm.GetAllFilms();

            //ViewBag.Cinema = managerCinema.GetAllCinema();

            //ViewBag.Salle = managerSalle.GetAllSalle();

            //ViewBag.Resources = new string[] { "Cinema", "Salle" };
            #endregion
            try
            {
                ManagerSeance managerSeance = new ManagerSeance();

                ViewBag.start = start;
                ViewBag.end = end;
                if (start != null || end != null)
                {
                    var orders = managerSeance.GetAllSeanceFromCinema(id)
                        .Where(x => x.date_debut > start
                        && x.date_fin < end)
                        .ToList();
                    return View(orders);
                }
                else
                {
                    var orders = managerSeance.GetAllSeanceFromCinema(id);
                    return View(orders);
                } 
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Filtre([Bind(Include = "id,date_debut,date_fin,titre_seance,salle_id,film_id")] seance seance)
        {
            try
            {
      
                return View(seance);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(FormCollection form)
        //{

        //    int id = int.Parse(form["cinemas"].ToString());
        //    return RedirectToAction("Create", new { id = id });

        //}

        // GET: seances/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                seance seance = manager.GetSeance(id);
                ViewBag.id_film = new SelectList(new ManagerFilm().GetAllFilms(), "id", "titre");
                return View(seance);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: seances/Create
        public ActionResult Create(int? id)
        {
            try
            {
                //if (id != null)
                //    ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle().Where(S => S == id), "id", "commentaire");
                //else
                //ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle(), "id", "commentaire");
                ViewBag.film_id = new SelectList(new ManagerFilm().GetAllFilmsFrom(null), "id", "titre");
                return View();
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
            }

        }

        // POST: seances/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date_debut,date_fin,titre_seance,salle_id,film_id,id_film")] seance seance)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                if (ModelState.IsValid)
                {
                    if (manager.PostSeance(seance))
                        return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
                }
                ViewBag.film_id = new SelectList(new ManagerFilm().GetAllFilmsFrom(null), "id", "titre");
                //ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle(), "id", "commentaire");
                return View(seance);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
            }
        }

        // GET: seances/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                seance seance = manager.GetSeance(id);
                //ViewBag.film_id = new SelectList(new ManagerFilm().GetAllFilmsFrom(null), "id", "titre", seance.film_id);
                ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle().Where(s => s.cinema_id == int.Parse(Session[SessionKeys.cinemaId].ToString())), "id", "numero_salle", seance.salle_id);
                return View(seance);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: seances/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date_debut,date_fin,titre_seance,salle_id,film_id")] seance seance)
        {
            try
            {
                ManagerSeance managerSeance = new ManagerSeance();

                if (ModelState.IsValid)
                {
                    if (managerSeance.PutSeance(seance))
                        return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
                }
                //ViewBag.film_id = new SelectList(new ManagerFilm().GetAllFilmsFrom(null), "id", "titre", seance.film_id);
                ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle().Where(s => s.cinema_id == int.Parse(Session[SessionKeys.cinemaId].ToString())), "id", "numero_salle", seance.salle_id);
                return View(seance);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
            }
        }

        // GET: seances/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                seance seance = manager.GetSeance(id);
                return View(seance);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
            }
        }

        // POST: seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                seance seance = manager.GetSeance(id);
                if (manager.DeleteSeance(id))
                    return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
                else
                    throw new Exception();
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
            }
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //ManagerSeance manager = new ManagerSeance();
            //manager.Dispose();
            //}

            ////base.Dispose(disposing);

            ////if (disposing)
            ////{
            ////    db.Dispose();
            ////}
            ////base.Dispose(disposing);
        }

        public ActionResult BackToSalle(int id)
        {
            return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
        }
    }
}

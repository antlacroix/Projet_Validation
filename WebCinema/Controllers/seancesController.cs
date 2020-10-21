﻿using System;
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
    public class seancesController : Controller
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<seance> GetScheduleData()
        {
            List<seance> appData = new List<seance>();
            appData.Add(new seance
            {
                Id = 1,
                Subject = "Explosion of Betelgeuse Star",
                StartTime = new DateTime(2018, 2, 11, 9, 30, 0),
                EndTime = new DateTime(2018, 2, 11, 11, 0, 0)
            });
            appData.Add(new seance
            {
                Id = 2,
                Subject = "Thule Air Crash Report",
                StartTime = new DateTime(2018, 2, 12, 12, 0, 0),
                EndTime = new DateTime(2018, 2, 12, 14, 0, 0)
            });
            appData.Add(new seance
            {
                Id = 3,
                Subject = "Blue Moon Eclipse",
                StartTime = new DateTime(2018, 2, 13, 9, 30, 0),
                EndTime = new DateTime(2018, 2, 13, 11, 0, 0)
            });
            appData.Add(new seance
            {
                Id = 4,
                Subject = "Meteor Showers in 2018",
                StartTime = new DateTime(2018, 2, 14, 13, 0, 0),
                EndTime = new DateTime(2018, 2, 14, 14, 30, 0)
            });
            appData.Add(new seance
            {
                Id = 5,
                Subject = "Milky Way as Melting pot",
                StartTime = new DateTime(2018, 2, 15, 12, 0, 0),
                EndTime = new DateTime(2018, 2, 15, 14, 0, 0)
            });
            return appData;
        }


        // GET: seances
        public ActionResult Index()
        {
            ManagerSeance manager = new ManagerSeance();
			ViewBag.appointments = GetScheduleData();
            //var seances = db.seances.Include(s => s.film).Include(s => s.salle);
            return View(manager.GetAllSeance());
        }

        // GET: seances/Details/5
        public ActionResult Details(int? id)
        {
            ManagerSeance manager = new ManagerSeance();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seance seance = manager.GetSeance(id);
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
            ManagerSeance manager = new ManagerSeance();
            if (ModelState.IsValid)
            {
                if(manager.PostSeance(seance))
                    return RedirectToAction("Index");
                // TODO
                //Implementer un message d'erreur
            }

            ViewBag.film_id = new SelectList(db.films, "id", "titre", seance.film_id);
            ViewBag.salle_id = new SelectList(db.salles, "id", "commentaire", seance.salle_id);
            return View(seance);
        }

        // GET: seances/Edit/5
        public ActionResult Edit(int? id)
        {
            ManagerSeance manager = new ManagerSeance();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seance seance = manager.GetSeance(id);
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
            ManagerSeance manager = new ManagerSeance();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seance seance = manager.GetSeance(id);
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
            ManagerSeance manager = new ManagerSeance();
            if(manager.DeleteSeance(id))
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

    //public class AppointmentData
    //{
    //    private seance s1 = new seance() { id = 1, date_debut = DateTime.Now, date_fin = DateTime.Now.AddMinutes(30), titre_seance = "test S1" };
    //    public int Id { get; set; }
    //    public string Subject { get; set; }
    //    public DateTime StartTime { get { return s1.date_debut; } set { s1.date_debut = value; } }
    //    public DateTime EndTime { get { return s1.date_fin; } set { s1.date_fin = value; } }

    //}
}

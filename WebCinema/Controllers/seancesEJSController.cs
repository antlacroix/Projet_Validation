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
    public class seancesEJSController : Controller
    {

        protected void btnSave(object sender, EventArgs e)
        {
            // Sauvgardé les modif et nouveau séence
        }
        #region
        public List<seance> GetScheduleData()
        {
            List<seance> appData = new List<seance>();
            appData.Add(new seance
            {
                id = 1,
                titre_seance = "Explosion of Betelgeuse Star",
                date_debut = new DateTime(2020, 2, 11, 9, 30, 0),
                date_fin = new DateTime(2020, 2, 11, 11, 0, 0),

                //IsAllDay = false,
                //CinemaId = 1,
                salle_id = 1
            });
            appData.Add(new seance
            {
                id = 2,
                titre_seance = "Thule Air Crash Report",
                date_debut = new DateTime(2020, 2, 12, 12, 0, 0),
                date_fin = new DateTime(2020, 2, 12, 14, 0, 0),

                //IsAllDay = false,
                //CinemaId = 1,
                salle_id = 2
            });
            appData.Add(new seance
            {
                id = 3,
                titre_seance = "Blue Moon Eclipse",
                date_debut = new DateTime(2020, 2, 13, 9, 30, 0),
                date_fin = new DateTime(2020, 2, 13, 11, 0, 0),

                //IsAllDay = false,
                //CinemaId = 2,
                salle_id = 1
            });
            appData.Add(new seance
            {
                id = 4,
                titre_seance = "Meteor Showers in 2018",
                date_debut = new DateTime(2020, 2, 14, 13, 0, 0),
                date_fin = new DateTime(2020, 2, 14, 14, 30, 0),

                //IsAllDay = false,
                //CinemaId = 2,
                salle_id = 2
            });
            appData.Add(new seance
            {
                id = 5,
                titre_seance = "Milky Way as Melting pot",
                date_debut = new DateTime(2020, 2, 15, 12, 0, 0),
                date_fin = new DateTime(2020, 2, 15, 14, 0, 0),

                //IsAllDay = false,
                //CinemaId = 2,
                salle_id = 1
            });
            return appData;
        }
        #endregion


        // GET: seancesEJS
        public ActionResult Index()
        {
            ManagerCinema managerCinema = new ManagerCinema();
            ManagerSalle managerSalle = new ManagerSalle();
            ManagerFilm managerFilm = new ManagerFilm();
            ManagerSeance managerSeance = new ManagerSeance();

            ViewBag.appointments = managerSeance.GetAllSeance();

            ViewBag.Film = managerFilm.GetAllFilms();

            ViewBag.Cinema = managerCinema.GetAllCinema();

            ViewBag.Salle = managerSalle.GetAllSalle();

            ViewBag.Resources = new string[] { "Cinema", "Salle" };

            return View(managerSeance.GetAllSeance());
        }

        // GET: seancesEJS/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                seance seance = manager.GetSeance(id);
                return View(seance);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: seancesEJS/Create
        public ActionResult Create(int? id)
        {
            try
            {
                if (id != null)
                    ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle().Where(S => S.cinema_id == id), "id", "commentaire");
                else
                    ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle(), "id", "commentaire");
                ViewBag.film_id = new SelectList(new ManagerFilm().GetAllFilms(), "id", "titre");
                return View();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return RedirectToAction("Index", new { id = id });
            }

        }

        // POST: seancesEJS/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date_debut,date_fin,titre_seance,salle_id,film_id")] seance seance)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                if (ModelState.IsValid)
                {
                    if (manager.PostSeance(seance))
                        return RedirectToAction("Index", new { id = seance.salle.cinema_id });
                }
                ViewBag.film_id = new SelectList(new ManagerFilm().GetAllFilms(), "id", "titre");
                ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle(), "id", "commentaire");
                return View(seance);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return RedirectToAction("Index", "seance", new { id = seance.salle.cinema_id });
            }
        }


        // GET: seancesEJS/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                seance seance = manager.GetSeance(id);
                ViewBag.film_id = new SelectList(new ManagerFilm().GetAllFilms(), "id", "titre", seance.film_id);
                ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle(), "id", "id", seance.salle_id);
                return View(seance);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: seancesEJS/Edit/5
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
                        return RedirectToAction("Index", new { id = seance.salle.cinema_id });
                }
                ViewBag.film_id = new SelectList(new ManagerFilm().GetAllFilms(), "id", "titre", seance.film_id);
                ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle(), "id", "commentaire", seance.salle_id);
                return View(seance);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return RedirectToAction("Index", new { id = seance.salle.cinema_id });
            }
        }

        // GET: seancesEJS/Delete/5
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
                //MessageBox.Show(e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: seancesEJS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                seance seance = manager.GetSeance(id);
                if (manager.DeleteSeance(id))
                    return RedirectToAction("Index", new { id = seance.salle.cinema_id });
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            return RedirectToAction("Index", "Home");
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
    }
}

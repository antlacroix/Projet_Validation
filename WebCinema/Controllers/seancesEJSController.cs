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
                Id = 1,
                Subject = "Explosion of Betelgeuse Star",
                StartTime = new DateTime(2020, 2, 11, 9, 30, 0),
                EndTime = new DateTime(2020, 2, 11, 11, 0, 0),

                //IsAllDay = false,
                salle_id = 18
            });
            appData.Add(new seance
            {
                Id = 2,
                Subject = "Thule Air Crash Report",
                StartTime = new DateTime(2020, 2, 12, 12, 0, 0),
                EndTime = new DateTime(2020, 2, 12, 14, 0, 0),

                //IsAllDay = false,
                salle_id = 18
            });
            appData.Add(new seance
            {
                Id = 3,
                Subject = "Blue Moon Eclipse",
                StartTime = new DateTime(2020, 2, 13, 9, 30, 0),
                EndTime = new DateTime(2020, 2, 13, 11, 0, 0),

                //IsAllDay = false,
                salle_id = 19
            });
            appData.Add(new seance
            {
                Id = 4,
                Subject = "Meteor Showers in 2018",
                StartTime = new DateTime(2020, 2, 14, 13, 0, 0),
                EndTime = new DateTime(2020, 2, 14, 14, 30, 0),

                //IsAllDay = false,
                salle_id = 19
            });
            appData.Add(new seance
            {
                Id = 5,
                Subject = "Milky Way as Melting pot",
                StartTime = new DateTime(2020, 2, 15, 12, 0, 0),
                EndTime = new DateTime(2020, 2, 15, 14, 0, 0),

                //IsAllDay = false,
                salle_id = 19
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

            List<seance> listeSeance = managerSeance.GetAllSeanceFrom(new DateTime(2020,10,30));
            listeSeance.ForEach(x => x.salle.cinema.salles.Clear());
            listeSeance.ForEach(x => x.salle.salle_status.salles.Clear());

            listeSeance.ForEach(x => x.salle.seances.Clear());

            listeSeance.ForEach(x => x.salle.cinema.contact_info.cinemas.Clear());
            listeSeance.ForEach(x => x.salle.cinema.user.contact_info.users.Clear());
            listeSeance.ForEach(x => x.salle.cinema.user.cinemas.Clear());
            listeSeance.ForEach(x => x.salle.cinema.user.user_status.users.Clear());
            listeSeance.ForEach(x => x.salle.cinema.user.user_type.users.Clear());


            ViewBag.appointments = managerSeance.GetAllSeanceFrom(new DateTime(2020, 10, 30));
            //ViewBag.appointments = GetScheduleData();

            ViewBag.Film = managerFilm.GetAllFilms();

            List<cinema> listeCinema = managerCinema.GetAllCinema();
            listeCinema.ForEach(x => x.salles.Clear());
            listeCinema.ForEach(x => x.contact_info = null);
            listeCinema.ForEach(x => x.contact_info_id = 0);
            listeCinema.ForEach(x => x.user = null);
            listeCinema.ForEach(x => x.responsable_user_id = 0);

            ViewBag.Cinema = listeCinema;
            //ViewBag.Cinema = managerCinema.GetAllCinema();

            List<salle> listeSalle = managerSalle.GetAllSalle();
            listeSalle.ForEach(x => x.salle_status.salles.Clear());
            listeSalle.ForEach(x => x.seances.Clear());
            listeSalle.ForEach(x => x.cinema.salles.Clear());
            listeSalle.ForEach(x => x.cinema.contact_info = null);
            listeSalle.ForEach(x => x.cinema.contact_info_id = 0);
            listeSalle.ForEach(x => x.cinema.user = null);
            listeSalle.ForEach(x => x.cinema.responsable_user_id = 0);
            ViewBag.Salle = listeSalle;
            //ViewBag.Salle = managerSalle.GetAllSalle();


            ViewBag.Resources = new string[] { "Cinema", "Salle" };

            return View(managerSeance.GetAllSeanceFrom(new DateTime(2020, 10, 30)));
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

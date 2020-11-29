using System;
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
        //Get methode        

        [HttpPost]
        public ActionResult Reccurance(int id, string recurrance, int nbrRecurrance, string[] dayToRepeat)
        {
            try
            {
                List<int> ids = new List<int>();
                List<programmation> progs = new ManagerProgrammation().GetAllprogramtionFromSeance(id);
                new ManagerSeance().RecurranceSeances(id, recurrance, nbrRecurrance, dayToRepeat, ref ids);
                new ManagerProgrammation().PostManyProgs(progs, ref ids);
                if (Session["isOnRoom"] as int? == 0)
                    return RedirectToAction("Edit", "seances", new { id = id });
                else
                    return RedirectToAction("DetailsSalle", "cinemas", new { id = Session[SessionKeys.salleId] as int?, start = DateTime.Now });
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                if (Session["isOnRoom"] as int? == 0)
                    return RedirectToAction("Edit", "seances", new { id = id });
                else
                    return RedirectToAction("DetailsSalle", "cinemas", new { id = Session[SessionKeys.salleId] as int?, start = DateTime.Now });
            }
        }

        // GET: seances
        public ActionResult Index(int id, DateTime? start, DateTime? end)
        {
            try
            {
                ManagerSeance managerSeance = new ManagerSeance();

                if (Session[SessionKeys.startDate] != null)
                    start = Session[SessionKeys.startDate] as DateTime?;
                ViewBag.start = start;

                if (Session[SessionKeys.endDate] != null)
                    end = Session[SessionKeys.endDate] as DateTime?;
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
        // GET: seances/Details/5
        public ActionResult Details(int? id)
        {
            Session[SessionKeys.seanceId] = id;
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
                List<SelectListItem> tempList = new List<SelectListItem>();
                foreach (film item in new ManagerFilm().GetAllFilmsFrom(null))
                {
                    tempList.Add(new SelectListItem() { Value = item.id.ToString(), Text = item.titre });
                }
                ViewBag.film_id = new SelectList(tempList, "Value", "Text");
                return View();
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("alert", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
            }
        }
        // GET: seances/Edit/5
        public ActionResult Edit(int? id, string titre, int? yearMin, int? yearMax, int? id_type)
        {

            Session["isOnRoom"] = 0;
            Session[SessionKeys.seanceId] = id;
            try
            {
                ManagerSeance manager = new ManagerSeance();
                seance seance = manager.GetSeance(id);
                ViewBag.id_type = new SelectList(new ManagerTypeFilm().GetAllType_film(), "id", "typage");
                ViewBag.films_id = new SelectList(new ManagerFilm().GetFilmFiltre(titre, yearMin, yearMax, id_type), "id", "titre");
                ViewBag.filmsFiltred = new List<film>(new ManagerFilm().GetFilmFiltre(titre, yearMin, yearMax, id_type).OrderBy(x => x.titre));
                ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle().Where(s => s.cinema_id == int.Parse(Session[SessionKeys.cinemaId].ToString())), "id", "numero_salle", seance.salle_id);
                return View(seance);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index", "Home");
            }
        }
        // GET: seances/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                seance seance = manager.GetSeance(id);
                return PartialView("PartialDeleteSeance", seance);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = Session[SessionKeys.salleId] as int?, start = DateTime.Now });
            }
        }

        //Post method
        #region
        // POST: seances/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date_debut,date_fin,titre_seance,salle_id,film_id,id_film")] seance seance,
            string datePickerStart, string timePickerStart, string datePickerFin, string timePickerfin)
        {

            string
                startString = datePickerStart + " " + timePickerStart,
                endString = datePickerFin + " " + timePickerfin;
            seance.date_debut = DateTime.Parse(startString);
            seance.date_fin = DateTime.Parse(endString);

            try
            {
                ManagerSeance manager = new ManagerSeance();
                if (ModelState.IsValid)
                {
                    if (manager.PostSeance(seance))
                        return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()), start = DateTime.Now });
                }
                ViewBag.film_id = new SelectList(new ManagerFilm().GetAllFilmsFrom(null), "id", "titre");
                return View(seance);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()), start = DateTime.Now });
            }
        }
        // POST: seances/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date_debut,date_fin,titre_seance,salle_id,film_id")] seance seance,
            string command, string titre, int? yearMin, int? yearMax, int? id_type,
            string datePickerStart, string timePickerStart, string datePickerFin, string timePickerfin)
        {
            string
                startString = datePickerStart + " " + timePickerStart,
                endString = datePickerFin + " " + timePickerfin;


            if (command == "Filtre")
                return RedirectToAction("Edit", new { titre = titre, yearMin = yearMin, yearMax = yearMax, id_type = id_type });
            else if (command == "addFilm")
            {
                return RedirectToAction("Edit", new { titre = titre, yearMin = yearMin, yearMax = yearMax, id_type = id_type });
            }

            seance.date_debut = DateTime.Parse(startString);
            seance.date_fin = DateTime.Parse(endString);


            try
            {
                ManagerSeance managerSeance = new ManagerSeance();

                if (ModelState.IsValid)
                {
                    if (managerSeance.PutSeance(seance))
                        return RedirectToAction("Edit", new { titre = titre, yearMin = yearMin, yearMax = yearMax, id_type = id_type });
                }
                ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle().Where(s => s.cinema_id == int.Parse(Session[SessionKeys.cinemaId].ToString())), "id", "numero_salle", seance.salle_id);
                return RedirectToAction("Edit", new { titre = titre, yearMin = yearMin, yearMax = yearMax, id_type = id_type });
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Edit", seance);
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
                    return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()), start = DateTime.Now });
                else
                    throw new Exception();
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                Session[SessionKeys.seanceId] = id;
                Session[SessionKeys.seanceTab] = "Delete";
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()), start = DateTime.Now });
            }
        }

        #endregion

        //Navigation Action
        #region
        public ActionResult BackToSalle(int id)
        {
            return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()), start = DateTime.Now });
        }
        #endregion

        public ActionResult getRepeat(int id)
        {
            try
            {
                seance s = new ManagerSeance().GetSeance(id);
                return PartialView("PartialRepeatSession", s);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()), start = DateTime.Now });
            }
        }

        public ActionResult CreateProgrammation(int? id, int seanceId)
        {
            try
            {
                programmation p = new programmation()
                {
                    id_film = id,
                    id_seance = int.Parse(Session[SessionKeys.seanceId].ToString())
                };
                ManagerProgrammation manager = new ManagerProgrammation();
                manager.PostProgrammation(p);
                return RedirectToAction("Edit", new { id = int.Parse(Session[SessionKeys.seanceId].ToString()) });
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Edit", new { id = int.Parse(Session[SessionKeys.seanceId].ToString()) });
            }
        }

        public ActionResult RemoveProgrammation(int id, int seanceId)
        {
            try
            {
                ManagerProgrammation manager = new ManagerProgrammation();
                manager.DeleteProgrammation(id);
                return RedirectToAction("Edit", new { id = seanceId });
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Details");
            }
        }

        public ActionResult MakePrimary(int id, int seanceId)
        {
            try
            {
                ManagerProgrammation manager = new ManagerProgrammation();
                if (manager.MakePrimary(id))
                    return RedirectToAction("Edit", new { id = int.Parse(Session[SessionKeys.seanceId].ToString()) });
                else
                    throw new Exception("echec de lopperation");
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Details");
            }
        }
    }
}

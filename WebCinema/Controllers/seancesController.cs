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
        public ActionResult Reccurance(int id, string recurrance, int nbrRecurrance)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                manager.RecurranceSeances(id, recurrance, nbrRecurrance);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString())});
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
            }
        }

        // GET: seances
        public ActionResult Index(int id, DateTime? start, DateTime? end)
        {
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
                return View(seance);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
            }
        }

        //Post method
        #region
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
                return View(seance);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
            }
        }
        // POST: seances/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date_debut,date_fin,titre_seance,salle_id,film_id")] seance seance, string command, string titre, int? yearMin, int? yearMax, int? id_type)
        {
            if (command == "Filtre")
                return RedirectToAction("Edit", new { titre = titre, yearMin = yearMin, yearMax = yearMax, id_type = id_type });
            else if (command == "addFilm")
                return RedirectToAction("Edit", new { titre = titre, yearMin = yearMin, yearMax = yearMax, id_type = id_type });


            try
            {
                ManagerSeance managerSeance = new ManagerSeance();

                if (ModelState.IsValid)
                {
                    if (managerSeance.PutSeance(seance))
                        return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
                }
                ViewBag.salle_id = new SelectList(new ManagerSalle().GetAllSalle().Where(s => s.cinema_id == int.Parse(Session[SessionKeys.cinemaId].ToString())), "id", "numero_salle", seance.salle_id);
                return RedirectToAction("Edit", new { titre = titre, yearMin = yearMin, yearMax = yearMax, id_type = id_type });
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

        #endregion

        //Navigation Action
        #region
        public ActionResult BackToSalle(int id)
        {
            return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
        }
        #endregion
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

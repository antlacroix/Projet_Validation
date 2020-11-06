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

        protected void btnSave(object sender, EventArgs e)
        {
            // Sauvgardé les modif et nouveau séence
        }

        // GET: seances
        public ActionResult Index(int id)
        {
            try
            {
                ManagerSeance managerSeance = new ManagerSeance();
                return View(managerSeance.GetAllSeanceFromCinema(id));
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
            try
            {
                ManagerSeance manager = new ManagerSeance();
                seance seance = manager.GetSeance(id);
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
                ViewBag.film_id = new SelectList(tempList,"Value", "Text");
                return View();
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAndAddSeance([Bind(Include = "id,date_debut,date_fin,titre_seance,salle_id,film_id")] seance seance)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                if (ModelState.IsValid)
                {
                    if (manager.PostSeance(seance))
                    {
                        ViewBag.film_id = new SelectList(new ManagerFilm().GetAllFilmsFrom(null), "id", "titre");
                        return RedirectToAction("AddSeance", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
                    }
                }
                return View(seance);
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
        public ActionResult Create([Bind(Include = "id,date_debut,date_fin,titre_seance,salle_id,film_id")] seance seance)
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

        // GET: seances/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                ManagerSeance manager = new ManagerSeance();
                seance seance = manager.GetSeance(id);
                ViewBag.films_id = new SelectList(new ManagerFilm().GetAllFilmsFromTo(1995, 2020), "id", "titre");
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


        public ActionResult BackToSalle(int id)
        {
            return RedirectToAction("DetailsSalle", "cinemas", new { id = int.Parse(Session[SessionKeys.salleId].ToString()) });
        }

        private bool CreateProgrammation(programmation programmation)
        {
            try
            {
                ManagerProgrammation manager = new ManagerProgrammation();
                manager.PostProgrammation(programmation);
                return true;
            }
            catch(Exception e)
            {
                TempData.Add("Alert", e.Message);
                return false;
            }
        }

        private bool EditProgramation(programmation programmation)
        {
            try
            {
                ManagerProgrammation manager = new ManagerProgrammation();
                manager.PutProgrammation(programmation);
                return true;
            }
            catch(Exception e)
            {
                TempData.Add("Alert", e.Message);
                return false;
            }
        }

        private bool DeleteProgramation(int idProgrammation)
        {
            try
            {
                ManagerProgrammation manager = new ManagerProgrammation();
                manager.DeleteProgrammation(idProgrammation);
                return true;
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return false;
            }
        }

        
    }
}

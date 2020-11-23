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
    public class cinemasController : Controller
    {
        [HttpPost]
        public ActionResult Filtre(DateTime? startDate, DateTime? endDate)
        {
            return RedirectToAction("DetailsSalle", new { start = startDate, end = endDate, id = int.Parse(Session[SessionKeys.salleId].ToString())});
        }

        // GET: cinemas
        public ActionResult Index()
        {
            Session.Remove(SessionKeys.cinemaId);
            try
            {
                ManagerCinema manager = new ManagerCinema();
                return View(manager.GetAllCinema());
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: cinemas/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                Session.Remove(SessionKeys.salleId);
                Session[SessionKeys.cinemaId] = id;
                ManagerCinema manager = new ManagerCinema();
                cinema cinema = manager.GetCinema(id);
                return View(cinema);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index");
            }
        }

        // GET: cinemas/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "adresse");
                ViewBag.responsable_user_id = new SelectList(new ManagerUser().GetAllUser(), "id", "name");
                return View();
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index");
            }
        }

        // POST: cinemas/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cinema_name,contact_info_id,responsable_user_id")] cinema cinema)
        {
            try
            {
                ManagerCinema manager = new ManagerCinema();
                if (ModelState.IsValid)
                {
                    if (manager.PostCinema(cinema))
                        return RedirectToAction("Index");
                }

                ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "adresse");
                ViewBag.responsable_user_id = new SelectList(new ManagerUser().GetAllUser(), "id", "name");
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
            }
            return View(cinema);
        }


        // GET: cinemas/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                ManagerCinema manager = new ManagerCinema();
                cinema cinema = manager.GetCinema(id);

                ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "adresse");
                ViewBag.responsable_user_id = new SelectList(new ManagerUser().GetAllUser(), "id", "name");

                return View(cinema);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index");
            }

        }

        // POST: cinemas/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cinema_name,contact_info_id,responsable_user_id")] cinema cinema)
        {
            try
            {
                ManagerCinema manager = new ManagerCinema();
                if (ModelState.IsValid)
                {
                    if (manager.PutCinema(cinema))
                        return RedirectToAction("Index");
                }
                ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "adresse");
                ViewBag.responsable_user_id = new SelectList(new ManagerUser().GetAllUser(), "id", "name");

                return View(cinema);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return View(cinema);
            }
        }

        // GET: cinemas/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                ManagerCinema manager = new ManagerCinema();
                cinema cinema = manager.GetCinema(id);
                return View(cinema);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index");
            }
        }

        // POST: cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ManagerCinema manager = new ManagerCinema();
                if (manager.DeleteCinema(id))
                    return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
            }
            return View(id);
        }

        protected override void Dispose(bool disposing)
        {

        }

        //GET: cinemas/CreateSalle
        public ActionResult CreateSalle(int id)
        {
            try
            {
                ManagerSalleStatus manager = new ManagerSalleStatus();
                Session["cineId"] = id;
                ViewBag.status_id = new SelectList(manager.GetAllSalleStatus(), "id", "status", manager.GetSalleStatus(2));
                return View();
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Details", new { id = id });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSalle([Bind(Include = "id, nbr_place, numero_salle, commentaire, status_id, cinema_id")] salle salle)
        {
            try
            {
                ManagerSalle manager = new ManagerSalle();
                salle.cinema_id = int.Parse(Session["cineId"].ToString());
                if (ModelState.IsValid)
                {
                    if (manager.PostSalle(salle))
                        return RedirectToAction("Details", new { id = salle.cinema_id });
                }
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
            }
            ViewBag.status_id = new SelectList(new ManagerSalleStatus().GetAllSalleStatus(), "id", "status", new ManagerSalleStatus().GetSalleStatus(2));
            return View(salle);
        }

        //GET: cinemas/DetailsSalle/5
        public ActionResult DetailsSalle(int? id, DateTime? start, DateTime? end)
        {
            Session[SessionKeys.salleId] = id;
            try
            {
                ManagerSalle manager = new ManagerSalle();
                salle salle = manager.GetSalle(id, start, end);
                return View(salle);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Details", new { id = id });
            }
        }

        //Get: cinemas/EditSalle/5
        public ActionResult EditSalle(int? id)
        {
            try
            {
                ManagerSalle manager = new ManagerSalle();
                salle salle = manager.GetSalle(id, null, null);
                ViewBag.status_id = new SelectList(new ManagerSalleStatus().GetAllSalleStatus(), "id", "status", salle.status_id);
                return View(salle);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Details", new { id = id });
            }
        }

        //Post cinemas/EditSalle5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSalle([Bind(Include = "id,nbr_place,numero_salle,commentaire,status_id,cinema_id")] salle salle)
        {
            try
            {
                ManagerSalle manager = new ManagerSalle();
                if (ModelState.IsValid)
                {
                    manager.PutSalle(salle);
                    return RedirectToAction("Details", new { id = salle.cinema_id });
                }
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
            }
            ViewBag.status_id = new SelectList(new ManagerSalleStatus().GetAllSalleStatus(), "id", "status", salle.status_id);
            return View(salle);
        }


        //Get: cinemas/DeleteSalle/5
        public ActionResult DeleteSalle(int? id)
        {
            try
            {
                ManagerSalle manager = new ManagerSalle();
                salle salle = manager.GetSalle(id, null, null);
                return View(salle);
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Details", new { id = id });
            }
        }

        //POST: cinemas/DeleteSalle/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSalle(int id)
        {
            try
            {
                ManagerSalle manager = new ManagerSalle();
                int cineId = manager.GetSalle(id, null, null).cinema_id;
                if (manager.DeleteSalles(id))
                    return RedirectToAction("Details", new { id = cineId });
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
            }
            return RedirectToAction("DeleteSalle", new { id = id });
        }

        public ActionResult CreateSeance()
        {
            return RedirectToAction("Create", "seances", new { id = Session[SessionKeys.salleId] });
        }

        public ActionResult EditSeance(int id)
        {
            return RedirectToAction("Edit", "seances", new { id = id });
        }

        public ActionResult DetailsSeance(int id)
        {
            return RedirectToAction("Details", "seances", new { id = id });
        }

        public ActionResult DeleteSeance(int id)
        {
            return RedirectToAction("Delete", "seances", new { id = id });
        }
    }
}

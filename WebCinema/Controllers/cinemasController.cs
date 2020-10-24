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
        //private cinema_dbEntities db = new cinema_dbEntities();

        // GET: cinemas
        public ActionResult Index()
        {
            ManagerCinema manager = new ManagerCinema();
            return View(manager.GetAllCinema());
        }

        // GET: cinemas/Details/5
        public ActionResult Details(int? id)
        {
            ManagerCinema manager = new ManagerCinema();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cinema cinema = manager.GetCinema(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // GET: cinemas/Create
        public ActionResult Create()
        {
            ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "adresse");
            ViewBag.responsable_user_id = new SelectList(new ManagerUser().GetAllUser(), "id", "login");
            return View();
        }

        // POST: cinemas/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,contact_info_id,responsable_user_id")] cinema cinema)
        {
            ManagerCinema manager = new ManagerCinema();
            if (ModelState.IsValid)
            {
                try
                {
                if(manager.PostCinema(cinema))
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            //ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "adresse");
            //ViewBag.responsable_user_id = new SelectList(new ManagerUser().GetAllUser(), "id", "login");
            return View(cinema);
        }

        // GET: cinemas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagerCinema manager = new ManagerCinema();
            cinema cinema = manager.GetCinema(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "adresse");
            ViewBag.responsable_user_id = new SelectList(new ManagerUser().GetAllUser(), "id", "login");
            return View(cinema);
        }

        // POST: cinemas/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,contact_info_id,responsable_user_id")] cinema cinema)
        {
            ManagerCinema manager = new ManagerCinema();
            if (ModelState.IsValid)
            {
                try
                {
                    if (manager.PutCinema(cinema))
                        return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "adresse");
            ViewBag.responsable_user_id = new SelectList(new ManagerUser().GetAllUser(), "id", "login");

            return View(cinema);
        }

        // GET: cinemas/Delete/5
        public ActionResult Delete(int? id)
        {
            ManagerCinema manager = new ManagerCinema();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cinema cinema = manager.GetCinema(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // POST: cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManagerCinema manager = new ManagerCinema();
            if(manager.DeleteCinema(id))
                return RedirectToAction("Index");
            // TODO
            //Implementer un message d'erreur
            return View(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) 
            { 
                //db.Dispose(); 
            }
            base.Dispose(disposing);
        }

        //GET: cinemas/CreateSalle
        public ActionResult CreateSalle(int id)
        {
            ManagerSalleStatus manager = new ManagerSalleStatus();
            Session["cineId"] = id;
            ViewBag.status_id = new SelectList(manager.GetAllSalleStatus(), "id", "status", manager.GetSalleStatus(2));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSalle([Bind(Include = "id, nbr_place, numero_salle, commentaire, status_id, cinema_id")] salle salle)
        {
            ManagerSalle manager = new ManagerSalle();
            salle.cinema_id = int.Parse(Session["cineId"].ToString());

            if (ModelState.IsValid)
            {
                try
                {
                    if (manager.PostSalle(salle))
                        return RedirectToAction("Details", new { id = salle.cinema_id });
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return View(salle);
        }

        //GET: cinemas/DetailsSalle/5
        public ActionResult DetailsSalle(int? id)
        {
            ManagerSalle manager = new ManagerSalle();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salle salle = manager.GetSalle(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        //Get: cinemas/EditSalle/5
        public ActionResult EditSalle(int? id)
        {
            ManagerSalle manager = new ManagerSalle();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salle salle = manager.GetSalle(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            ViewBag.status_id = new SelectList(new ManagerSalleStatus().GetAllSalleStatus(), "id", "status", salle.status_id);
            return View(salle);
        }

        //Post cinemas/EditSalle5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSalle([Bind(Include = "id,nbr_place,numero_salle,commentaire,status_id,cinema_id")] salle salle)
        {
            ManagerSalle manager = new ManagerSalle();
            if (ModelState.IsValid)
            {
                try
                {
                    manager.PutSalle(salle);
                    return RedirectToAction("Details", new { id = salle.cinema_id });
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            ViewBag.status_id = new SelectList(new ManagerSalleStatus().GetAllSalleStatus(), "id", "status", salle.status_id);
            return View(salle);
        }

        //Get: cinemas/DeleteSalle/5
        public ActionResult DeleteSalle(int? id)
        {
            ManagerSalle manager = new ManagerSalle();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salle salle = manager.GetSalle(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        //POST: cinemas/DeleteSalle/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSalle(int id)
        {
            ManagerSalle manager = new ManagerSalle();
            int cineId = manager.GetSalle(id).cinema_id;
            if (manager.DeleteSalles(id))
                return RedirectToAction("Details", new { id = cineId });
            // TODO
            //Implementer un message d'erreur
            return View(id);
        }
    }
}

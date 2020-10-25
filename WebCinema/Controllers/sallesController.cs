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
    public class sallesController : Controller
    {
        //private cinema_dbEntities db = new cinema_dbEntities();

        // GET: salles
        public ActionResult Index()
        {
            ManagerSalle manager = new ManagerSalle();
            return View(manager.GetAllSalle());
        }

        public ActionResult SalleCine(int id)
        {
            ManagerSalle manager = new ManagerSalle();
            Session["salle"] = id;
            return View("Index", manager.GetAllSalle().Where(s => s.cinema_id == id));
        }

        // GET: salles/Details/5
        public ActionResult Details(int? id)
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

        // GET: salles/Create
        public ActionResult Create()
        {
            int cinemaId;
            if(int.TryParse(Session["salle"].ToString(), out cinemaId))
                ViewBag.cinema_id = new SelectList(new ManagerCinema().GetAllCinema().Where(c => c.id == cinemaId), "id", "id");
            else
                ViewBag.cinema_id = new SelectList(new ManagerCinema().GetAllCinema(), "id", "id");
            ViewBag.status_id = new SelectList(new ManagerSalleStatus().GetAllSalleStatus(), "id", "status");
            return View();
        }

        // POST: salles/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nbr_place,numero_salle,commentaire,status_id,cinema_id")] salle salle)
        {
            ManagerSalle manager = new ManagerSalle();
            if (ModelState.IsValid)
            {
                try
                {
                    if (manager.PostSalle(salle))
                        return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            ViewBag.cinema_id = new SelectList(new ManagerCinema().GetAllCinema(), "id", "id", salle.cinema_id);
            ViewBag.status_id = new SelectList(new ManagerSalleStatus().GetAllSalleStatus(), "id", "status", salle.status_id);

            return View(salle);
        }

        // GET: salles/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.cinema_id = new SelectList(new ManagerCinema().GetAllCinema(), "id", "id", salle.cinema_id);
            ViewBag.status_id = new SelectList(new ManagerSalleStatus().GetAllSalleStatus(), "id", "status", salle.status_id);
            return View(salle);
        }

        // POST: salles/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nbr_place,numero_salle,commentaire,status_id,cinema_id")] salle salle)
        {
            ManagerSalle manager = new ManagerSalle();
            if (ModelState.IsValid)
            {
                try
                {
                    manager.PutSalle(salle);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            ViewBag.cinema_id = new SelectList(new ManagerCinema().GetAllCinema(), "id", "id", salle.cinema_id);
            ViewBag.status_id = new SelectList(new ManagerSalleStatus().GetAllSalleStatus(), "id", "status", salle.status_id);

            return View(salle);
        }

        // GET: salles/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: salles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManagerSalle manager = new ManagerSalle();
            if (manager.DeleteSalles(id))
                return RedirectToAction("SalleCine");
            // TODO
            //Implementer un message d'erreur
            return RedirectToAction("SalleCine");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }
    }
}

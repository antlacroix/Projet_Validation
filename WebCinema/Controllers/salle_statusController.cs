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
    public class salle_statusController : Controller
    {
        //private cinema_dbEntities db = new cinema_dbEntities();

        // GET: salle_status
        public ActionResult Index()
        {
            return View(new ManagerSalleStatus().GetAllSalleStatus());
        }

        // GET: salle_status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salle_status salle_status = new ManagerSalleStatus().GetSalleStatus(id);
            if (salle_status == null)
            {
                return HttpNotFound();
            }
            return View(salle_status);
        }

        // GET: salle_status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: salle_status/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,status")] salle_status salle_status)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.salle_status.Add(salle_status);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(salle_status);
        //}

        // GET: salle_status/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    salle_status salle_status = db.salle_status.Find(id);
        //    if (salle_status == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(salle_status);
        //}

        // POST: salle_status/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,status")] salle_status salle_status)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(salle_status).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(salle_status);
        //}

        // GET: salle_status/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    salle_status salle_status = db.salle_status.Find(id);
        //    if (salle_status == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(salle_status);
        //}

        // POST: salle_status/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    salle_status salle_status = db.salle_status.Find(id);
        //    db.salle_status.Remove(salle_status);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        }
    }
}

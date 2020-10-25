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
    public class user_statusController : Controller
    {
        //private cinema_dbEntities db = new cinema_dbEntities();
        
        // GET: user_status
        public ActionResult Index()
        {
            return View(new ManagerUserStatus().GetAllUserStatus());
        }

        // GET: user_status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_status user_status = new ManagerUserStatus().GetUserStatus(id);
            if (user_status == null)
            {
                return HttpNotFound();
            }
            return View(user_status);
        }

        // GET: user_status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user_status/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,status")] user_status user_status)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.user_status.Add(user_status);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(user_status);
        //}

        // GET: user_status/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    user_status user_status = db.user_status.Find(id);
        //    if (user_status == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user_status);
        //}

        // POST: user_status/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,status")] user_status user_status)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user_status).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(user_status);
        //}

        // GET: user_status/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    user_status user_status = db.user_status.Find(id);
        //    if (user_status == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user_status);
        //}

        // POST: user_status/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    user_status user_status = db.user_status.Find(id);
        //    db.user_status.Remove(user_status);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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

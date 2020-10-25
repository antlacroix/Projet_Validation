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
    public class role_participantController : Controller
    {
        // GET: role_participant
        public ActionResult Index()
        {
            return View(new ManagerParticipationRole().GetAllParticipationRole());
        }

        // GET: role_participant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            role_participant role_participant = new ManagerParticipationRole().GetParticipationRole(id);
            if (role_participant == null)
            {
                return HttpNotFound();
            }
            return View(role_participant);
        }

        // GET: role_participant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: role_participant/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,role")] role_participant role_participant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.role_participant.Add(role_participant);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(role_participant);
        //}

        // GET: role_participant/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    role_participant role_participant = db.role_participant.Find(id);
        //    if (role_participant == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(role_participant);
        //}

        // POST: role_participant/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,role")] role_participant role_participant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(role_participant).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(role_participant);
        //}

        // GET: role_participant/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    role_participant role_participant = db.role_participant.Find(id);
        //    if (role_participant == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(role_participant);
        //}

        // POST: role_participant/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    role_participant role_participant = db.role_participant.Find(id);
        //    db.role_participant.Remove(role_participant);
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

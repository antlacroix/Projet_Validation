using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelCinema.Models;

namespace WebCinema.Controllers
{
    public class user_typeController : Controller
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        // GET: user_type
        public ActionResult Index()
        {
            return View(db.user_type.ToList());
        }

        // GET: user_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_type user_type = db.user_type.Find(id);
            if (user_type == null)
            {
                return HttpNotFound();
            }
            return View(user_type);
        }

        // GET: user_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user_type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type")] user_type user_type)
        {
            if (ModelState.IsValid)
            {
                db.user_type.Add(user_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_type);
        }

        // GET: user_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_type user_type = db.user_type.Find(id);
            if (user_type == null)
            {
                return HttpNotFound();
            }
            return View(user_type);
        }

        // POST: user_type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type")] user_type user_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_type);
        }

        // GET: user_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_type user_type = db.user_type.Find(id);
            if (user_type == null)
            {
                return HttpNotFound();
            }
            return View(user_type);
        }

        // POST: user_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_type user_type = db.user_type.Find(id);
            db.user_type.Remove(user_type);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

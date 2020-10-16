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
    public class usersController : Controller
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        // GET: users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.contact_info).Include(u => u.user_status).Include(u => u.user_type);
            return View(users.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            ViewBag.contact_info_id = new SelectList(db.contact_info, "id", "tel_number");
            ViewBag.user_status_id = new SelectList(db.user_status, "id", "status");
            ViewBag.user_type_id = new SelectList(db.user_type, "id", "type");
            return View();
        }

        // POST: users/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,login,password,name,contact_info_id,user_status_id,user_type_id")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contact_info_id = new SelectList(db.contact_info, "id", "tel_number", user.contact_info_id);
            ViewBag.user_status_id = new SelectList(db.user_status, "id", "status", user.user_status_id);
            ViewBag.user_type_id = new SelectList(db.user_type, "id", "type", user.user_type_id);
            return View(user);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.contact_info_id = new SelectList(db.contact_info, "id", "tel_number", user.contact_info_id);
            ViewBag.user_status_id = new SelectList(db.user_status, "id", "status", user.user_status_id);
            ViewBag.user_type_id = new SelectList(db.user_type, "id", "type", user.user_type_id);
            return View(user);
        }

        // POST: users/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,login,password,name,contact_info_id,user_status_id,user_type_id")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contact_info_id = new SelectList(db.contact_info, "id", "tel_number", user.contact_info_id);
            ViewBag.user_status_id = new SelectList(db.user_status, "id", "status", user.user_status_id);
            ViewBag.user_type_id = new SelectList(db.user_type, "id", "type", user.user_type_id);
            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
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

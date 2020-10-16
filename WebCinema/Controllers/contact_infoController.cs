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
    public class contact_infoController : Controller
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        // GET: contact_info
        public ActionResult Index()
        {
            return View(db.contact_info.ToList());
        }

        // GET: contact_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact_info contact_info = db.contact_info.Find(id);
            if (contact_info == null)
            {
                return HttpNotFound();
            }
            return View(contact_info);
        }

        // GET: contact_info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: contact_info/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tel_number,code_postal,adresse,ville,province,pays")] contact_info contact_info)
        {
            if (ModelState.IsValid)
            {
                db.contact_info.Add(contact_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact_info);
        }

        // GET: contact_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact_info contact_info = db.contact_info.Find(id);
            if (contact_info == null)
            {
                return HttpNotFound();
            }
            return View(contact_info);
        }

        // POST: contact_info/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tel_number,code_postal,adresse,ville,province,pays")] contact_info contact_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact_info);
        }

        // GET: contact_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact_info contact_info = db.contact_info.Find(id);
            if (contact_info == null)
            {
                return HttpNotFound();
            }
            return View(contact_info);
        }

        // POST: contact_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contact_info contact_info = db.contact_info.Find(id);
            db.contact_info.Remove(contact_info);
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

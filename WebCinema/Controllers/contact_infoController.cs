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
    public class contact_infoController : Controller
    {
        // GET: contact_info
        public ActionResult Index()
        {
            ManagerContact manager = new ManagerContact();
            return View(manager.GetAllContact());
        }

        // GET: contact_info/Details/5
        public ActionResult Details(int? id)
        {
            ManagerContact manager = new ManagerContact();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact_info contact_info = manager.GetContact(id);
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
            ManagerContact manager = new ManagerContact();
            if (ModelState.IsValid)
            {
                try
                {
                    if (manager.PostContact(contact_info))
                        return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData.Add("Alert", e.Message);
                }
            }

            return View(contact_info);
        }

        // GET: contact_info/Edit/5
        public ActionResult Edit(int? id)
        {
            ManagerContact manager = new ManagerContact();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact_info contact_info = manager.GetContact(id);
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
            ManagerContact manager = new ManagerContact();
            if (ModelState.IsValid)
            {
                try
                {
                    manager.PutContact(contact_info);
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                    TempData.Add("Alert", e.Message);
                }
            }
            return View(contact_info);
        }

        // GET: contact_info/Delete/5
        public ActionResult Delete(int? id)
        {
            ManagerContact manager = new ManagerContact();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact_info contact_info = manager.GetContact(id);
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
            ManagerContact manager = new ManagerContact();
            if (manager.DeleteContact(id))
                return RedirectToAction("Index");
            // TODO
            //Implementer un message d'erreur
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {

        }
    }
}

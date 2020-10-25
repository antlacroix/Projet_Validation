using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows;
using ModelCinema.Models;
using ModelCinema.Models.DataManager;

namespace WebCinema.Controllers
{
    public class usersController : Controller
    {
        //private cinema_dbEntities db = new cinema_dbEntities();

        // GET: users
        public ActionResult Index()
        {
            ManagerUser manager = new ManagerUser();
            return View(manager.GetAllUser());
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            ManagerUser manager = new ManagerUser();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = manager.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "tel_number");
            ViewBag.user_status_id = new SelectList(new ManagerUserStatus().GetAllUserStatus(), "id", "status");
            ViewBag.user_type_id = new SelectList(new ManagerUserType().GetAllUserType(), "id", "type");
            return View();
        }

        // POST: users/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,login,password,name,contact_info_id,user_status_id,user_type_id")] user user)
        {
            ManagerUser manager = new ManagerUser();
            if (ModelState.IsValid)
            {
                try
                {
                    if (manager.PostUser(user))
                        return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "tel_number");
            ViewBag.user_status_id = new SelectList(new ManagerUserStatus().GetAllUserStatus(), "id", "status");
            ViewBag.user_type_id = new SelectList(new ManagerUserType().GetAllUserType(), "id", "type");

            return View(user);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            ManagerUser manager = new ManagerUser();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = manager.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "tel_number");
            ViewBag.user_status_id = new SelectList(new ManagerUserStatus().GetAllUserStatus(), "id", "status");
            ViewBag.user_type_id = new SelectList(new ManagerUserType().GetAllUserType(), "id", "type");

            return View(user);
        }

        // POST: users/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,login,password,name,contact_info_id,user_status_id,user_type_id")] user user)
        {
            ManagerUser manager = new ManagerUser();
            if (ModelState.IsValid)
            {
                try
                {
                    manager.PutUser(user);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            ViewBag.contact_info_id = new SelectList(new ManagerContact().GetAllContact(), "id", "tel_number");
            ViewBag.user_status_id = new SelectList(new ManagerUserStatus().GetAllUserStatus(), "id", "status");
            ViewBag.user_type_id = new SelectList(new ManagerUserType().GetAllUserType(), "id", "type");

            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            ManagerUser manager = new ManagerUser();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = manager.GetUser(id);
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
            ManagerUser manager = new ManagerUser();
            if (manager.DeleteUser(id))
                return RedirectToAction("Index");
            // TODO
            //Implementer un message d'erreur
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //new ManagerSeance().Dispose();
            //}

            ////base.Dispose(disposing);

            ////if (disposing)
            ////{
            ////    db.Dispose();
            ////}
            ////base.Dispose(disposing);
        }
    }
}

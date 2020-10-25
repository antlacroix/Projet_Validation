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
    public class participantsController : Controller
    {
        // GET: participants
        public ActionResult Index()
        {
            ManagerParticipant manager = new ManagerParticipant();
            return View(manager.GetAllParticipant());
        }

        // GET: participants/Details/5
        public ActionResult Details(int? id)
        {
            ManagerParticipant manager = new ManagerParticipant();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participant participant = manager.GetParticipant(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // GET: participants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: participants/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] participant participant)
        {
            ManagerParticipant manager = new ManagerParticipant();
            if (ModelState.IsValid)
            {
                try
                {
                    if (manager.PostParticipant(participant))
                        return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return View(participant);
        }

        // GET: participants/Edit/5
        public ActionResult Edit(int? id)
        {
            ManagerParticipant manager = new ManagerParticipant();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participant participant = manager.GetParticipant(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: participants/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] participant participant)
        {
            ManagerParticipant manager = new ManagerParticipant();
            if (ModelState.IsValid)
            {
                try
                {
                    manager.PutParticipant(participant);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return View(participant);
        }

        // GET: participants/Delete/5
        public ActionResult Delete(int? id)
        {
            ManagerParticipant manager = new ManagerParticipant();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participant participant = manager.GetParticipant(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManagerParticipant manager = new ManagerParticipant();
            if (manager.DeleteParticipant(id))
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

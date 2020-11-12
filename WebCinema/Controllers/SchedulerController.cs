using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ModelCinema.Models;
namespace WebCinema.Controllers
{
   public class SchedulerController : Controller
   {
        cinema_dbEntities db = new cinema_dbEntities();
        public ActionResult Index()
        {
            ViewBag.dataSource = db.seances.ToList();
            return View();
        }
    }
}

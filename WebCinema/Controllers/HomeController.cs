using ModelCinema.Models;
using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace WebCinema.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                List<cinema> tempCinema = new ManagerCinema().GetAllCinema();
                List<SelectListItem> cinemas = new List<SelectListItem>();
                foreach (cinema item in tempCinema)
                {
                    cinemas.Add(new SelectListItem() { Text = item.id.ToString(), Value = item.id.ToString() });
                }

                ViewBag.cinemas = new SelectList(cinemas, "Value", "Text");
            }
            catch (Exception e)
            {
                TempData.Add("Alert", e.Message);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {

            int id = int.Parse(form["cinemas"].ToString());
            return RedirectToAction("Index", "seances", new { id = id });

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
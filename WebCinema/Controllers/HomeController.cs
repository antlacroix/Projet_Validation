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
            string Id_Cinema;
            try
            {
                if (Request.Cookies.AllKeys.Contains("Id_Cinema"))
                {
                    Id_Cinema = Request.Cookies["Id_Cinema"].Value;
                    Session[SessionKeys.cinemaId] = Id_Cinema;
                    ManagerCinema manager = new ManagerCinema();
                    cinema cinema = manager.GetCinema(int.Parse(Id_Cinema));
                    return RedirectToAction("Details", "cinemas", new { id = Id_Cinema });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Le Cookie est vide");
                Console.WriteLine(e);
            }

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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ModelCinema.Models;
using ModelCinema.Models.DataManager;
using ScheduleSample.Models;
using Syncfusion.EJ2.Schedule;

namespace WebCinema.Controllers
{
    public class SchedulerEJSController : Controller
    {
        cinema_dbEntities db = new cinema_dbEntities();
        public ActionResult Index()
        {
            //ManagerCinema managerCinema = new ManagerCinema();
            //ManagerSalle managerSalle = new ManagerSalle();
            //ManagerFilm managerFilm = new ManagerFilm();
            //ManagerSeance managerSeance = new ManagerSeance();

            //List<seance> listeSeance = managerSeance.GetAllSeanceFrom(new DateTime(2020, 10, 30));
            //listeSeance.ForEach(x => x.salle.cinema.salles.Clear());
            //listeSeance.ForEach(x => x.salle.salle_status.salles.Clear());
            //listeSeance.ForEach(x => x.programmations.Clear());

            //listeSeance.ForEach(x => x.salle.seances.Clear());

            //listeSeance.ForEach(x => x.salle.cinema.contact_info.cinemas.Clear());
            //listeSeance.ForEach(x => x.salle.cinema.user.contact_info.users.Clear());
            //listeSeance.ForEach(x => x.salle.cinema.user.cinemas.Clear());
            //listeSeance.ForEach(x => x.salle.cinema.user.user_status.users.Clear());
            //listeSeance.ForEach(x => x.salle.cinema.user.user_type.users.Clear());


            //ViewBag.appointments = managerSeance.GetAllSeanceFrom(new DateTime(2020, 10, 30));
            ////ViewBag.appointments = GetScheduleData();

            //ViewBag.Film = managerFilm.GetAllFilms();

            //List<cinema> listeCinema = managerCinema.GetAllCinema();
            //listeCinema.ForEach(x => x.salles.Clear());
            //listeCinema.ForEach(x => x.contact_info = null);
            //listeCinema.ForEach(x => x.contact_info_id = 0);
            //listeCinema.ForEach(x => x.user = null);
            //listeCinema.ForEach(x => x.responsable_user_id = 0);

            //ViewBag.Cinema = listeCinema;
            ////ViewBag.Cinema = managerCinema.GetAllCinema();

            //List<salle> listeSalle = managerSalle.GetAllSalle();
            //listeSalle.ForEach(x => x.salle_status.salles.Clear());
            //listeSalle.ForEach(x => x.seances.Clear());
            //listeSalle.ForEach(x => x.cinema.salles.Clear());
            //listeSalle.ForEach(x => x.cinema.contact_info = null);
            //listeSalle.ForEach(x => x.cinema.contact_info_id = 0);
            //listeSalle.ForEach(x => x.cinema.user = null);
            //listeSalle.ForEach(x => x.cinema.responsable_user_id = 0);
            //ViewBag.Salle = listeSalle;
            ////ViewBag.Salle = managerSalle.GetAllSalle();


            //ViewBag.Resources = new string[] { "Cinema", "Salle" };

            //return View(managerSeance.GetAllSeanceFrom(new DateTime(2020, 10, 30)));

            ViewBag.locationData = new string[] { "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Anguilla", "Antigua &amp; Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia &amp; Herzegovina", "Botswana", "Brazil", "British Virgin Islands", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Cape Verde", "Cayman Islands", "Chad", "Chile", "China", "Colombia", "Congo", "Cook Islands", "Costa Rica", "Cote D Ivoire", "Croatia", "Cruise Ship", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Estonia", "Ethiopia", "Falkland Islands", "Faroe Islands", "Fiji", "Finland", "France", "French Polynesia", "French West Indies", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guam", "Guatemala", "Guernsey", "Guinea", "Guinea Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Isle of Man", "Israel", "Italy", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kuwait", "Kyrgyz Republic", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Mauritania", "Mauritius", "Mexico", "Moldova", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Namibia", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Norway", "Oman", "Pakistan", "Palestine", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russia", "Rwanda", "Saint Pierre &amp; Miquelon", "Samoa", "San Marino", "Satellite", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "South Africa", "South Korea", "Spain", "Sri Lanka", "St Kitts &amp; Nevis", "St Lucia", "St Vincent", "St. Lucia", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor L'Este", "Togo", "Tonga", "Trinidad &amp; Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks &amp; Caicos", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "Uruguay", "Uzbekistan", "Venezuela", "Vietnam", "Virgin Islands (US)", "Yemen", "Zambia", "Zimbabwe" };
            ViewBag.data = new string[] { "American Football", "Badminton", "Basketball", "Cricket", "Football", "Golf", "Hockey", "Rugby", "Snooker", "Tennis" };
            return View();
        }
        //public class ResourceDataSourceModel
        //{
        //    public string text { set; get; }
        //    public int id { set; get; }
        //    public string color { set; get; }
        //}

        public JsonResult LoadData(Params param)  // Here we get the Start and End Date and based on that can filter the data and return to Scheduler
        {
            var data = db.seances.ToList();
            var JsonFile = Json(data, JsonRequestBehavior.AllowGet);
            Console.WriteLine(JsonFile);
            return JsonFile;
        }
        public class Params
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        //[HttpPost]
        //public JsonResult UpdateData(EditParams param)
        //{
        //    if (param.action == "insert" || (param.action == "batch" && param.added != null)) // this block of code will execute while inserting the appointments
        //    {
        //        var value = (param.action == "insert") ? param.value : param.added[0];
        //        int intMax = db.seances.ToList().Count > 0 ? db.seances.ToList().Max(p => p.Id) : 1;
        //        DateTime startTime = Convert.ToDateTime(value.StartTime);
        //        DateTime endTime = Convert.ToDateTime(value.EndTime);
        //        seance appointment = new seance()
        //        {
        //            Id = intMax + 1,
        //            StartTime = startTime.ToLocalTime(),
        //            EndTime = endTime.ToLocalTime(),
        //            Subject = value.Subject,
        //            IsAllDay = value.IsAllDay,
        //            RecurrenceRule = value.RecurrenceRule,
        //            RecurrenceID = value.RecurrenceID,
        //            RecurrenceException = value.RecurrenceException,
        //        };
        //        db.seances.Add(appointment);
        //        db.SaveChanges();
        //    }
        //    if (param.action == "update" || (param.action == "batch" && param.changed != null)) // this block of code will execute while updating the appointment
        //    {
        //        var value = (param.action == "update") ? param.value : param.changed[0];
        //        var filterData = db.seances.Where(c => c.Id == Convert.ToInt32(value.Id));
        //        if (filterData.Count() > 0)
        //        {
        //            DateTime startTime = Convert.ToDateTime(value.StartTime);
        //            DateTime endTime = Convert.ToDateTime(value.EndTime);
        //            seance appointment = db.seances.Single(A => A.Id == Convert.ToInt32(value.Id));
        //            appointment.StartTime = startTime.ToLocalTime();
        //            appointment.EndTime = endTime.ToLocalTime();;
        //            appointment.Subject = value.Subject;
        //            appointment.IsAllDay = value.IsAllDay;
        //            appointment.RecurrenceRule = value.RecurrenceRule;
        //            appointment.RecurrenceID = value.RecurrenceID;
        //            appointment.RecurrenceException = value.RecurrenceException;
        //        }
        //        db.SaveChanges();
        //    }
        //    if (param.action == "remove" || (param.action == "batch" && param.deleted != null)) // this block of code will execute while removing the appointment
        //    {
        //        if (param.action == "remove")
        //        {
        //            int key = Convert.ToInt32(param.key);
        //            seance appointment = db.seances.Where(c => c.Id == key).FirstOrDefault();
        //            if (appointment != null) db.seances.Remove(appointment);
        //        }
        //        else
        //        {
        //            foreach (var apps in param.deleted)
        //            {
        //                seance appointment = db.seances.Where(c => c.Id == apps.Id).FirstOrDefault();
        //                if (apps != null) db.seances.Remove(appointment);
        //            }
        //        }
        //        db.SaveChanges();
        //    }
        //    var data = db.seances.ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

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

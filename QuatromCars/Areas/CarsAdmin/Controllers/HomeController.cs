using QuatromCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuatromCars.Areas.CarsAdmin.Controllers
{
    public class HomeController : Controller
    {
        QuatromDB db = new QuatromDB();
        public ActionResult Index()
        {
            return View();
        }
    }
}
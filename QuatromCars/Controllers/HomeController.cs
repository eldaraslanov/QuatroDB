using QuatromCars.Models;
using QuatromCars.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuatromCars.Controllers
{
    public class HomeController : Controller
    {
        QuatromDB db = new QuatromDB();
        public ActionResult Index()
        {
            var vm = new homeVm
            {
                slider = db.SliderTops.ToList(),
                News=db.News.ToList(),
                products=db.Products.ToList(),  
                CarsGa=db.CarsGaleries.ToList(),
                AvtoPa=db.AvtoParths.ToList(),
            };
            return View(vm);
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
        public ActionResult CarsListing()
        {
            ViewBag.Message = "Your cars Listing page.";

            return View();
        }
    }
}
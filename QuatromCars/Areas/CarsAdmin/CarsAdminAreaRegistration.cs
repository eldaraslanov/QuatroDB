using System.Web.Mvc;

namespace QuatromCars.Areas.CarsAdmin
{
    public class CarsAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CarsAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CarsAdmin_default",
                "CarsAdmin/{controller}/{action}/{id}",
                new {Controller="Home",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
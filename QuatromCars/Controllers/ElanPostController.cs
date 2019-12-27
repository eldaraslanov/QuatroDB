using QuatromCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuatromCars.Controllers
{
    public class ElanPostController : Controller
    {
        QuatromDB db = new QuatromDB();
        // GET: ElanPost
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CheckPhone(string PhoneType,string phone)
        {
            object data = null;

            if (PhoneType!=String.Empty && phone != String.Empty)
            {
                CellNumber selectedUser = db.CellNumbers.FirstOrDefault(us => us.PhoneType== PhoneType);
                if (selectedUser != null)
                {
                    User_to_CellNumber Ustell = db.User_to_CellNumber.FirstOrDefault(us => us.CellNumber.PhoneType == selectedUser.PhoneType && us.User.Phone == phone);
                    if (Ustell==null)
                    {
                        data =new{
                          status=200,
                          message="success",
                          redirectUrl = Url.Action("index", "elanpost"),
                          response =Ustell.User.Phone
                        };
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    data = new
                    {
                        status = 404,
                        message = "Bele bir Privader tipi yoxdur!",
                        response = ""
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}
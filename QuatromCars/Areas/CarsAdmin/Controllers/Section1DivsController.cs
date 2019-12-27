using QuatromCars.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace QuatromCars.Areas.CarsAdmin.Controllers
{
    public class Section1DivsController : Controller
    {
        QuatromDB db = new QuatromDB();
        public ActionResult Index()
        {
            return View(db.SliderTops.ToList());
        }

        public ActionResult Create()
        {       
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SliderTop sliderTop, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                if(Image.ContentType.ToLower()=="image/jpg" ||
                    Image.ContentType.ToLower()=="image/jpeg" ||
                    Image.ContentType.ToLower() == "image/png" ||
                    Image.ContentType.ToLower() == "image/svg" ||
                    Image.ContentType.ToLower() == "image/gif")
                {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo fileName = new FileInfo(Image.FileName);
                    string newName = Guid.NewGuid().ToString() + fileName.Extension;
                    img.Save("~/uploads/Section1Photo/" + newName);
                    sliderTop.SliderPhoto = "/uploads/section1Photo/" + newName;
                    db.SliderTops.Add(sliderTop);
                    db.SaveChanges();
                   return RedirectToAction("Index");
                    };  
                };
            }
            return View();
        }


        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();
            SliderTop selectedSlider = db.SliderTops.FirstOrDefault(sl => sl.Id == id);
            if (selectedSlider == null) return HttpNotFound();
            return View(selectedSlider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,SliderTop slider,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                SliderTop selectedSlider = db.SliderTops.SingleOrDefault(sl => sl.Id == id);

                if (Image != null)
                {
                    if (Image.ContentType.ToLower() == "image/jpg" ||
                        Image.ContentType.ToLower() == "image/jpeg" ||
                        Image.ContentType.ToLower() == "image/png" ||
                        Image.ContentType.ToLower() == "image/svg" ||
                        Image.ContentType.ToLower() == "image/gif")
                    {
                        if (System.IO.File.Exists(Server.MapPath(selectedSlider.SliderPhoto)))
                        {
                            System.IO.File.Delete(Server.MapPath(selectedSlider.SliderPhoto));

                        }
                        WebImage img = new WebImage(Image.InputStream);
                        FileInfo fileName = new FileInfo(Image.FileName);
                        string newName = Guid.NewGuid().ToString() + fileName.Extension;
                        img.Save("~/uploads/Section1Photo/" + newName);
                        selectedSlider.SliderPhoto = "/uploads/section1Photo/" + newName;
                    };

                };
                selectedSlider.Header = slider.Header;
                selectedSlider.Descriptions = slider.Descriptions;
                selectedSlider.SubDescriptions = slider.SubDescriptions;
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(slider);
        }
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();
            SliderTop selectedSlider = db.SliderTops.FirstOrDefault(sl => sl.Id == id);
            if (selectedSlider == null) return HttpNotFound();
            return View(selectedSlider);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderTop slt = db.SliderTops.Find(id);
            if (slt == null)
            {
                return HttpNotFound();
            }
            return View(slt);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SliderTop slt = db.SliderTops.Find(id);
            db.SliderTops.Remove(slt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
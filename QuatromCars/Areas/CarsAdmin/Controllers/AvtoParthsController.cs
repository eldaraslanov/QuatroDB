using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using QuatromCars.Models;

namespace QuatromCars.Areas.CarsAdmin.Controllers
{
    public class AvtoParthsController : Controller
    {
        private QuatromDB db = new QuatromDB();

        // GET: CarsAdmin/AvtoParths
        public ActionResult Index()
        {
            var avtoParths = db.AvtoParths.Include(a => a.Category).Include(a => a.City).Include(a => a.PriceType).Include(a => a.VIP);
            return View(avtoParths.ToList());
        }

        // GET: CarsAdmin/AvtoParths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();
            AvtoParth SelAvtoParth = db.AvtoParths.FirstOrDefault(sl => sl.id == id);
            if (SelAvtoParth == null) return HttpNotFound();
            return View(SelAvtoParth);
        }

        // GET: CarsAdmin/AvtoParths/Create
        public ActionResult Create()
        {
            ViewBag.ParthCategoryID = new SelectList(db.Categories, "id", "Name");
            ViewBag.CityID = new SelectList(db.Cities, "id", "CitName");
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "id", "TypeName");
            ViewBag.VipID = new SelectList(db.VIPs, "id", "Name");
            return View();
        }

        // POST: CarsAdmin/AvtoParths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,ParthCategoryID,Photo,Price,PriceTypeId,Description,NewOrOld,VipID,CityID,PublishDatte")] AvtoParth avtoParth, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    if (Image.ContentType.ToLower() == "image/jpg" ||
                    Image.ContentType.ToLower() == "image/jpeg" ||
                    Image.ContentType.ToLower() == "image/png" ||
                    Image.ContentType.ToLower() == "image/svg+xml" ||
                    Image.ContentType.ToLower() == "image/gif")
                    {
                        WebImage img = new WebImage(Image.InputStream);
                        FileInfo fileName = new FileInfo(Image.FileName);
                        string newName = Guid.NewGuid().ToString() + fileName.Extension;
                        img.Save("~/uploads/AvtoParP/" + newName);
                        avtoParth.Photo = "/uploads/AvtoParP/" + newName;
                    }
                }
                db.AvtoParths.Add(avtoParth);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParthCategoryID = new SelectList(db.Categories, "id", "Name", avtoParth.ParthCategoryID);
            ViewBag.CityID = new SelectList(db.Cities, "id", "CitName", avtoParth.CityID);
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "id", "TypeName", avtoParth.PriceTypeId);
            ViewBag.VipID = new SelectList(db.VIPs, "id", "Name", avtoParth.VipID);
            return View(avtoParth);
        }

        // GET: CarsAdmin/AvtoParths/Edit/5
        public ActionResult Edit(int? id)
        {
            
                if (id == null) return HttpNotFound();
                AvtoParth avtoParth = db.AvtoParths.FirstOrDefault(sl => sl.id == id);
                if (avtoParth == null) return HttpNotFound();
            ViewBag.ParthCategoryID = new SelectList(db.Categories, "id", "Name");
            ViewBag.CityID = new SelectList(db.Cities, "id", "CitName");
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "id", "TypeName");
            ViewBag.VipID = new SelectList(db.VIPs, "id", "Name");
            return View(avtoParth);
           
        }

        // POST: CarsAdmin/AvtoParths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( AvtoParth avtoParth,int id, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                AvtoParth selAvtoParth = db.AvtoParths.SingleOrDefault(nw => nw.id == id);
                if (Image != null)
                {
                    if (Image.ContentType.ToLower() == "image/jpg" ||
                           Image.ContentType.ToLower() == "image/jpeg" ||
                           Image.ContentType.ToLower() == "image/png" ||
                           Image.ContentType.ToLower() == "image/svg+xml" ||
                           Image.ContentType.ToLower() == "image/gif")
                    {
                        if (System.IO.File.Exists(Server.MapPath(selAvtoParth.Photo)))
                        {
                            System.IO.File.Delete(Server.MapPath(selAvtoParth.Photo));
                        }
                        WebImage img = new WebImage(Image.InputStream);
                        FileInfo fileName = new FileInfo(Image.FileName);
                        string newName = Guid.NewGuid().ToString() + fileName.Extension;
                        img.Save("~/uploads/AvtoParP/" + newName);
                        selAvtoParth.Photo = "/uploads/AvtoParP/" + newName;
                    };
                };
                selAvtoParth.Name = avtoParth.Name;
                selAvtoParth.Price = avtoParth.Price;
                selAvtoParth.Description = avtoParth.Description;
                selAvtoParth.NewOrOld = avtoParth.NewOrOld;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParthCategoryID = new SelectList(db.Categories, "id", "Name", avtoParth.ParthCategoryID);
            ViewBag.CityID = new SelectList(db.Cities, "id", "CitName", avtoParth.CityID);
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "id", "TypeName", avtoParth.PriceTypeId);
            ViewBag.VipID = new SelectList(db.VIPs, "id", "Name", avtoParth.VipID);
            return View(avtoParth);
        }

        // GET: CarsAdmin/AvtoParths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvtoParth avtoParth = db.AvtoParths.Find(id);
            if (avtoParth == null)
            {
                return HttpNotFound();
            }
            return View(avtoParth);
        }

        // POST: CarsAdmin/AvtoParths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvtoParth avtoParth = db.AvtoParths.Find(id);
            db.AvtoParths.Remove(avtoParth);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

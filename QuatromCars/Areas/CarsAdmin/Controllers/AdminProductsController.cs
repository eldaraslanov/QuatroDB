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
    public class AdminProductsController : Controller
    {
        private QuatromDB db = new QuatromDB();

        // GET: CarsAdmin/AdminProducts
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.City).Include(p => p.FuelType).Include(p => p.Model).Include(p => p.MotorsCapacity).Include(p => p.PriceType).Include(p => p.ProductColor).Include(p => p.Transmission).Include(p => p.VIP);
            return View(products.ToList());
        }

        // GET: CarsAdmin/AdminProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();
            Product carsAdmin = db.Products.FirstOrDefault(sl => sl.id == id);
            if (carsAdmin == null) return HttpNotFound();
            return View(carsAdmin);
        }

        // GET: CarsAdmin/AdminProducts/Create
        public ActionResult Create()
        {
            ViewBag.ModelId = new SelectList(db.Models, "id", "Name");
            ViewBag.MotorCapacityId = new SelectList(db.MotorsCapacities, "Id", "Capacity");
            ViewBag.PriceType = new SelectList(db.PriceTypes, "id", "TypeName");
            ViewBag.ProductTypeID = new SelectList(db.Transmissions, "id", "TypeName");
            return View();
        }

        // POST: CarsAdmin/AdminProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Photo,PriceType,Price,Description,NewOrOld,Published,IsActive,VIPid,CategoryID,CityID,ProductionDate,PrublishDate,ProductTypeID,ModelId,PinNumber,IsCredit,isBarter,MotorCapacityId,HorsePower,FuelId,ColorId")] Product product, HttpPostedFileBase Image)
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
                        img.Save("~/uploads/CarsAdmin/" + newName);
                        product.Photo = "/uploads/CarsAdmin/" + newName;
                    }
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "id", "Name", product.CategoryID);
            ViewBag.CityID = new SelectList(db.Cities, "id", "CitName", product.CityID);
            ViewBag.FuelId = new SelectList(db.FuelTypes, "Id", "FuelName", product.FuelId);
            ViewBag.ModelId = new SelectList(db.Models, "id", "Name", product.ModelId);
            ViewBag.MotorCapacityId = new SelectList(db.MotorsCapacities, "Id", "Capacity", product.MotorCapacityId);
            ViewBag.PriceType = new SelectList(db.PriceTypes, "id", "TypeName", product.PriceType);
            ViewBag.ColorId = new SelectList(db.ProductColors, "Id", "ColorName", product.ColorId);
            ViewBag.ProductTypeID = new SelectList(db.Transmissions, "id", "TypeName", product.ProductTypeID);
            ViewBag.VIPid = new SelectList(db.VIPs, "id", "Name", product.VIPid);
            return View(product);
        }

        // GET: CarsAdmin/AdminProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "id", "Name", product.CategoryID);
            ViewBag.CityID = new SelectList(db.Cities, "id", "CitName", product.CityID);
            ViewBag.FuelId = new SelectList(db.FuelTypes, "Id", "FuelName", product.FuelId);
            ViewBag.ModelId = new SelectList(db.Models, "id", "Name", product.ModelId);
            ViewBag.MotorCapacityId = new SelectList(db.MotorsCapacities, "Id", "Capacity", product.MotorCapacityId);
            ViewBag.PriceType = new SelectList(db.PriceTypes, "id", "TypeName", product.PriceType);
            ViewBag.ColorId = new SelectList(db.ProductColors, "Id", "ColorName", product.ColorId);
            ViewBag.ProductTypeID = new SelectList(db.Transmissions, "id", "TypeName", product.ProductTypeID);
            ViewBag.VIPid = new SelectList(db.VIPs, "id", "Name", product.VIPid);
            return View(product);
        }

        // POST: CarsAdmin/AdminProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Photo,PriceType,Price,Description,NewOrOld,Published,IsActive,VIPid,CategoryID,CityID,ProductionDate,PrublishDate,ProductTypeID,ModelId,PinNumber,IsCredit,isBarter,MotorCapacityId,HorsePower,FuelId,ColorId")] Product product,int id, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                Product selPro = db.Products.SingleOrDefault(pr => pr.id == id);
                if (Image != null)
                {
                    if (Image.ContentType.ToLower() == "image/jpg" ||
                           Image.ContentType.ToLower() == "image/jpeg" ||
                           Image.ContentType.ToLower() == "image/png" ||
                           Image.ContentType.ToLower() == "image/svg+xml" ||
                           Image.ContentType.ToLower() == "image/gif")
                    {
                        if (System.IO.File.Exists(Server.MapPath(selPro.Photo)))
                        {
                            System.IO.File.Delete(Server.MapPath(selPro.Photo));
                        }
                        WebImage img = new WebImage(Image.InputStream);
                        FileInfo fileName = new FileInfo(Image.FileName);
                        string newName = Guid.NewGuid().ToString() + fileName.Extension;
                        img.Save("~/uploads/CarsAdmin/" + newName);
                        selPro.Photo = "/uploads/CarsAdmin/" + newName;
                    };
                };
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "id", "Name", product.CategoryID);
            ViewBag.CityID = new SelectList(db.Cities, "id", "CitName", product.CityID);
            ViewBag.FuelId = new SelectList(db.FuelTypes, "Id", "FuelName", product.FuelId);
            ViewBag.ModelId = new SelectList(db.Models, "id", "Name", product.ModelId);
            ViewBag.MotorCapacityId = new SelectList(db.MotorsCapacities, "Id", "Capacity", product.MotorCapacityId);
            ViewBag.PriceType = new SelectList(db.PriceTypes, "id", "prcTypeName", product.PriceType);
            ViewBag.ColorId = new SelectList(db.ProductColors, "Id", "ColorName", product.ColorId);
            ViewBag.ProductTypeID = new SelectList(db.Transmissions, "id", "TypeName", product.ProductTypeID);
            ViewBag.VIPid = new SelectList(db.VIPs, "id", "Name", product.VIPid);
            return View(product);
        }

        // GET: CarsAdmin/AdminProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: CarsAdmin/AdminProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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

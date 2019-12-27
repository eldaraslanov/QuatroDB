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
    public class AdminBrendsController : Controller
    {
        private QuatromDB db = new QuatromDB();

        // GET: CarsAdmin/AdminBrends
        public ActionResult Index()
        {
            return View(db.Brends.ToList());
        }

        // GET: CarsAdmin/AdminBrends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brend brend = db.Brends.Find(id);
            if (brend == null)
            {
                return HttpNotFound();
            }
            return View(brend);
        }

        // GET: CarsAdmin/AdminBrends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsAdmin/AdminBrends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BrendPhoto")] Brend brend,HttpPostedFileBase Image)
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
                            img.Save("~/uploads/SecBrend/" + newName);
                            brend.BrendPhoto = "/uploads/SecBrend/" + newName;
                            db.Brends.Add(brend);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                    }
                }
                db.Brends.Add(brend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brend);
        }

        // GET: CarsAdmin/AdminBrends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brend brend = db.Brends.Find(id);
            if (brend == null)
            {
                return HttpNotFound();
            }
            return View(brend);
        }

        // POST: CarsAdmin/AdminBrends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BrendPhoto")] Brend brend,int id,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                Brend selectedBrend = db.Brends.SingleOrDefault(br => br.Id==id);
                if (Image != null)
                {
                    if (Image.ContentType.ToLower() == "image/jpg" ||
                        Image.ContentType.ToLower() == "image/jpeg" ||
                        Image.ContentType.ToLower() == "image/png" ||
                        Image.ContentType.ToLower() == "image/svg+xml" ||
                        Image.ContentType.ToLower() == "image/gif")
                    {
                        if (System.IO.File.Exists(Server.MapPath(selectedBrend.BrendPhoto)))
                        {
                            System.IO.File.Delete(Server.MapPath(selectedBrend.BrendPhoto));
                        }
                        WebImage img = new WebImage(Image.InputStream);
                        FileInfo fileName = new FileInfo(Image.FileName);
                        string newName = Guid.NewGuid().ToString() + fileName.Extension;
                        img.Save("~/uploads/SecBrend/" + newName);
                        selectedBrend.BrendPhoto = "/uploads/SecBrend/" + newName;
                    };
                };
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brend);
        }

        // GET: CarsAdmin/AdminBrends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brend brend = db.Brends.Find(id);
            if (brend == null)
            {
                return HttpNotFound();
            }
            return View(brend);
        }

        // POST: CarsAdmin/AdminBrends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brend brend = db.Brends.Find(id);
            db.Brends.Remove(brend);
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

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
    public class NewsController : Controller
    {
        QuatromDB db = new QuatromDB();

        // GET: CarsAdmin/News
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }

        // GET: CarsAdmin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();
            News SelectedNews = db.News.FirstOrDefault(sl => sl.Id == id);
            if (SelectedNews == null) return HttpNotFound();
            return View(SelectedNews);
        }

        // GET: CarsAdmin/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsAdmin/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreateDate,Description,SubDescription,NewPhoto")] News news,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image!= null)
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
                        img.Save("~/uploads/newsPhotoF/" + newName);
                        news.NewPhoto = "/uploads/newsPhotoF/" + newName;
                        db.News.Add(news);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: CarsAdmin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: CarsAdmin/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreateDate,Description,SubDescription,NewPhoto")] News news,int id,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                News selectedNews = db.News.SingleOrDefault(nw => nw.Id==id);
                if (Image!= null)
                {
                    if (Image.ContentType.ToLower() == "image/jpg" ||
                           Image.ContentType.ToLower() == "image/jpeg" ||
                           Image.ContentType.ToLower() == "image/png" ||
                           Image.ContentType.ToLower() == "image/svg+xml" ||
                           Image.ContentType.ToLower() == "image/gif")
                    {
                        if (System.IO.File.Exists(Server.MapPath(selectedNews.NewPhoto)))
                        {
                            System.IO.File.Delete(Server.MapPath(selectedNews.NewPhoto));
                        }
                        WebImage img = new WebImage(Image.InputStream);
                        FileInfo fileName = new FileInfo(Image.FileName);
                        string newName = Guid.NewGuid().ToString() + fileName.Extension;
                        img.Save("~/uploads/newsPhotoF/" + newName);
                        selectedNews.NewPhoto = "/uploads/newsPhotoF/" + newName;
                    };
                };
                selectedNews.CreateDate = news.CreateDate;
                selectedNews.Description = news.Description;
                selectedNews.SubDescription = news.SubDescription;  
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: CarsAdmin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: CarsAdmin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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

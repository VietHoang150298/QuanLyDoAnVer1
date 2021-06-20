using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAn.Models;
using QuanLyDoAn.ViewModels;

namespace QuanLyDoAn.Controllers
{
    public class HocKysController : Controller
    {
        private QLDADbContext db = new QLDADbContext();
        // GET: HocKys
        public ActionResult Index()
        {
            return View(db.HocKys.ToList());
        }

        public ActionResult KhoiTaoDLHK(string maHocKy)
           {
            ViewBag.MaHocKy = maHocKy;
            var hocKy = from a in db.HocKys
                           where a.MaHocKy == maHocKy
                           select new HocKyViewModel {TenHocKy = a.TenHocKy};
            ViewBag.HocKy = hocKy.ToList();
            return View();
        }

        // GET: HocKys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocKy hocKy = db.HocKys.Find(id);
            if (hocKy == null)
            {
                return HttpNotFound();
            }
            return View(hocKy);
        }

        // GET: HocKys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HocKys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHocKy,MaHocKy,TenHocKy,NamBatDau,NamKetThuc")] HocKy hocKy)
        {
            if (ModelState.IsValid)
            {
                if (db.HocKys.Any(x => x.MaHocKy == hocKy.MaHocKy))
                {
                    ModelState.AddModelError("maHocKy", "Mã học kỳ đã tồn tại!");
                    return View("Create");
                }
                db.HocKys.Add(hocKy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hocKy);
        }
        // GET: HocKys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocKy hocKy = db.HocKys.Find(id);
            if (hocKy == null)
            {
                return HttpNotFound();
            }
            return View(hocKy);
        }

        // POST: HocKys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHocKy,MaHocKy,TenHocKy,NamBatDau,NamKetThuc")] HocKy hocKy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocKy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hocKy);
        }
        
        // GET: HocKys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocKy hocKy = db.HocKys.Find(id);
            if (hocKy == null)
            {
                return HttpNotFound();
            }
            return View(hocKy);
        }

        // POST: HocKys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HocKy hocKy = db.HocKys.Find(id);
            db.HocKys.Remove(hocKy);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAn.Models;

namespace QuanLyDoAn.Areas.Admin.Controllers
{
    public class LoaiMonHocsController : Controller
    {
        private QLDADbContext db = new QLDADbContext();

        // GET: Admin/LoaiMonHocs
        public ActionResult Index()
        {
            return View(db.LoaiMonHocs.ToList());
        }

        // GET: Admin/LoaiMonHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMonHoc loaiMonHoc = db.LoaiMonHocs.Find(id);
            if (loaiMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(loaiMonHoc);
        }

        // GET: Admin/LoaiMonHocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiMonHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLoaiMonHoc,TenLoaiMonHoc")] LoaiMonHoc loaiMonHoc)
        {
            if (ModelState.IsValid)
            {
                db.LoaiMonHocs.Add(loaiMonHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiMonHoc);
        }

        // GET: Admin/LoaiMonHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMonHoc loaiMonHoc = db.LoaiMonHocs.Find(id);
            if (loaiMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(loaiMonHoc);
        }

        // POST: Admin/LoaiMonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLoaiMonHoc,TenLoaiMonHoc")] LoaiMonHoc loaiMonHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiMonHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiMonHoc);
        }

        // GET: Admin/LoaiMonHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMonHoc loaiMonHoc = db.LoaiMonHocs.Find(id);
            if (loaiMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(loaiMonHoc);
        }

        // POST: Admin/LoaiMonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiMonHoc loaiMonHoc = db.LoaiMonHocs.Find(id);
            db.LoaiMonHocs.Remove(loaiMonHoc);
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

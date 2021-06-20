﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAn.Models;
using QuanLyDoAn.ViewModels;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyDoAn.Controllers
{
    public class MonHocsController : Controller
    {
        private QLDADbContext db = new QLDADbContext();
        // GET: MonHocs
        public ActionResult Index(string maHocKy2)
        {
            ViewBag.MaHocKy2 = maHocKy2;
            var hocKy = from a in db.HocKys
                        where a.MaHocKy == maHocKy2
                        select new HocKyViewModel { TenHocKy = a.TenHocKy };
            ViewBag.HocKy = hocKy.ToList();
            return View(db.MonHocs.ToList());
        }

        public ActionResult KhoiTaoDLMH(string maMonHoc)
        {
            ViewBag.MaMonHoc = maMonHoc;
            var monHoc = from a in db.MonHocs
                        where a.MaMonHoc == maMonHoc
                        select new MonHocViewModel { TenMonHoc = a.TenMonHoc, IdLoaiMonHoc = a.IdLoaiMonHoc };
            ViewBag.MonHoc = monHoc.ToList();
            return View();
        }

        // GET: MonHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // GET: MonHocs/Create
        public ActionResult Create(string maHocKy3)
        {
            ViewBag.TenLoaiMonHoc = new SelectList(db.LoaiMonHocs, "IdLoaiMonHoc", "TenLoaiMonHoc");
            return View();
        }

        // POST: MonHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMonHoc,MaMonHoc,TenMonHoc,IdLoaiMonHoc,DieuKienTienQuyet,MaHocKy")] MonHoc monHoc, string maHocKy3)
        {
            
            monHoc.MaHocKy = maHocKy3;
            if (ModelState.IsValid)
            {
                db.MonHocs.Add(monHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monHoc);
        }

        // GET: MonHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // POST: MonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMonHoc,MaMonHoc,TenMonHoc,IdLoaiMonHoc,DieuKienTienQuyet,MaHocKy")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monHoc);
        }

        // GET: MonHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // POST: MonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonHoc monHoc = db.MonHocs.Find(id);
            db.MonHocs.Remove(monHoc);
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

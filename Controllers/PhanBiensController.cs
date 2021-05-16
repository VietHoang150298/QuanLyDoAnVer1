﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAn.Models;

namespace QuanLyDoAn.Controllers
{
    public class PhanBiensController : Controller
    {
        private QLDADbContext db = new QLDADbContext();

        // GET: PhanBiens
        public ActionResult Index()
        {
            return View(db.PhanBiens.ToList());
        }

        // GET: PhanBiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanBien phanBien = db.PhanBiens.Find(id);
            if (phanBien == null)
            {
                return HttpNotFound();
            }
            return View(phanBien);
        }


        // GET: PhanBiens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhanBiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPhanBien,MaPhanBien,ThoiKhoaBieu,MaGiangVien,MaDeTai")] PhanBien phanBien)
        {
            if (ModelState.IsValid)
            {
                db.PhanBiens.Add(phanBien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phanBien);
        }

        // GET: PhanBiens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanBien phanBien = db.PhanBiens.Find(id);
            if (phanBien == null)
            {
                return HttpNotFound();
            }
            return View(phanBien);
        }

        // POST: PhanBiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPhanBien,MaPhanBien,ThoiKhoaBieu,MaGiangVien,MaDeTai")] PhanBien phanBien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanBien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phanBien);
        }

        // GET: PhanBiens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanBien phanBien = db.PhanBiens.Find(id);
            if (phanBien == null)
            {
                return HttpNotFound();
            }
            return View(phanBien);
        }

        // POST: PhanBiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhanBien phanBien = db.PhanBiens.Find(id);
            db.PhanBiens.Remove(phanBien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DsDeTai(string maPhanBien)
        {
            return View(db.DeTais.ToList());
        }

        public ActionResult PhanCongPhanBien(string maDeTai)
        {
            return View();
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
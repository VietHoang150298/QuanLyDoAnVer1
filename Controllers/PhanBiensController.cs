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
    public class PhanBiensController : Controller
    {
        private QLDADbContext db = new QLDADbContext();

        // GET: PhanBiens
        public ActionResult Index()
        {
            var phanBien = from a in db.PhanBiens
                           join b in db.GiangViens
                           on a.MaGiangVien equals b.MaGiangVien
                           select new PhanBienViewModel
                           {
                               IdPhanBien = a.IdPhanBien,
                               MaGiangVien = a.MaGiangVien,
                               TenGiangVien = b.HoTen
                           };
            ViewBag.PhanBien = phanBien.ToList();
            return View();


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
        public ActionResult Create([Bind(Include = "IdPhanBien,MaGiangVien")] PhanBien phanBien)
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
        public ActionResult Edit([Bind(Include = "IdPhanBien,MaGiangVien")] PhanBien phanBien)
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

        public ActionResult KhoiTaoPhanBien()
        {
            return View(db.GiangViens.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KhoiTaoPhanBien([Bind(Include = "IdPhanBien,MaGiangVien")] PhanBien phanBien, string[] maGiangViens)
        {
            foreach (var maGiangVien in maGiangViens)
            {
                db.PhanBiens.Add(new PhanBien
                {
                    MaGiangVien = maGiangVien
                });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult PhanCongPhanBien(string maGiangVien)
        {

            return View(db.DeTais.Where(s => s.SoLuongPhanBien < 2).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhanCongPhanBien([Bind(Include = "IdPhanBienDeTai,MaHocKy,MaGiangVien,MaDeTai")] PhanBienDeTai phanBienDeTai, string[] maDeTais, string maGiangVien)
        {
            var hocKy = db.HocKys
                             .OrderByDescending(x => x.IdHocKy)
                             .Take(1)
                             .Select(x => x.MaHocKy)
                             .ToList()
                             .FirstOrDefault();
            foreach (var maDeTai in maDeTais)
            {
                db.PhanBienDeTais.Add(new PhanBienDeTai { 
                    MaDeTai = maDeTai,
                    MaGiangVien = maGiangVien,
                    MaHocKy = hocKy.ToString()
                });
                DeTai deTai = (from a in db.DeTais
                               where a.MaDeTai == maDeTai
                               select a).FirstOrDefault();
                deTai.SoLuongPhanBien += 1;
                db.SaveChanges();
            }
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

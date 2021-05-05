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
    public class DeTaisController : Controller
    {
        private QLDADbContext db = new QLDADbContext();

        // GET: DeTais

        public ActionResult DsDetaiTtsx()
        {
            var deTais = from a in db.DeTais
                         join b in db.SinhViens
                         on a.IdSinhVien equals b.IdSinhVien
                         join c in db.GiangVienHuongDanTheoKys
                         on a.IdGvhdTheoky equals c.IdGVHD
                         join e in db.GiangViens
                         on c.IdGiangVien equals e.IdGiangVien
                         join d in db.MonHocs
                         on a.IdMonHoc equals d.IdMonHoc
                         select new DeTaiViewModel()
                         {
                             Id = a.IdDeTai,
                             MaDeTai = a.MaDeTai,
                             TenDeTai = a.TenDeTai,
                             KetQua = a.KetQua,
                             NhanXet = a.NhanXet,
                             HoTenSinhVien = b.HoTen,
                             HoTenGvhd = e.HoTen
                         };
            ViewBag.deTais = deTais.ToList();
            return View();
        }

        // GET: DeTais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            return View(deTai);
        }

        // GET: DeTais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeTais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDeTai,MaDeTai,TenDeTai,KetQua,NhanXet,IdSinhVien,IdMonHoc,IdHoiDong,IdGvhdTheoky,LinkFileBaoCaoCuoiCung")] DeTai deTai)
        {
            if (ModelState.IsValid)
            {
                db.DeTais.Add(deTai);
                db.SaveChanges();
                return RedirectToAction("DsDetaiTtsx");
            }

            return View(deTai);
        }

        // GET: DeTais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.IdMonHoc = new SelectList(db.MonHocs, "IdMonHoc", "TenMonHoc");
            ViewBag.IdGvhdTheoky = new SelectList(db.GiangVienHuongDanTheoKys, "IdGVHD", "IdGiangVien");
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            return View(deTai);
        }

        // POST: DeTais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDeTai,MaDeTai,TenDeTai,KetQua,NhanXet,IdSinhVien,IdMonHoc,IdHoiDong,IdGvhdTheoky,LinkFileBaoCaoCuoiCung")] DeTai deTai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deTai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DsSvDangky");
            }
            return View(deTai);
        }

        // GET: DeTais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            return View(deTai);
        }

        // POST: DeTais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeTai deTai = db.DeTais.Find(id);
            db.DeTais.Remove(deTai);
            db.SaveChanges();
            return RedirectToAction("DsDetaiTtsx");
        }

        //Thêm Sinh Viên Đăng Ký Đề Tài===========================================================

        public ActionResult ThemDsSvDangKy()
        {
            return View(db.SinhViens.ToList());
        }

        [HttpPost]
        public ActionResult ThemDsSvDangKy(int? idSvdk)
        {
            DeTai sinhvienDangKy = new DeTai();
            sinhvienDangKy.IdSinhVien = idSvdk;
            db.DeTais.Add(sinhvienDangKy);
            db.SaveChanges();
            return RedirectToAction("DsDetaiTtsx");
        }


        //Thêm Sinh Viên Đăng Ký Đề Tài===========================================================
        //Danh Sách Sinh Viên Đăng Ký Đề Tài===========================================================

        public ActionResult DsSvDangky()
        {
            var svDanhky = from a in db.SinhViens
                           join b in db.DeTais
                           on a.IdSinhVien equals b.IdSinhVien
                           select new SinhVienViewModel()
                           {
                               Id = b.IdDeTai,
                               HoTen = a.HoTen,
                               HomThu = a.HomThu,
                               DienThoai = a.DienThoai,
                               TenDeTai = b.TenDeTai
                           };
            ViewBag.svDangky = svDanhky.ToList();
            return View();
        }
        //Danh Sách Sinh Viên Đăng Ký Đề Tài===========================================================

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

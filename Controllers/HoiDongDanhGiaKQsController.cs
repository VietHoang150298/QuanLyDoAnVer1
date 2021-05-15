using QuanLyDoAn.Models;
using QuanLyDoAn.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoAn.Controllers
{
    public class HoiDongDanhGiaKQsController : Controller
    {
        private QLDADbContext db = new QLDADbContext();
        // GET: HoiDongDanhGiaKQs

        public ActionResult Index()
        {
            return View(db.HoiDongDanhGiaKQs.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ThemChiTietHoiDong(string maHoiDong)
        {
            ViewBag.MaGiangVien = new SelectList(db.GiangViens, "MaGiangVien", "HoTen");
            ViewBag.MaHoiDong = new SelectList(db.HoiDongDanhGiaKQs, "MaHoiDong", "MaHoiDong");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemChiTietHoiDong([Bind(Include = "IdChiTietHoiDong,MaHoiDong,MaGiangVien1,MaGiangVien2,MaGiangVien3,MaGiangVien4,MaGiangVien5")] ChiTietHoiDong chiTietHoiDong)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHoiDongs.Add(chiTietHoiDong);
                db.SaveChanges();
                RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHoiDongDGKQ,MaHoiDong,ThoiKhoaBieu,SoLuongThanhVien,MaDeTai,MaHocKy")] HoiDongDanhGiaKQ hoiDongDanhGiaKQ)
        {
            var hocKy = db.HocKys
                             .OrderByDescending(x => x.IdHocKy)
                             .Take(1)
                             .Select(x => x.MaHocKy)
                             .ToList()
                             .FirstOrDefault();
            hoiDongDanhGiaKQ.MaHocKy = hocKy.ToString();
            if (ModelState.IsValid)
            {
                db.HoiDongDanhGiaKQs.Add(hoiDongDanhGiaKQ);
                db.SaveChanges();
                RedirectToAction("ChonHoiDong");
            }
            return RedirectToAction("Index");
        }

        public ActionResult DsDeTai(string maHoiDong)
        {
            var hoiDong = from a in db.HoiDongDanhGiaKQs
                          join b in db.DeTais
                          on a.MaHoiDong equals b.MaHoiDong
                          join c in db.SinhViens
                          on b.MaSinhVien equals c.MaSinhVien
                          join d in db.GiangViens
                          on b.MaGiangVien equals d.MaGiangVien
                          where a.MaHoiDong == maHoiDong.ToString()
                          select new DeTaiViewModel()
                          {
                              MaDeTai = b.MaDeTai,
                              TenDeTai = b.TenDeTai,
                              HoTenSinhVien = c.HoTen,
                              HoTenGvhd = d.HoTen
                          };
            ViewBag.dsHoiDong = hoiDong.ToList();
            return View();
        }
    }
}
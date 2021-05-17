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

        public ActionResult DanhSachPhanCongHD()
        {
            return View(db.HoiDongDanhGiaKQs.Where(s => s.SoLuongThanhVien > 0).ToList());
        }
        
        public ActionResult PhanCongThanhVienHD(string maHoiDong)
        {
            return View(db.GiangViens.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhanCongThanhVienHD([Bind(Include = "IdChiTietHoiDong,MaHoiDong,MaGiangVien")] ChiTietHoiDong chiTietHoiDong, string[] maGiangViens, string maHoiDong)
        {
            foreach (var maGiangVien in maGiangViens)
            {
                db.ChiTietHoiDongs.Add(new ChiTietHoiDong { 
                    MaHoiDong = maHoiDong,
                    MaGiangVien = maGiangVien
                });
                HoiDongDanhGiaKQ hoiDongDanhGiaKQ = (from a in db.HoiDongDanhGiaKQs
                               where a.MaHoiDong == maHoiDong
                               select a).SingleOrDefault();
                hoiDongDanhGiaKQ.SoLuongThanhVien -= 1;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //public ActionResult DsDeTai(string maHoiDong)
        //{
        //    var hoiDong = from a in db.HoiDongDanhGiaKQs
        //                  join b in db.DeTais
        //                  on a.MaHoiDong equals b.MaHoiDong
        //                  join c in db.SinhViens
        //                  on b.MaSinhVien equals c.MaSinhVien
        //                  join d in db.GiangViens
        //                  on b.MaGiangVien equals d.MaGiangVien
        //                  where a.MaHoiDong == maHoiDong.ToString()
        //                  select new DeTaiViewModel()
        //                  {
        //                      MaDeTai = b.MaDeTai,
        //                      TenDeTai = b.TenDeTai,
        //                      HoTenSinhVien = c.HoTen,
        //                      HoTenGvhd = d.HoTen
        //                  };
        //    ViewBag.dsHoiDong = hoiDong.ToList();
        //    return View();
        //}
    }
}
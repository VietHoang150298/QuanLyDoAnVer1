using QuanLyDoAn.Models;
using QuanLyDoAn.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoAn.Controllers
{
    public class HoiDongDanhGiaKQsController : Controller
    {
        private readonly QLDADbContext db = new QLDADbContext();
        // GET: HoiDongDanhGiaKQs

        public ActionResult Index(string maMonHoc)
        {
            ViewBag.MaMonHoc = maMonHoc;
            return View(db.HoiDongDanhGiaKQs.Where(s => s.MaMonHoc == maMonHoc).ToList());
        }

        public ActionResult Create(string maMonHoc)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHoiDongDGKQ,MaHoiDong,ThoiKhoaBieu,SoLuongThanhVien,DemSoLuongThanhVien,MaMonHoc")] HoiDongDanhGiaKQ hoiDongDanhGiaKQ, string maMonHoc)
        {

            if (ModelState.IsValid)
            {
                if (db.HoiDongDanhGiaKQs.Any(x => x.MaHoiDong == hoiDongDanhGiaKQ.MaHoiDong))
                {
                    ModelState.AddModelError("maHoiDong", "Mã Hội Đồng Đã Tồn Tại!");
                    return View("Create");
                }
                db.HoiDongDanhGiaKQs.Add(hoiDongDanhGiaKQ);
                db.SaveChanges();
                return RedirectToAction("Index", "HoiDongDanhGiaKQs", new { maMonHoc });
            }
            return RedirectToAction("Index", "HoiDongDanhGiaKQs", new { maMonHoc });
        }

        public ActionResult DanhSachPhanCongHD(string maMonHoc)
        {
            ViewBag.MaMonHoc = maMonHoc;
            return View(db.HoiDongDanhGiaKQs.Where(s => s.MaMonHoc == maMonHoc).Where(s => s.DemSoLuongThanhVien < s.SoLuongThanhVien).ToList());
        }

        public ActionResult PhanCongThanhVienHD(string maHoiDong, string maMonHoc)
        {
            return View(db.GiangViens.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhanCongThanhVienHD([Bind(Include = "IdChiTietHoiDong,MaHoiDong,MaGiangVien")] ChiTietHoiDong chiTietHoiDong, string[] maGiangViens, string maHoiDong, string maMonHoc)
        {
            foreach (var maGiangVien in maGiangViens)
            {
                db.ChiTietHoiDongs.Add(new ChiTietHoiDong
                {
                    MaHoiDong = maHoiDong,
                    MaGiangVien = maGiangVien
                });
                HoiDongDanhGiaKQ hoiDongDanhGiaKQ = (from a in db.HoiDongDanhGiaKQs
                                                     where a.MaHoiDong == maHoiDong
                                                     select a).FirstOrDefault();
                hoiDongDanhGiaKQ.DemSoLuongThanhVien += 1;
            }
            HoiDongDanhGiaKQ hoiDongDanhGiaKQ2 = (from a in db.HoiDongDanhGiaKQs
                                                  where a.MaHoiDong == maHoiDong
                                                  select a).FirstOrDefault();
            if (hoiDongDanhGiaKQ2.DemSoLuongThanhVien <= hoiDongDanhGiaKQ2.SoLuongThanhVien)
            {
                db.SaveChanges();
            }
            else
            {
                ViewBag.ErrorMessage = "Vượt quá số lượng thành viên, mời chọn lại!";
                return RedirectToAction("PhanCongThanhVienHD", new { maHoiDong });
            }
            return RedirectToAction("DanhSachPhanCongHD", new { maMonHoc});
        }

        public ActionResult PhanCongDanhGia(string maHoiDong, string maMonHoc)
        {
            //return View(db.DeTais.Where(m => m.MaMonHoc == maMonHoc).Where(s => s.MaHoiDong == null).ToList());
            return View(db.DeTais.Where(m => m.MaMonHoc == maMonHoc).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult PhanCongDanhGia([Bind(Include = "IdDeTai,MaDeTai,TenDeTai,LinkFileBaoCaoCuoiCung,MaMonHoc,MaSinhVien,MaGiangVien,MaHoiDong,SoLuongPhanBien")] DeTai deTai, int[] idDeTais, string maHoiDong, string maMonHoc)
        {
            for (int i = 0; i < idDeTais.Count(); i++)
            {
                DeTai dsDeTai = db.DeTais.Find(Convert.ToInt32(idDeTais[i]));
                dsDeTai.MaHoiDong = maHoiDong;
                db.Entry(dsDeTai).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "HoiDongDanhGiaKQs", new { maMonHoc });
        }

        public ActionResult Edit(int? id, string maMonHoc)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoiDongDanhGiaKQ hoiDongDanhGiaKQ = db.HoiDongDanhGiaKQs.Find(id);

            if (hoiDongDanhGiaKQ == null)
            {
                return HttpNotFound();
            }
            return View(hoiDongDanhGiaKQ);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHoiDongDGKQ,MaHoiDong,ThoiKhoaBieu,SoLuongThanhVien,DemSoLuongThanhVien,MaMonHoc")] HoiDongDanhGiaKQ hoiDongDanhGiaKQ, string maMonHoc)
        {
            hoiDongDanhGiaKQ.DemSoLuongThanhVien = 0;
            if (ModelState.IsValid)
            {
                db.Entry(hoiDongDanhGiaKQ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "HoiDongDanhGiaKQs", new { maMonHoc});
            }
            return RedirectToAction("Index", "HoiDongDanhGiaKQs", new { maMonHoc });
        }
        //======================================Chi Tiết Hội Đồng=============================
        public ActionResult ChiTietHoiDong(string maHoiDong)
        {
            var chiTietHoiDong = from a in db.ChiTietHoiDongs
                                 join b in db.HoiDongDanhGiaKQs
                                 on a.MaHoiDong equals b.MaHoiDong
                                 join c in db.GiangViens
                                 on a.MaGiangVien equals c.MaGiangVien
                                 where b.MaHoiDong == maHoiDong
                                 select new ChiTietHoiDongViewModel
                                 {
                                     MaHoiDong = b.MaHoiDong,
                                     MaGiangVien = a.MaGiangVien,
                                     TenGiangVien = c.HoTen
                                 };
            ViewBag.ChiTietHoiDong = chiTietHoiDong.ToList();
            return View();
        }
        //======================================Chi Tiết Hội Đồng=============================
    }
}
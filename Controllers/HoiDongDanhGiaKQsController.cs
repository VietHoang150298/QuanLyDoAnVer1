using QuanLyDoAn.Models;
using QuanLyDoAn.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoAn.Controllers
{
    public class HoiDongDanhGiaKQsController : Controller
    {
        private QLDADbContext db = new QLDADbContext();
        // GET: HoiDongDanhGiaKQs

        public ActionResult Index(string maMonHoc)
        {
            ViewBag.MaMonHoc = maMonHoc;
            return View(db.HoiDongDanhGiaKQs.ToList());
        }
        public ActionResult Create(string maMonHoc)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHoiDongDGKQ,MaHoiDong,ThoiKhoaBieu,SoLuongThanhVien,DemSoLuongThanhVien,MaMonHoc")] HoiDongDanhGiaKQ hoiDongDanhGiaKQ, string maMonHoc)
        {
            hoiDongDanhGiaKQ.DemSoLuongThanhVien = 0;
            hoiDongDanhGiaKQ.MaMonHoc = maMonHoc;
            if (ModelState.IsValid)
            {
                db.HoiDongDanhGiaKQs.Add(hoiDongDanhGiaKQ);
                db.SaveChanges();
                RedirectToAction("ChonHoiDong");
            }
            return RedirectToAction("Index", "HoiDongDanhGiaKQs", new { maMonHoc });
        }

        public ActionResult DanhSachPhanCongHD()
        {
            return View(db.HoiDongDanhGiaKQs.Where(s => s.DemSoLuongThanhVien < s.SoLuongThanhVien).ToList());
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
                hoiDongDanhGiaKQ.DemSoLuongThanhVien += 1;
            }
            HoiDongDanhGiaKQ hoiDongDanhGiaKQ2 = (from a in db.HoiDongDanhGiaKQs
                                                 where a.MaHoiDong == maHoiDong
                                                 select a).SingleOrDefault();
            if (hoiDongDanhGiaKQ2.DemSoLuongThanhVien <= hoiDongDanhGiaKQ2.SoLuongThanhVien)
            {
                db.SaveChanges();
            }
            else
            {
                ViewBag.ErrorMessage = "Vượt quá số lương thành viên, mời chọn lại!";
                return RedirectToAction("PhanCongThanhVienHD");
            }
            return RedirectToAction("DanhSachPhanCongHD");
        }

        public ActionResult PhanCongDanhGia(string maHoiDong, string maMonHoc)
        {
            //return View(db.DeTais.Where(m => m.MaMonHoc == maMonHoc).Where(s => s.MaHoiDong == null).ToList());
            return View(db.DeTais.Where(m => m.MaMonHoc == maMonHoc).ToList());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult PhanCongDanhGia([Bind(Include = "IdDeTai,MaDeTai,TenDeTai,LinkFileBaoCaoCuoiCung,MaMonHoc,MaSinhVien,MaGiangVien,MaHoiDong,SoLuongPhanBien")] DeTai deTai,int[] idDeTais, string maHoiDong)
        {
            for (int i = 0; i < idDeTais.Count(); i++)
            {
                DeTai dsDeTai = db.DeTais.Find(Convert.ToInt32(idDeTais[i]));
                dsDeTai.MaHoiDong = maHoiDong;
                db.Entry(dsDeTai).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "IdHoiDongDGKQ,MaHoiDong,ThoiKhoaBieu,SoLuongThanhVien,DemSoLuongThanhVien,MaMonHoc")] HoiDongDanhGiaKQ hoiDongDanhGiaKQ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoiDongDanhGiaKQ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hoiDongDanhGiaKQ);
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
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
        public ActionResult Index(string maMonHoc)
        {
            var phanBien = from a in db.PhanBiens
                           join b in db.GiangViens
                           on a.MaGiangVien equals b.MaGiangVien
                           join c in db.MonHocs
                           on a.MaMonHoc equals maMonHoc
                           select new PhanBienViewModel
                           {
                               IdPhanBien = a.IdPhanBien,
                               MaGiangVien = a.MaGiangVien,
                               TenGiangVien = b.HoTen,
                               MaMonHoc = maMonHoc
                           };
            ViewBag.PhanBien = phanBien.Distinct().ToList();
            ViewBag.MaMonHoc = maMonHoc;
            return View();


        }

        //============================Chi Tiết Phản Biện=================================================
        public ActionResult ChiTietPhanBien(string maGiangVien)
        {
            ViewBag.maGiangVien = maGiangVien;
            var phanBienDeTais = from a in db.PhanBienDeTais
                                 where a.MaGiangVien == maGiangVien
                                 join b in db.GiangViens
                                 on a.MaGiangVien equals b.MaGiangVien
                                 group a by a.MaDeTai
                                 into c
                                 join d in db.DeTais
                                 on c.Key equals d.MaDeTai
                                 select new PhanBienViewModel
                                 {
                                     MaDeTai =  c.Key,
                                     TenDeTai = d.TenDeTai
                                 };
            ViewBag.phanBienDeTais = phanBienDeTais.Distinct().ToList();
            return View();
        }
        //============================Chi Tiết Phản Biện=================================================

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

        public ActionResult KhoiTaoPhanBien(string maMonHoc)
        {
            return View(db.GiangViens.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KhoiTaoPhanBien(string[] maGiangViens, string maMonHoc)
        {
            foreach (var maGiangVien in maGiangViens)
            {
                db.PhanBiens.Add(new PhanBien
                {
                    MaGiangVien = maGiangVien,
                    MaMonHoc = maMonHoc
                });
                db.SaveChanges();
            }
            return RedirectToAction("Index","PhanBiens",new { maMonHoc});
        }
        //Danh sách Dề Tài ====================================================================================================
        public ActionResult DanhSachDeTai(string maMonHoc, string searchString)
        {
            ViewBag.ErrorFlag = 0;
            var monHoc = from a in db.MonHocs
                         where a.MaMonHoc == maMonHoc
                         select new MonHocViewModel { TenMonHoc = a.TenMonHoc, IdLoaiMonHoc = a.IdLoaiMonHoc };
            ViewBag.MonHoc = monHoc.ToList();
            ViewBag.MaMonHoc = maMonHoc;
            var DeTais = from dt in db.DeTais
                         where dt.MaMonHoc == maMonHoc && dt.SoLuongPhanBien !=2
                         select dt;
            if (!String.IsNullOrEmpty(searchString))
            {
                DeTais = DeTais.Where(s => s.TenDeTai.Contains(searchString) || s.MaSinhVien.Contains(searchString));
            }
            return View(DeTais.ToList());
        }
        //Danh sách Dề Tài ====================================================================================================

        // Phân công phản biện=============================================================================
        public ActionResult PhanCongPhanBien(string maMonHoc, string maDeTai)
        {
            var giangVienHd = from a in db.DeTais
                              where a.MaDeTai == maDeTai && a.MaMonHoc == maMonHoc
                              select a.MaGiangVien;
            var phanBienDeTai = from a in db.PhanBienDeTais
                                where a.MaDeTai == maDeTai
                                select a.MaGiangVien;
            var dsPhanBien = from a in db.PhanBiens
                             join b in db.GiangViens
                             on a.MaGiangVien equals b.MaGiangVien
                             where a.MaGiangVien != giangVienHd.FirstOrDefault() && a.MaGiangVien != phanBienDeTai.FirstOrDefault()
                             select new PhanBienViewModel
                             {
                                 MaGiangVien = a.MaGiangVien,
                                 HoTen = b.HoTen,
                                 HomThu = b.HomThu,
                                 DonViCongTac = b.DonViCongTac,
                                 DienThoai = b.DienThoai
                             };
            ViewBag.DsPhanBien = dsPhanBien.Distinct().ToList();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult PhanCongPhanBien(string maDeTai, string[] maGiangViens, string maMonHoc)
        {
            var Count = 0;
            var soLuongPhanBienToiDa = (from mh in db.MonHocs
                                        where mh.MaMonHoc == maMonHoc
                                        select mh.SoLuongPhanBienToiDa).Single();
            foreach (var maGiangVien in maGiangViens)
            {
                db.PhanBienDeTais.Add(new PhanBienDeTai
                {
                    MaDeTai = maDeTai,
                    MaGiangVien = maGiangVien,
                    MaMonHoc = maMonHoc
                });
                DeTai deTai = (from a in db.DeTais
                               where a.MaDeTai == maDeTai && a.MaMonHoc == maMonHoc && a.MaHoiDong != null
                               select a).FirstOrDefault();
                deTai.SoLuongPhanBien += 1;
                Count = (int)deTai.SoLuongPhanBien;
            }

            if (Count <= soLuongPhanBienToiDa)
            {
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("DanhSachDeTai", "PhanBiens", new { maMonHoc });
            }
            return RedirectToAction("DanhSachDeTai", "PhanBiens", new { maMonHoc });
        }
        // Phân công phản biện=============================================================================

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

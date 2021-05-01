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
    public class GiangVienHuongDanTheoKysController : Controller
    {
        private QLDADbContext db = new QLDADbContext();

        // GET: GiangVienHuongDanTheoKys
        public ActionResult Index()
        {
            var GvhdTheoKy = from a in db.GiangVienHuongDanTheoKys
                             join b in db.GiangViens
                             on a.IdGiangVien equals b.Id
                             select new GiangVienHuongDanViewModel
                             {
                                 Id = a.Id,
                                 HoTen = b.HoTen,
                                 SoLuongSinhVienHuongDan = a.SoLuongSinhVienHuongDan
                             };
            ViewBag.GvhdTheoky = GvhdTheoKy.ToList();
            return View();
        }

        // GET: GiangVienHuongDanTheoKys/Create

        //Edit GET Method
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.IdHocky = new SelectList(db.HocKys, "Id", "TenHocKy");
            GiangVienHuongDanTheoKy giangVienHuongDanTheoKy = db.GiangVienHuongDanTheoKys.Find(id);
            if (giangVienHuongDanTheoKy == null)
            {
                return HttpNotFound();
            }
            return View(giangVienHuongDanTheoKy);
        }
        // POST: GiangVienHuongDanTheoKys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdGiangVien,IdHocKy,SoLuongSinhVienHuongDan")] GiangVienHuongDanTheoKy giangVienHuongDanTheoKy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giangVienHuongDanTheoKy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giangVienHuongDanTheoKy);
        }

        //public ActionResult EditGvhdTheoKy(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    //GiangVienHuongDanTheoKy giangVienHuongDanTheoKy = db.GiangVienHuongDanTheoKys.Find(idGv);
        //    var model = from a in db.GiangVienHuongDanTheoKys where a.IdGiangVien == id
        //                select new GiangVienHuongDanTheoKy()
        //                {
        //                    IdGiangVien = a.IdGiangVien,
        //                    IdHocKy = a.IdHocKy,
        //                    SoLuongSinhVienHuongDan = a.SoLuongSinhVienHuongDan
        //                };
            
        //    //GiangVienHuongDanTheoKy giangVienHuongDanTheoKy = new GiangVienHuongDanTheoKy() { IdGiangVien = model};
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditGvhdTheoKy([Bind(Include = "Id,IdGiangVien,IdHocKy,SoLuongSinhVienHuongDan")] GiangVienHuongDanTheoKy giangVienHuongDanTheoKy)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(giangVienHuongDanTheoKy).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(giangVienHuongDanTheoKy);
        //}

        // GET: GiangVienHuongDanTheoKys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiangVienHuongDanTheoKy giangVienHuongDanTheoKy = db.GiangVienHuongDanTheoKys.Find(id);
            if (giangVienHuongDanTheoKy == null)
            {
                return HttpNotFound();
            }
            return View(giangVienHuongDanTheoKy);
        }

        // POST: GiangVienHuongDanTheoKys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiangVienHuongDanTheoKy giangVienHuongDanTheoKy = db.GiangVienHuongDanTheoKys.Find(id);
            db.GiangVienHuongDanTheoKys.Remove(giangVienHuongDanTheoKy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ThemDsGVHD()
        {
            return View(db.GiangViens.ToList());
        }


        [HttpPost]
        public ActionResult ThemDsGVHD(int? idGVHD)
        {
            GiangVienHuongDanTheoKy gvhdTheoKy = new GiangVienHuongDanTheoKy();
            gvhdTheoKy.IdGiangVien = idGVHD;
            db.GiangVienHuongDanTheoKys.Add(gvhdTheoKy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public List<GiangVienHuongDanTheoKy> GVHDtheoKy(int Id)
        //{
        //    GiangVienHuongDanTheoKy gvhdTheoKy = new GiangVienHuongDanTheoKy();
        //    List<GiangVienHuongDanTheoKy> listGvhdTheoKy = new List<GiangVienHuongDanTheoKy>();
        //    gvhdTheoKy.IdGiangVien = Id;
        //    listGvhdTheoKy.Add(gvhdTheoKy);
        //    return listGvhdTheoKy;
        //}

        public ActionResult DanhSachGVHD()
        {
            ViewBag.Hocky = db.HocKys.FirstOrDefault().TenHocKy.ToString();
            var model = from a in db.GiangVienHuongDanTheoKys
                        join b in db.HocKys
                        on a.IdHocKy equals b.Id
                        join c in db.GiangViens
                        on a.IdGiangVien equals c.Id
                        select new GiangVienHuongDanViewModel()
                        {
                            MaGiangVien = c.MaGiangVien,
                            HoTen = c.HoTen,
                            HomThu = c.HomThu,
                            DonViCongTac = c.DonViCongTac,
                            TenHocKy = b.TenHocKy,
                            NamBatDau = b.NamBatDau,
                            NamKetThuc = b.NamKetThuc
                        };
            ViewBag.GVHD = model.ToList();
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

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
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyDoAn.Controllers
{
    public class KetQuasController : Controller
    {
        private QLDADbContext db = new QLDADbContext();

        // GET: KetQuas
        public ActionResult Index()
        {
            var ketQua = from a in db.KetQuas
                         join b in db.GiangViens
                         on a.MaGiangVien equals b.MaGiangVien
                         join c in db.HoiDongDanhGiaKQs
                         on a.MaHoiDong equals c.MaHoiDong
                         join d in db.DeTais
                         on a.MaDeTai equals d.MaDeTai
                         select new KetQuaViewModel
                         {
                             IdKetQua = a.IdKetQua,
                             MaHoiDong = c.MaHoiDong,
                             TenGiangVien = b.HoTen,
                             TenDeTai = d.TenDeTai,
                             DiemSo = a.DiemSo,
                             IsPhanBien = a.IsPhanBien
                         };
            ViewBag.KetQua = ketQua.ToList();
            return View();
        }

        // GET: KetQuas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            return View(ketQua);
        }

        // GET: KetQuas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KetQuas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdKetQua,MaHoiDong,MaGiangVien,MaDeTai,DiemSo,NhanXet,IsPhanBien")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                db.KetQuas.Add(ketQua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ketQua);
        }

        // GET: KetQuas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            return View(ketQua);
        }

        // POST: KetQuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdKetQua,MaHoiDong,MaGiangVien,MaDeTai,DiemSo,NhanXet,IsPhanBien")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ketQua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ketQua);
        }

        // GET: KetQuas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            return View(ketQua);
        }

        // POST: KetQuas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KetQua ketQua = db.KetQuas.Find(id);
            db.KetQuas.Remove(ketQua);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Import File Excel============================================================================
        [HttpPost]

        public ActionResult Doc_File_Excel(HttpPostedFileBase excelfile)
        {
            if (excelfile == null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Please select an excel file";
                return View("Index");
            }
            else
            {
                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Content/ExcelFiles/" + excelfile.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelfile.SaveAs(path);
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    List<KetQua> DsKetQua = new List<KetQua>();
                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        KetQua ketQua = new KetQua();
                        ketQua.MaHoiDong = ((Excel.Range)range.Cells[row, 1]).Text;
                        ketQua.MaGiangVien = ((Excel.Range)range.Cells[row, 2]).Text;
                        ketQua.MaDeTai = ((Excel.Range)range.Cells[row, 3]).Text;
                        ketQua.DiemSo = float.Parse(((Excel.Range)range.Cells[row, 4]).Text);
                        ketQua.NhanXet = ((Excel.Range)range.Cells[row, 5]).Text;
                        DsKetQua.Add(ketQua);
                        db.KetQuas.Add(ketQua);
                    }
                    db.SaveChanges();
                    workbook.Close(0);
                    application.Quit();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "File type is incorrect<br>";
                    return View("Index");
                }
            }
        }

        //Import File Excel============================================================================

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

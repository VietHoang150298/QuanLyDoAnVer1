using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAn.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyDoAn.Controllers
{
    public class GiangVienHdSinhViensController : Controller
    {
        private QLDADbContext db = new QLDADbContext();

        // GET: GiangVienHdSinhViens
        public ActionResult Index(string maHocKy)
        {
            ViewBag.MaHocKy = maHocKy;
            var tenHocKy = from a in db.HocKys
                           where a.MaHocKy == maHocKy
                           select a.TenHocKy;
            ViewBag.TenHocKy = tenHocKy.FirstOrDefault();
            return View(db.GiangVienHdSinhViens.Where(s => s.MaHocKy == maHocKy).ToList());
        }

        //Import File Excel============================================================================
        [HttpPost]

        public ActionResult Doc_File_Excel(HttpPostedFileBase excelfile, string maHocKy)
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
                    List<GiangVienHdSinhVien> DsGiangVienHdSinhViens = new List<GiangVienHdSinhVien>();
                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        GiangVienHdSinhVien giangVienHdSinhVien = new GiangVienHdSinhVien();
                        giangVienHdSinhVien.MaSinhVien = ((Excel.Range)range.Cells[row, 1]).Text;
                        giangVienHdSinhVien.TenSinhVien = ((Excel.Range)range.Cells[row, 2]).Text;
                        giangVienHdSinhVien.MaGiangVien = ((Excel.Range)range.Cells[row, 3]).Text;
                        giangVienHdSinhVien.TenGiangVien = ((Excel.Range)range.Cells[row, 4]).Text;
                        giangVienHdSinhVien.MaHocKy = maHocKy;
                        DsGiangVienHdSinhViens.Add(giangVienHdSinhVien);
                        db.GiangVienHdSinhViens.Add(giangVienHdSinhVien);
                    }
                    db.SaveChanges();
                    workbook.Close(0);
                    application.Quit();
                    return RedirectToAction("Index", "GiangVienHdSinhViens", new { maHocKy});
                }
                else
                {
                    ViewBag.Error = "File type is incorrect<br>";
                    return View("Index", "GiangVienHdSinhViens", new { maHocKy });
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

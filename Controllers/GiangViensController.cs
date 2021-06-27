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
    public class GiangViensController : Controller
    {
        private QLDADbContext db = new QLDADbContext();

        // GET: GiangViens
        public ActionResult Index(string maHocKy)
        {
            ViewBag.MaHocKy = maHocKy;
            var hocKy = from a in db.HocKys
                        where a.MaHocKy == maHocKy
                        select new HocKyViewModel { TenHocKy = a.TenHocKy };
            ViewBag.HocKy = hocKy.ToList();
            return View(db.GiangViens.Where(s => s.MaHocKy == maHocKy).ToList());
        }

        // GET: GiangViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiangVien giangVien = db.GiangViens.Find(id);
            if (giangVien == null)
            {
                return HttpNotFound();
            }
            return View(giangVien);
        }

        // GET: GiangViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiangViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGiangVien,MaGiangVien,HoDem,Ten,HoTen,HomThu,DonViCongTac,DienThoai,MaBoMon,MaHocKy")] GiangVien giangVien)
        {
            if (ModelState.IsValid)
            {
                giangVien.MaHocKy = db.HocKys.LastOrDefault().MaHocKy;
                db.GiangViens.Add(giangVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giangVien);
        }

        //Import File Excel============================================================================
        [HttpPost]

        public ActionResult Doc_File_Excel(HttpPostedFileBase excelfile, string maHocKy)
        {
            ViewBag.MaHocKy = maHocKy;
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
                    List<GiangVien> DsGiangVien = new List<GiangVien>();
                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        GiangVien giangVien = new GiangVien();
                        giangVien.MaGiangVien = ((Excel.Range)range.Cells[row, 1]).Text;
                        giangVien.HoDem = ((Excel.Range)range.Cells[row, 2]).Text;
                        giangVien.Ten = ((Excel.Range)range.Cells[row, 3]).Text;
                        giangVien.HoTen = ((Excel.Range)range.Cells[row, 4]).Text;
                        giangVien.HomThu = ((Excel.Range)range.Cells[row, 5]).Text;
                        giangVien.MaBoMon = ((Excel.Range)range.Cells[row, 6]).Text;
                        giangVien.DonViCongTac = ((Excel.Range)range.Cells[row, 7]).Text;
                        giangVien.DienThoai = ((Excel.Range)range.Cells[row, 8]).Text;
                        giangVien.MaHocKy = maHocKy;
                        DsGiangVien.Add(giangVien);
                        db.GiangViens.Add(giangVien);
                    }
                    db.SaveChanges();
                    workbook.Close(0);
                    application.Quit();
                    return RedirectToAction("Index","GiangViens", new { maHocKy});
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

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
using PagedList;

namespace QuanLyDoAn.Controllers
{
    public class SinhViensController : Controller
    {
        private QLDADbContext db = new QLDADbContext();

        // GET: SinhViens
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            var hocKy = db.HocKys
                             .OrderByDescending(x => x.IdHocKy)
                             .Take(1)
                             .Select(x => x.TenHocKy )
                             .ToList()
                             .FirstOrDefault();
            ViewBag.HocKy = hocKy;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var sinhViens = from s in db.SinhViens
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sinhViens = sinhViens.Where(s => s.HoTen.Contains(searchString) || s.MaSinhVien.Contains(searchString));
            }

            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(sinhViens.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: SinhViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSinhVien,MaSinhVien,HoDem,Ten,HoTen,HomThu,MaLop,DienThoai,TinChiTichLuy,DiemTichLuy,MaHocKy")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sinhVien);
        }

        //Import File Excel============================================================================

        [HttpPost]

        public ActionResult Doc_File_Excel(HttpPostedFileBase excelfile)
        {
            var hocKy = db.HocKys
                             .OrderByDescending(x => x.IdHocKy)
                             .Take(1)
                             .Select(x => x.MaHocKy)
                             .ToList()
                             .FirstOrDefault();
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
                    List<SinhVien> DsSinhVien = new List<SinhVien>();
                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        SinhVien sinhVien = new SinhVien();
                        sinhVien.MaSinhVien = ((Excel.Range)range.Cells[row, 1]).Text;
                        sinhVien.HoDem = ((Excel.Range)range.Cells[row, 2]).Text;
                        sinhVien.Ten = ((Excel.Range)range.Cells[row, 3]).Text;
                        sinhVien.HoTen = ((Excel.Range)range.Cells[row, 4]).Text;
                        sinhVien.HomThu = ((Excel.Range)range.Cells[row, 5]).Text;
                        sinhVien.MaLop = ((Excel.Range)range.Cells[row, 6]).Text;
                        sinhVien.DienThoai = ((Excel.Range)range.Cells[row, 7]).Text;
                        sinhVien.TinChiTichLuy = Convert.ToInt32(((Excel.Range)range.Cells[row, 8]).Text);
                        sinhVien.DiemTichLuy = float.Parse(((Excel.Range)range.Cells[row, 9]).Text);
                        sinhVien.MaHocKy = hocKy.ToString();
                        DsSinhVien.Add(sinhVien);
                        db.SinhViens.Add(sinhVien);
                    }
                    db.SaveChanges();
                    workbook.Close(0);
                    application.Quit();
                    //ViewBag.DS_DeTais = DS_DeTais;
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

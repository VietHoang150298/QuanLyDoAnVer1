using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAn.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyDoAn.Controllers
{
    public class DeTaisController : Controller
    {
        private QLDADbContext db = new QLDADbContext();
        // GET: DeTais

        public ActionResult Index(string maMonHoc2)
        {
            var hocKy = db.HocKys
                             .OrderByDescending(x => x.IdHocKy)
                             .Take(1)
                             .Select(x => x.TenHocKy)
                             .ToList()
                             .FirstOrDefault();
            ViewBag.HocKy = hocKy.ToString();
            ViewBag.MaMonHoc = maMonHoc2;
            var DeTais = from dt in db.DeTais
                         where dt.MaMonHoc == maMonHoc2
                         select dt;
            return View(DeTais.ToList());
        }

        // GET: DeTais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTais = db.DeTais.Find(id);
            if (deTais == null)
            {
                return HttpNotFound();
            }
            return View(deTais);
        }

        public ActionResult XemFileBaoCao(string linkFileBaoCao)
        {
            return Redirect("https://localhost:44347/" + linkFileBaoCao);
        }

        // GET: DeTais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeTais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDeTai,MaDeTai,TenDeTai,LinkFileBaoCaoCuoiCung,MaMonHoc,MaSinhVien,MaGiangVien,MaHoiDong")] DeTai deTai)
        {
            if (ModelState.IsValid)
            {
                db.DeTais.Add(deTai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deTai);
        }

        // GET: DeTais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.maHoiDong = new SelectList(db.HoiDongDanhGiaKQs, "MaHoiDong", "MaHoiDong");
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            return View(deTai);
        }

        // POST: DeTais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDeTai,MaDeTai,TenDeTai, LinkFileBaoCaoCuoiCung,MaMonHoc,MaSinhVien,MaGiangVien,MaHoiDong")] DeTai deTai, HttpPostedFileBase inputFileBaoCao)
        {
            if (inputFileBaoCao != null)
            {
                string extensionName = System.IO.Path.GetExtension(inputFileBaoCao.FileName);
                string path = "/Content/FileBaoCaos/" + extensionName;
                string urlImg = System.IO.Path.Combine(Server.MapPath("~/Content/FileBaoCaos/") + extensionName);
                inputFileBaoCao.SaveAs(urlImg);
                //tours.avatar = path;
                deTai.LinkFileBaoCaoCuoiCung = path;
            }
            if (ModelState.IsValid)
            {
                db.Entry(deTai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deTai);
        }


        //Import File Excel============================================================================
        [HttpPost]

        public ActionResult Doc_File_Excel(HttpPostedFileBase excelfile, string maMonHoc2)
        {
            var hocKy = db.HocKys
                             .OrderByDescending(x => x.IdHocKy)
                             .Take(1)
                             .Select(x => x.MaHocKy)
                             .ToList()
                             .FirstOrDefault();
            ViewBag.HocKy = hocKy;
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
                    List<DeTai> DsDeTai = new List<DeTai>();
                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        DeTai deTai = new DeTai();
                        deTai.MaDeTai = ((Excel.Range)range.Cells[row, 1]).Text;
                        deTai.TenDeTai = ((Excel.Range)range.Cells[row, 2]).Text;
                        deTai.MaSinhVien = ((Excel.Range)range.Cells[row, 3]).Text;
                        deTai.MaGiangVien = ((Excel.Range)range.Cells[row, 4]).Text;
                        deTai.MaMonHoc = ((Excel.Range)range.Cells[row, 5]).Text;
                        deTai.SoLuongPhanBien = 0;
                        DsDeTai.Add(deTai);
                        db.DeTais.Add(deTai);
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

        // Chuyển giai đoạn=============================================================================

        public ActionResult DuyetDiem(string maMonHoc2)
        {
            var DeTaisTTTN = from dt in db.DeTais
                             join kq in db.KetQuas
                             on dt.MaDeTai equals kq.MaDeTai
                             where kq.DiemSo > 8
                             select dt;
            foreach (var item in DeTaisTTTN)
            {
                db.DeTais.Add(new DeTai()
                {
                    MaDeTai = item.MaDeTai,
                    TenDeTai = item.TenDeTai,
                    LinkFileBaoCaoCuoiCung = item.LinkFileBaoCaoCuoiCung,
                    MaMonHoc = maMonHoc2,
                    MaSinhVien = item.MaSinhVien,
                    MaGiangVien = item.MaGiangVien,
                    MaHoiDong = item.MaHoiDong,
                    SoLuongPhanBien = item.SoLuongPhanBien
                });
            }
            db.SaveChanges();
            return RedirectToAction("Index", "DeTais", new { maMonHoc2 });
        }

        // Chuyển giai đoạn=============================================================================

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

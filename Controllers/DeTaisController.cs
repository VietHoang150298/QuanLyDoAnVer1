using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAn.Models;
using QuanLyDoAn.ViewModels;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyDoAn.Controllers
{
    public class DeTaisController : Controller
    {
        private QLDADbContext db = new QLDADbContext();
        // GET: DeTais

        public ActionResult Index(string maMonHoc)
        {
            ViewBag.ErrorFlag = 0;
            var monHoc = from a in db.MonHocs
                         where a.MaMonHoc == maMonHoc
                         select new MonHocViewModel { TenMonHoc = a.TenMonHoc, IdLoaiMonHoc = a.IdLoaiMonHoc };
            ViewBag.MonHoc = monHoc.ToList();
            ViewBag.MaMonHoc = maMonHoc;
            var DeTais = from dt in db.DeTais
                         where dt.MaMonHoc == maMonHoc
                         select dt;
            return View(DeTais.ToList());
        }

        public ActionResult DSDTHoanThanhDoAn(string maMonHoc)
        {
            return View(db.DeTais.Where(s => s.MaMonHoc == maMonHoc).Where(p => p.MaHoiDong == null).ToList());
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

        public ActionResult Doc_File_Excel(HttpPostedFileBase excelfile, string maMonHoc)
        {
            var monHoc = from a in db.MonHocs
                         where a.MaMonHoc == maMonHoc
                         select new MonHocViewModel { TenMonHoc = a.TenMonHoc };
            ViewBag.MonHoc = monHoc.ToList();
            try
            {
                if (excelfile == null || excelfile.ContentLength == 0)
                {
                    ViewBag.ErrorFlag = 1;
                    ViewBag.Error = "Hãy chọn một file Excel!";
                    return RedirectToAction("Index", "DeTais", new { maMonHoc });
                }
                else
                {
                    if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                    {
                        ViewBag.ErrorFlag = 0;
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
                            deTai.MaMonHoc = maMonHoc;
                            deTai.SoLuongPhanBien = 0;
                            DsDeTai.Add(deTai);
                            db.DeTais.Add(deTai);
                        }
                        db.SaveChanges();
                        workbook.Close(0);
                        application.Quit();
                        return RedirectToAction("Index", "DeTais", new { maMonHoc });
                    }
                    else
                    {
                        ViewBag.ErrorFlag = 1;
                        ViewBag.Error = "Định dạng file không đúng!<br>";
                        return View("Index");
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        //Import File Excel============================================================================

        // Duyệt điểm sang thực tập Sản Xuất=============================================================================

        public ActionResult DuyetDiemTTSX(string maMonHoc)
        {
            var DeTaisTTTN = from dt in db.DeTais
                             join kq in db.KetQuas
                             on dt.MaDeTai equals kq.MaDeTai
                             join mh in db.MonHocs
                             on kq.MaMonHoc equals mh.MaMonHoc
                             where kq.DiemSo >= 5 && mh.IdLoaiMonHoc == 1
                             select dt;
            foreach (var item in DeTaisTTTN)
            {
                db.DeTais.Add(new DeTai()
                {
                    MaDeTai = item.MaDeTai,
                    TenDeTai = item.TenDeTai,
                    LinkFileBaoCaoCuoiCung = item.LinkFileBaoCaoCuoiCung,
                    MaMonHoc = maMonHoc,
                    MaSinhVien = item.MaSinhVien,
                    MaGiangVien = item.MaGiangVien,
                    MaHoiDong = item.MaHoiDong,
                    SoLuongPhanBien = item.SoLuongPhanBien
                });
            }
            db.SaveChanges();
            return RedirectToAction("Index", "DeTais", new { maMonHoc });
        }

        // Duyệt điểm sang thực tập Sản Xuất=============================================================================

        // Duyệt điểm sang thực tập tốt nghiệp =============================================================================

        public ActionResult DuyetDiemTTTN(string maMonHoc)
        {
            var DeTaisTTTN = from dt in db.DeTais
                             join kq in db.KetQuas
                             on dt.MaDeTai equals kq.MaDeTai
                             join mh in db.MonHocs
                             on kq.MaMonHoc equals mh.MaMonHoc
                             where kq.DiemSo >= 5 && mh.IdLoaiMonHoc == 2
                             select dt;
            foreach (var item in DeTaisTTTN)
            {
                db.DeTais.Add(new DeTai()
                {
                    MaDeTai = item.MaDeTai,
                    TenDeTai = item.TenDeTai,
                    LinkFileBaoCaoCuoiCung = item.LinkFileBaoCaoCuoiCung,
                    MaMonHoc = maMonHoc,
                    MaSinhVien = item.MaSinhVien,
                    MaGiangVien = item.MaGiangVien,
                    MaHoiDong = item.MaHoiDong,
                    SoLuongPhanBien = item.SoLuongPhanBien
                });
            }
            db.SaveChanges();
            return RedirectToAction("Index", "DeTais", new { maMonHoc });
        }

        // Duyệt điểm sang thực tập tốt nghiệp =============================================================================


        // Duyệt điểm ĐATN=============================================================================

        public ActionResult DuyetDiemDATN(string maMonHoc)
        {
            var DeTaiDATN = from a in db.KetQuas
                            join d in db.MonHocs
                            on a.MaMonHoc equals d.MaMonHoc
                            where d.IdLoaiMonHoc == 3
                            group a by a.MaDeTai
                            into b
                            join c in db.DeTais
                            on b.Key equals c.MaDeTai
                            select new KetQuaViewModel
                            {
                                DiemTrungBinh = b.Average(s => s.DiemSo),
                                MaDeTai = b.Key,
                                TenDeTai = c.TenDeTai,
                                MaSinhVien = c.MaSinhVien,
                                MaGiangVien = c.MaGiangVien
                            };
            var themDeTaiDATN = DeTaiDATN.Distinct().ToList();
            foreach (var item in themDeTaiDATN)
            {
                if (item.DiemTrungBinh > 7)
                {
                    db.DeTais.Add(new DeTai()
                    {
                        MaDeTai = item.MaDeTai,
                        TenDeTai = item.TenDeTai,
                        MaMonHoc = maMonHoc,
                        MaSinhVien = item.MaSinhVien,
                        MaGiangVien = item.MaGiangVien,
                        SoLuongPhanBien = 0
                    });
                }

            }
            db.SaveChanges();
            return RedirectToAction("DSDTHoanThanhDoAn", "DeTais", new { maMonHoc });
        }

        // Duyệt điểm ĐATN=============================================================================

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

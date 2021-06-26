using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAn.Models;
using QuanLyDoAn.Models.Process;

namespace QuanLyDoAn.Areas.Admin.Controllers
{
    public class TaiKhoansController : Controller
    {
        private QLDADbContext db = new QLDADbContext();
        StringProcess strPro = new StringProcess();
        // GET: Admin/TaiKhoans
        public ActionResult Index()
        {
            return View(db.TaiKhoans.ToList());
        }

        // GET: Admin/TaiKhoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan account = db.TaiKhoans.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Admin/TaiKhoans/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.VaiTros, "IdVaiTro", "TenVaiTro");
            return View();
        }

        // POST: Admin/TaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTaiKhoan,TenTaiKhoan,Email,MatKhau,MatKhauXacNhan,IdVaiTro")] TaiKhoan taiKhoan)
        {
            string strMD5 = strPro.GetMD5(taiKhoan.MatKhau);
            if (taiKhoan.MatKhau == taiKhoan.MatKhauXacNhan)
            {
                taiKhoan.MatKhau = strMD5;
                taiKhoan.MatKhauXacNhan = strMD5;
            }
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan account = db.TaiKhoans.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTaiKhoan,TenTaiKhoan,Email,MatKhau,MatKhauXacNhan,IdVaiTro")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan account = db.TaiKhoans.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoan account = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
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

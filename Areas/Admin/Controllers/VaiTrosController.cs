using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAn.Models;

namespace QuanLyDoAn.Areas.Admin.Controllers
{
    public class VaiTrosController : Controller
    {
        private QLDADbContext db = new QLDADbContext();

        // GET: Admin/VaiTros
        public ActionResult Index()
        {
            return View(db.VaiTros.ToList());
        }

        // GET: Admin/VaiTros/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaiTro role = db.VaiTros.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Admin/VaiTros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/VaiTros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVaiTro, TenVaiTro")] VaiTro vaiTro)
        {
            if (ModelState.IsValid)
            {
                db.VaiTros.Add(vaiTro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vaiTro);
        }

        // GET: Admin/VaiTros/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaiTro role = db.VaiTros.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Admin/VaiTros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVaiTro, TenVaiTro")] VaiTro vaiTro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaiTro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaiTro);
        }

        // GET: Admin/VaiTros/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaiTro role = db.VaiTros.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Admin/VaiTros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VaiTro role = db.VaiTros.Find(id);
            db.VaiTros.Remove(role);
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

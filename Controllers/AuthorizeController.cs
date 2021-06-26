using QuanLyDoAn.Models;
using QuanLyDoAn.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyDoAn.Controllers
{
    public class AuthorizeController : Controller
    {
        private QLDADbContext db = new QLDADbContext();
        private int CheckSession()
        {
            using (var db = new QLDADbContext())
            {
                var user = HttpContext.Session["idUser"];
                if (user != null)
                {
                    //var role = db.TaiKhoans.Find(user.ToString()).RoleId;
                    var role = db.TaiKhoans.Where(m => m.Email == user.ToString()).FirstOrDefault().IdVaiTro;
                    if (role != null)
                    {
                        if (role.ToString() == "1")
                        {
                            return 1;
                        }
                        else if (role.ToString() == "2")
                        {
                            return 2;
                        }
                    }
                }
            }
            return 0;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(TaiKhoan acc, string returnUrl)
        {
            StringProcess strPro = new StringProcess();
            try
            {
                if (!string.IsNullOrEmpty(acc.Email) && !string.IsNullOrEmpty(acc.MatKhau))
                {

                    using (var db = new QLDADbContext())
                    {
                        var passToMD5 = strPro.GetMD5(acc.MatKhau);
                        var account = db.TaiKhoans.Where(m => m.Email.Equals(acc.Email) && m.MatKhau.Equals(passToMD5));
                        if (account.Count() == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.Email, false);
                            Session["idUser"] = acc.Email;
                            Session["roleUser"] = acc.IdVaiTro;
                            //Session["StudentCode"] = account.FirstOrDefault().StudentCode;
                            //Session["TeacherCode"] = account.FirstOrDefault().TeacherCode;
                            Response.Cookies.Add(new HttpCookie("userCookie", acc.Email));
                            Response.Cookies.Add(new HttpCookie("roleCookie", acc.IdVaiTro));
                            return RedirectToLocal(returnUrl);
                        }
                        ModelState.AddModelError("", "Thông tin đăng nhập chưa chính xác");
                    }
                }
                ModelState.AddModelError("", "Email and password is required.");
            }
            catch
            {
                ModelState.AddModelError("", "Hệ thống đang được bảo trì, vui lòng liên hệ với quản trị viên");
            }
            return View(acc);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)
                {
                    return RedirectToAction("Index", "HocKys");
                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "TaiKhoans", new { Area = "Admin" });
                }
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login", "Authorize");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return Redirect("/Authorize/Login");
        }
    }
}
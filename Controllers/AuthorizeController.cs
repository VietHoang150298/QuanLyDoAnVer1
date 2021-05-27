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
                    //var role = db.Accounts.Find(user.ToString()).RoleId;
                    var role = db.Accounts.Where(m => m.UserName == user.ToString()).FirstOrDefault().RoleId;
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
        public ActionResult Login(Account acc, string returnUrl)
        {
            StringProcess strPro = new StringProcess();
            try
            {
                if (!string.IsNullOrEmpty(acc.UserName) && !string.IsNullOrEmpty(acc.Password))
                {

                    using (var db = new QLDADbContext())
                    {
                        var passToMD5 = strPro.GetMD5(acc.Password);
                        var account = db.Accounts.Where(m => m.UserName.Equals(acc.UserName) && m.Password.Equals(passToMD5));
                        if (account.Count() == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.UserName, false);
                            Session["idUser"] = acc.UserName;
                            Session["roleUser"] = acc.RoleId;
                            //Session["StudentCode"] = account.FirstOrDefault().StudentCode;
                            //Session["TeacherCode"] = account.FirstOrDefault().TeacherCode;
                            Response.Cookies.Add(new HttpCookie("userCookie", acc.UserName));
                            Response.Cookies.Add(new HttpCookie("roleCookie", acc.RoleId));
                            return RedirectToLocal(returnUrl);
                        }
                        ModelState.AddModelError("", "Thông tin đăng nhập chưa chính xác");
                    }
                }
                ModelState.AddModelError("", "Username and password is required.");
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
                    return RedirectToAction("Index", "Accounts", new { Area = "Admin" });
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


        public ActionResult Login2()
        {
            return View();
        }
    }
}
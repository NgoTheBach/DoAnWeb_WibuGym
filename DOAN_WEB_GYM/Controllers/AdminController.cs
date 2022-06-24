using DOAN_WEB_GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DOAN_WEB_GYM.Controllers
{
    public class AdminController : Controller
    {
        MyDataDataContext db = new MyDataDataContext();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["account"];
            var matkhau = collection["password"];
            var user = db.TaiKhoanQTVs.SingleOrDefault(p => p.Account == tendn);
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
                return this.Login();
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
                return this.Login();
            }
            else if (user == null)
            {
                ViewData["1"] = "Tài Khoản không tồn tại";
                return this.Login();
            }
            else if (!String.Equals(ConvertMD5.MD5Hash(matkhau), user.Password))
            {
                ViewData["2"] = "Sai mật khẩu";
                return this.Login();
            }
            else
            {
                Session["admin"] = user;
                return RedirectToAction("ManHinhAdmin", "Admin");
            }
        }
        public ActionResult LogOut()
        {
            Session["admin"] = null;
            return RedirectToAction("LogIn", "Account");
        }
        public ActionResult ManHinhAdmin()
        {
            return View();
        }
        public ActionResult ThemKhoaTap()
        {
            return View();
        }
        
        public ActionResult ThemTinTuc()
        {
            return View();
        }
        public ActionResult ThemCLB()
        {
            return View();
        }
        public ActionResult DanhSachKhoaTap()
        {
            return View();
        }
        public ActionResult DanhSachHocVien()
        {
            return View();
        }
        public ActionResult DanhSachCLB()
        {
            return View();
        }
        
    }
}
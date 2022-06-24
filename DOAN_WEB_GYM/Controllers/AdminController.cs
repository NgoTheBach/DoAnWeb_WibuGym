using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_WEB_GYM.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult ThemKhoaTap()
        {
            return View();
        }
        public ActionResult ManHinhAdmin()
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
        public ActionResult Login()
        {
            return View();
        }
    }
}
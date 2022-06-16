using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_WEB_GYM.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
    }
}
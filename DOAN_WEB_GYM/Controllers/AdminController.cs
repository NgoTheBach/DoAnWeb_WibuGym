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
    }
}
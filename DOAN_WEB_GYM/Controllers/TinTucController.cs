using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_WEB_GYM.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult SuKien()
        {
            return View();
        }
        public ActionResult KienThucSucKhoe()
        {
            return View();
        }
    }
}
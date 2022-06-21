using DOAN_WEB_GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_WEB_GYM.Controllers
{
    public class GYMController : Controller
    {
        MyDataDataContext db = new MyDataDataContext();
        // GET: GYM
        public ActionResult Index()
        {
            var dbCourses = (from s in db.KhoaTaps select s);
            return View(dbCourses);
        }
    }
}
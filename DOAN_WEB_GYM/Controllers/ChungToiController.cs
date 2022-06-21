using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOAN_WEB_GYM.Models;

namespace DOAN_WEB_GYM.Controllers
{
    public class ChungToiController : Controller
    {
        MyDataDataContext db = new MyDataDataContext();
        // GET: ChungToi
        public ActionResult Chungtoi()
        {
            var dbPT = (from s in db.PTs select s);
            return View(dbPT);
        }
    }
}
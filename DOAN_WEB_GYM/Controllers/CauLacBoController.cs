using DOAN_WEB_GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_WEB_GYM.Controllers
{
    public class CauLacBoController : Controller
    {
        MyDataDataContext db = new MyDataDataContext();
        // GET: CauLacBo
        public ActionResult CLB()
        {
            var dbCLB = (from s in db.CLBs select s);
            return View(dbCLB);
        }
    }
}
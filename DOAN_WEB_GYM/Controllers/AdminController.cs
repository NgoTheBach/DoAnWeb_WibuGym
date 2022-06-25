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
        [HttpPost]
        public ActionResult ThemCLB(FormCollection collection, CLB s)
        {
            var E_tenCLB = collection["CLBName"];
            var E_addressCLB = collection["addressCLB"];
            var E_urlImage = collection["urlImg"];
            var E_phoneNumber = collection["phoneNumber"];
            if (string.IsNullOrEmpty(E_tenCLB))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.CLBName = E_tenCLB.ToString();
                s.addressCLB = E_addressCLB.ToString();
                s.urlImg = E_urlImage.ToString();
                s.phoneNumber = E_phoneNumber.ToString();
                db.CLBs.InsertOnSubmit(s);
                db.SubmitChanges();
                return RedirectToAction("ThemCLB","Admin");
            }
            return this.ThemCLB();
        }
        // EDit CLB
        public ActionResult SuaCLB(int id)
        {
            var E_sach = db.CLBs.First(m => m.idCLB == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult SuaCLB(int id, FormCollection collection)
        {
            var E_clb = db.CLBs.First(m => m.idCLB == id);
            var E_tenCLB = collection["CLBName"];
            var E_addressCLB = collection["addressCLB"];
            var E_urlImage = collection["urlImg"];
            var E_phoneNumber = collection["phoneNumber"];
            E_clb.idCLB = id;
            if (string.IsNullOrEmpty(E_tenCLB))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_clb.CLBName = E_tenCLB;
                E_clb.addressCLB = E_addressCLB;
                E_clb.urlImg = E_urlImage;
                E_clb.phoneNumber = E_phoneNumber;
                UpdateModel(E_clb);
                db.SubmitChanges();
                return RedirectToAction("ListCLB");
            }
            return this.SuaCLB(id);
        }
        //end Edit CLB
        // delete clb
        public ActionResult XoaCLB(int id)
        {
            var D_clb = db.CLBs.First(m => m.idCLB == id);
            return View(D_clb);
        }
        [HttpPost]
        public ActionResult XoaCLB(int id, FormCollection collection)
        {
            var D_clb = db.CLBs.Where(m => m.idCLB == id).First();
            db.CLBs.DeleteOnSubmit(D_clb);
            db.SubmitChanges();
            return RedirectToAction("ListCLB");
        }
        //end delete clb
        // list CLB
        public ActionResult ListCLB()
        {
            var all_clb = from ss in db.CLBs select ss;
            return View(all_clb);
        }
        // end List CLB
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
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }

            file.SaveAs(Server.MapPath("~/Content/images_1/" + file.FileName));

            return "/Content/images_1/" + file.FileName;
        }
    }
}
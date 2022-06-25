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
        // Thêm khóa tập
        [HttpGet]
        public ActionResult ThemKhoaTap()
        {
            ViewBag.MaCLB = new SelectList(db.CLBs.ToList().OrderBy(n => n.CLBName), "idCLB", "CLBName");
            ViewBag.GioBatDau = new SelectList(db.thoiGianBatDaus.ToList().OrderBy(n => n.idTimeStart), "idTimeStart", "timeStart");
            ViewBag.GioKetThuc = new SelectList(db.thoiGianKetThucs.ToList().OrderBy(n => n.idTimeEnd), "idTimeEnd", "timeEnd");
            ViewBag.ThuTrongTuan = new SelectList(db.NgayTrongTuans.ToList().OrderBy(n => n.idDaysInWeek), "idDaysInWeek", "daysInWeek");
            return View();
        }
        [HttpPost]
        public ActionResult ThemKhoaTap(FormCollection collection, KhoaTap s, Lich l)
        {
            var E_tenKT = collection["tenKT"];
            var E_descriptionKT = collection["descriptionKT"];
            var E_startDay = Convert.ToDateTime(collection["startDay"]);
            var E_dueDay = Convert.ToDateTime(collection["dueDay"]);
            var E_gia = Convert.ToInt32(collection["price"]);
            var E_hinh = collection["urlImg"];
            var E_idCLB = Convert.ToInt32(collection["MaCLB"]);
            var E_idGioBatDau = Convert.ToInt32(collection["GioBatDau"]);
            var E_idGioKetThuc = Convert.ToInt32(collection["GioKetThuc"]);
            var E_idThuTrongTuan = Convert.ToInt32(collection["ThuTrongTuan"]);

            if (string.IsNullOrEmpty(E_tenKT))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.nameCourse = E_tenKT.ToString();
                s.descriptionKT = E_descriptionKT.ToString();
                s.startDay = E_startDay;
                s.dueDay = E_dueDay;
                s.price = E_gia;
                s.descriptionKT = E_descriptionKT;
                s.urlImg = E_hinh.ToString();
                s.idCLB = E_idCLB;
                db.KhoaTaps.InsertOnSubmit(s);
                db.SubmitChanges();
                l.idCourse = s.idCourse;
                l.idTimeStart = E_idGioBatDau;
                l.idTimeEnd = E_idGioKetThuc;
                l.idDaysInWeek = E_idThuTrongTuan;
                db.Liches.InsertOnSubmit(l);
                db.SubmitChanges();
                return RedirectToAction("ListKhoaTap");
            }
            return this.ThemKhoaTap();
        }
        // end Thêm khóa tập
        // list Khoa tap
        public ActionResult ListKhoaTap()
        {
            var all_khoatap = from ss in db.KhoaTaps select ss;
            return View(all_khoatap);
        }
        // end List Khoa tap
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
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }

            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));

            return "/Content/images/" + file.FileName;
        }

    }
}
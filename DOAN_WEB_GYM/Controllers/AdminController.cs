﻿using DOAN_WEB_GYM.Models;
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
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                TaiKhoanQTV ad = db.TaiKhoanQTVs.SingleOrDefault(n => n.Account == tendn && n.Password == matkhau);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("ManHinhAdmin", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return RedirectToAction("Login", "Admin");
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
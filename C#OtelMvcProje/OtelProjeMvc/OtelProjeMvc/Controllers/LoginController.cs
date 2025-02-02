﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelProjeMvc.Models.Entity;

namespace OtelProjeMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DbOtelEntities db = new DbOtelEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblYeniKayitlar p)
        {
            var bilgiler = db.TblYeniKayitlar.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
            if (bilgiler!= null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail,false);
                Session["Mail"] = bilgiler.Mail.ToString();
                return RedirectToAction("Index","Misafir");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
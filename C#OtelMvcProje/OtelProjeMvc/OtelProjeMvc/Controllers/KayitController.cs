using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelProjeMvc.Models.Entity;

namespace OtelProjeMvc.Controllers
{
    public class KayitController : Controller
    {
        // GET: Kayit
       
        DbOtelEntities db = new DbOtelEntities();
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        public ActionResult KayitOl(TblYeniKayitlar p)
        {
            db.TblYeniKayitlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Login");
        }

    }
}
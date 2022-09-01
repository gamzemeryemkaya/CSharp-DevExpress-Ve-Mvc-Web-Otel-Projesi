using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelProjeMvc.Models.Entity;


namespace OtelProjeMvc.Controllers
{
    public class RezervasyonController : Controller
    {
        DbOtelEntities db = new DbOtelEntities();
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
       public ActionResult Index(TblOnRezervasyon t)
        {
            var misafirmail = (string)Session["Mail"];
            var misafirid = db.TblYeniKayitlar.Where(x => x.Mail == misafirmail).Select(x => x.ID).FirstOrDefault();

            //p.Durum = 12;
            //p.Misafir =misafirid;
            t.Mail = misafirmail;
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblOnRezervasyon.Add(t);
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlarimiz", "Misafir");
        }

    }
}
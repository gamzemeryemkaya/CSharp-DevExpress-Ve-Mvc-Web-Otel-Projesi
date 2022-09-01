using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelProjeMvc.Models.Entity;

namespace OtelProjeMvc.Controllers
{
   [Authorize]
    public class MisafirController : Controller
    {
        // GET: Misafir
        DbOtelEntities db = new DbOtelEntities();
     [Authorize]
        public ActionResult Index()
        {
            var misafirmail = (string)Session["Mail"];
            var misafirbilgi = db.TblYeniKayitlar.Where(x => x.Mail == misafirmail).FirstOrDefault();
            return View(misafirbilgi);
        }
        public ActionResult Rezervasyonlarimiz()
        {
            var misafirmail = (string)Session["Mail"];
            //ViewBag.a = misafirmail;
            //var misafirid = db.TblYeniKayitlar.Where(x => x.Mail == misafirmail).Select(y => y.ID).FirstOrDefault();
            //ViewBag.a = misafirid;
            var degerler = db.TblOnRezervasyon.Where(x => x.Mail == misafirmail).ToList();
            return View(degerler);
        }
        public ActionResult MisafirBilgiGuncelle(TblYeniKayitlar p)
        {
            var misafir = db.TblYeniKayitlar.Find(p.ID);
            misafir.AdSoyad = p.AdSoyad;
            misafir.Sifre = p.Sifre;
            misafir.Telefon = p.Telefon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "AnaSayfa");
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var misafirmail = (string)Session["Mail"];
            var mesajlar = db.TblMesaj2.Where(x => x.Alıcı == misafirmail).ToList();
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var misafirmail = (string)Session["Mail"];
            var mesajlar = db.TblMesaj2.Where(x => x.Gonderen == misafirmail).ToList();
            return View(mesajlar);
        }
        public ActionResult MesajDetaylar(int id)
        {
            var mesaj = db.TblMesaj2.Where(x => x.MesajID == id).FirstOrDefault();
            return View(mesaj);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TblMesaj2 p)
        {
            var misafirmail = (string)Session["Mail"];
            p.Gonderen = misafirmail;
            p.Alıcı= "Admin";
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMesaj2.Add(p);
            db.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }

    }
}
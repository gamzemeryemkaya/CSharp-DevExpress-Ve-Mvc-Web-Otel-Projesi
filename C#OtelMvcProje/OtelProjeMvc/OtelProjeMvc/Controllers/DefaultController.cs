using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelProjeMvc.Models.Entity;


namespace OtelProjeMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        DbOtelEntities db = new DbOtelEntities();
        public ActionResult Hakkimda()
        {
            var veriler = db.TblHakkimda.ToList();
            return View(veriler);
        }
        public PartialViewResult Ekibimiz()
        {
            var ekiplistesi = db.TblEkibimiz.ToList();
            return PartialView(ekiplistesi);
        }
        public PartialViewResult İstatistik()
        {
            return PartialView();
        }
        public PartialViewResult Referans()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            var doluodalar = db.TblOda.Where(x => x.Durum != 1).Count();
            ViewBag.d = doluodalar;
            var bosodalar = db.TblOda.Where(x => x.Durum == 1).Count();
            ViewBag.b = bosodalar;
            return PartialView();
        }
        public PartialViewResult PartialSosyalMedya()
        {
            return PartialView();
        }
    }
}
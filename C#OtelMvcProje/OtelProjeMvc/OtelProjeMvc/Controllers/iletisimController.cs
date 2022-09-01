using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelProjeMvc.Models.Entity;

namespace OtelProjeMvc.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        DbOtelEntities db = new DbOtelEntities();
        public ActionResult Index()
        {
            var bilgiler = db.Tbliletisim.ToList();
            return View(bilgiler);
        }
        [HttpGet]
        public PartialViewResult MesajGonder()
        {
            return PartialView();

        }
        [HttpPost]
        public PartialViewResult MesajGonder(TblMesaj p)
        {
            db.TblMesaj.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }
}
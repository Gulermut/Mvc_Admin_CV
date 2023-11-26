using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        GenericRepository<TBLHAKKIMDA> repo = new GenericRepository<TBLHAKKIMDA>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(TBLHAKKIMDA p)
        {
            // TBLHOBİLERİM t = new TBLHOBİLERİM();
            var t = repo.Find(x => x.ID == 1);
            t.AD = p.AD;
            t.SOYAD = p.SOYAD;
            t.ADRES = p.ADRES;
            t.MAİL = p.MAİL;
            t.TELEFON = p.TELEFON;
            t.ACIKLAMA = p.ACIKLAMA;
            t.RESİM = p.RESİM;
          
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}
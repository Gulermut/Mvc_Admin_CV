using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;
namespace MvcCV.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek

        GenericRepository<TBLYETENEKLERİM> repo = new GenericRepository<TBLYETENEKLERİM>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);

        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLYETENEKLERİM p)

        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult YetenekDüzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDüzenle(TBLYETENEKLERİM t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.YETENEK = t.YETENEK;
            y.ORAN = t.ORAN;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}
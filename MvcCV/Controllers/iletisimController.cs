using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<TBLİLETİSİM> repo = new GenericRepository<TBLİLETİSİM>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}
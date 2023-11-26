using MvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBLADMİN p)
        {
            CVEntities db = new CVEntities();
            var bilgi = db.TBLADMİN.FirstOrDefault(x=> x.KULLANICIADI==p.KULLANICIADI && x.SİFRE==p.SİFRE);
            if (bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KULLANICIADI, false);
                Session["KULLANICIADI"] = bilgi.KULLANICIADI.ToString();
                return RedirectToAction("Index", "Deneyim");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}
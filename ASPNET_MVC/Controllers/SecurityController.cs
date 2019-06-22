using ASPNET_MVC.Models.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASPNET_MVC.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        ProjeMVCEntities db = new ProjeMVCEntities();

        public ActionResult Sifre_unuttum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Oturum_ac(Kullanici kullanici, string returnUrl)
        {
            // Kullanıcı ve şifre var mı
            var bkullanici = db.Kullanici.FirstOrDefault(
               x => x.Ad == kullanici.Ad && x.Sifre == kullanici.Sifre);
            if (bkullanici != null)
            {
                FormsAuthentication.SetAuthCookie(bkullanici.Ad, true);//Hatırla                
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Anasayfa", "Home");
            }
            else
            {
                var bkullanici2 = db.Gelismis.FirstOrDefault(x => x.KullaniciAdi == kullanici.Ad && x.Sifre == kullanici.Sifre);
                if (bkullanici2 != null)
                {
                    FormsAuthentication.SetAuthCookie(bkullanici2.KullaniciAdi, true);//Hatırla
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Anasayfa", "Home");
                }
                else
                {
                    ViewBag.Mesaj = "Geçersiz kullanıcı adı ve ya şifre";
                    return View();
                }
            }
        }

        public ActionResult Oturum_ac(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult Kayit()
        {
            return View();
        }
    }
}
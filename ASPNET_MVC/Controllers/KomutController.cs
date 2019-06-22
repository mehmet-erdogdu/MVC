using ASPNET_MVC.Models.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_MVC.Controllers
{
    public class KomutController : Controller
    {
        // GET: Komut
        ProjeMVCEntities db = new ProjeMVCEntities();

        public ActionResult JavaScript()
        {

            return View();
        }

        public ActionResult Yenile()
        {
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        public ActionResult Hamburger(int id)
        {
            if (id == 0)
            {
                Response.Cookies["hamburger"].Value = "1";
            }
            else
                Response.Cookies["hamburger"].Value = "0";
            Response.Cookies["hamburger"].Expires = DateTime.Now.AddDays(60);
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        public ActionResult Tema(int id)
        {
            if (id == 0)
            {
                Response.Cookies["tema"].Value = "1";
            }
            else
                Response.Cookies["tema"].Value = "0";
            Response.Cookies["tema"].Expires = DateTime.Now.AddDays(60);
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        public ActionResult CerezK()
        {
            Response.Cookies["cerez"].Value = "1";
            Response.Cookies["cerez"].Expires = DateTime.Now.AddDays(60);
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        public int Personel_Sayisi() //Soru işareti nullable int? convert error int gibi
        {
            return db.Personel.Count();
        }

        public int Departman_Sayisi() //Soru işareti nullable int? convert error int gibi
        {
            return db.Departman.Count();
        }
    }
}
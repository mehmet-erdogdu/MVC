using ASPNET_MVC.Models.EntitiyFramework;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ASPNET_MVC.Controllers
{

    public class HomeController : Controller
    {
        // GET: Home
        private ProjeMVCEntities db = new ProjeMVCEntities();

        public ActionResult HtmlCss()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Oturum_ac", "Security");
        }

        [OutputCache(Duration = 60)] // 1dk boyunca sayfayı ön belleğe alır
        public ActionResult Tanitim()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            ViewData["Message"] = "İletişim Bilgilerimiz";
            return View();
        }

        public ActionResult Hakkinda()
        {
            ViewData["Message"] = "Sayfamızı Açıklayan Kısım.";
            return View();
        }

        public ActionResult Anasayfa()
        {
            var detay = db.Detay.Include(d => d.Kullanici);
            return View(detay.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
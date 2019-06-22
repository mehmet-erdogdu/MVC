using ASPNET_MVC.Models.EntitiyFramework;
using ASPNET_MVC.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ASPNET_MVC.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        // GET: Home
        ProjeMVCEntities db = new ProjeMVCEntities();
        public ActionResult Sil(int id)
        {
            var silinecekdepartman = db.Departman.Find(id);
            if (silinecekdepartman == null)
                return HttpNotFound();
            db.Departman.Remove(silinecekdepartman);
            db.SaveChanges();
            return RedirectToAction("Departman");
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("DepartmanForm", model);
        }

        //CSRF
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Departman departman)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanForm");
            }
            MesajViewModel model = new MesajViewModel();
            if (departman.Id == 0)
            {
                db.Departman.Add(departman);
                model.Mesaj = departman.Ad + " başarıyle eklendi";
                model.Status = true;
            }
            else
            {
                var guncellencekdepartman = db.Departman.Find(departman.Id);
                if (guncellencekdepartman == null)
                {
                    return HttpNotFound();
                }
                guncellencekdepartman.Ad = departman.Ad;
                model.Mesaj = departman.Ad + " başarıyle güncellendi";
                model.Status = false;
            }
            db.SaveChanges();
            model.LinkText = "Departman Listesi";
            model.Url = "/Departmanlar";
            return View("_Mesaj", model);
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View("DepartmanForm", new Departman());
        }

        public ActionResult Departman()
        {
            var model = db.Departman.ToList();
            return View(model);
        }
    }
}
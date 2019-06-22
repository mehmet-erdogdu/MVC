using ASPNET_MVC.Models.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASPNET_MVC.ViewModels;

namespace ASPNET_MVC.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        // GET: Personel
        ProjeMVCEntities db = new ProjeMVCEntities();


        public int? ToplamMaas() //Soru işareti nullable int? convert error int gibi
        {
            return db.Personel.Sum(x=>x.Maas);
        }

        public ActionResult PersonelleriListele(int id)
        {
            var model = db.Personel.Where(x => x.DepartmanId == id).ToList();
            return PartialView(model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekpersonel = db.Personel.Find(id);
            if (silinecekpersonel == null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(silinecekpersonel);
            db.SaveChanges();
            return RedirectToAction("Personel");
        }

        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = db.Personel.Find(id)
            };
            return View("PersonelForm", model);
        }

        //CSRF
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = db.Departman.ToList(),
                    Personel = personel
                };
                return View("PersonelForm", model);
            }
            if (personel.Id == 0)
            {
                db.Personel.Add(personel);
            }
            else
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Personel");
        }

        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = new Personel()
            };
            return View("PersonelForm", model);
        }

        public ActionResult Personel()
        {
            var model = db.Personel.Include(x => x.Departman).ToList();
            ViewBag.konum = "Personel Listesi";
            return View(model);
        }
    }
}
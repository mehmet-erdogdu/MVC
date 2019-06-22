using ASPNET_MVC.Models.EntitiyFramework;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ASPNET_MVC.Controllers
{
    public class DetaylarController : Controller
    {
        private ProjeMVCEntities db = new ProjeMVCEntities();

        // GET: Detaylar
        public ActionResult Index()
        {
            var detay = db.Detay.Include(d => d.Kullanici);
            return View(detay.ToList());
        }

        // GET: Detaylar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detay detay = db.Detay.Find(id);
            if (detay == null)
            {
                return HttpNotFound();
            }
            return View(detay);
        }


        // GET: Detaylar/Details/5
        public ActionResult Oku(string baslik)
        {
            return View(db.Detay.Where(i => i.Baslik == baslik).SingleOrDefault());
        }

        // GET: Detaylar/Create
        public ActionResult Create()
        {
            ViewBag.KullaniciId = new SelectList(db.Kullanici, "Id", "Ad");
            return View();
        }

        // POST: Detaylar/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KullaniciId,Baslik,Makale,Olusturma_Tarihi")] Detay detay)
        {
            if (ModelState.IsValid)
            {
                db.Detay.Add(detay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KullaniciId = new SelectList(db.Kullanici, "Id", "Ad", detay.KullaniciId);
            return View(detay);
        }

        // GET: Detaylar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detay detay = db.Detay.Find(id);
            if (detay == null)
            {
                return HttpNotFound();
            }
            ViewBag.KullaniciId = new SelectList(db.Kullanici, "Id", "Ad", detay.KullaniciId);
            return View(detay);
        }

        // POST: Detaylar/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KullaniciId,Baslik,Makale,Olusturma_Tarihi")] Detay detay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KullaniciId = new SelectList(db.Kullanici, "Id", "Ad", detay.KullaniciId);
            return View(detay);
        }

        // GET: Detaylar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detay detay = db.Detay.Find(id);
            if (detay == null)
            {
                return HttpNotFound();
            }
            return View(detay);
        }

        // POST: Detaylar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detay detay = db.Detay.Find(id);
            db.Detay.Remove(detay);
            db.SaveChanges();
            return RedirectToAction("Index");
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

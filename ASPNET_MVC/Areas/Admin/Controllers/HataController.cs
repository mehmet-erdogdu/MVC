using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNET_MVC.Models.EntitiyFramework;

namespace ASPNET_MVC.Areas.Admin.Controllers
{
    [Authorize]
    public class HataController : Controller
    {
        private ProjeMVCEntities db = new ProjeMVCEntities();

        // GET: Admin/Hata
        public ActionResult Index()
        {
            return View(db.ELMAH_Error.ToList());
        }

        // GET: Admin/Hata/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ELMAH_Error eLMAH_Error = db.ELMAH_Error.Find(id);
            if (eLMAH_Error == null)
            {
                return HttpNotFound();
            }
            return View(eLMAH_Error);
        }

        // GET: Admin/Hata/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ELMAH_Error eLMAH_Error = db.ELMAH_Error.Find(id);
            if (eLMAH_Error == null)
            {
                return HttpNotFound();
            }
            return View(eLMAH_Error);
        }

        // POST: Admin/Hata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ELMAH_Error eLMAH_Error = db.ELMAH_Error.Find(id);
            db.ELMAH_Error.Remove(eLMAH_Error);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Direk_Sil(Guid id)
        {
            ELMAH_Error eLMAH_Error = db.ELMAH_Error.Find(id);
            db.ELMAH_Error.Remove(eLMAH_Error);
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

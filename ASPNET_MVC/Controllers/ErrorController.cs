using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Sayfa_bulunamadi()
        {
            return View();
        }
    }
}
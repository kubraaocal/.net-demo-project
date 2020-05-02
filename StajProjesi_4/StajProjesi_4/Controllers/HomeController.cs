using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using StajProjesi_4.Models;

namespace StajProjesi_4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var bilgiler = db.Bilgiler.Include(b => b.Bilgiler2).Include(b => b.Departman1);
            return View(bilgiler.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        private DbBilgiKayitEntities1 db = new DbBilgiKayitEntities1();

        // GET: Bilgilers

        // GET: Bilgilers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilgiler bilgiler = db.Bilgiler.Find(id);
            if (bilgiler == null)
            {
                return HttpNotFound();
            }
            return View(bilgiler);
        }
    }
}
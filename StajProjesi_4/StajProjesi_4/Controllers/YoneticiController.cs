using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StajProjesi_4.Models;

namespace StajProjesi_4.Controllers
{
    public class YoneticiController : Controller
    {
        private DbBilgiKayitEntities1 db = new DbBilgiKayitEntities1();

        // GET: Bilgilers
        public ActionResult Index()
        {
            var bilgiler = db.Bilgiler.Include(b => b.Bilgiler2).Include(b => b.Departman1);
            return View(bilgiler.ToList());
        }

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

        // GET: Bilgilers/Create
        public ActionResult Create()
        {
            ViewBag.YNTBİLGİ = new SelectList(db.Bilgiler, "ID", "AD");
            ViewBag.DEPARTMAN = new SelectList(db.Departman, "ID", "DPRTMN");
            return View();
        }

        // POST: Bilgilers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AD,SOYAD,TELEFON,DEPARTMAN,YNTBİLGİ")] Bilgiler bilgiler)
        {
                if (ModelState.IsValid)
                {
                    db.Bilgiler.Add(bilgiler);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.YNTBİLGİ = new SelectList(db.Bilgiler, "ID", "AD", bilgiler.YNTBİLGİ);
                ViewBag.DEPARTMAN = new SelectList(db.Departman, "ID", "DPRTMN", bilgiler.DEPARTMAN);
                return View(bilgiler);
            
            
        }

        // GET: Bilgilers/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.YNTBİLGİ = new SelectList(db.Bilgiler, "ID", "AD", bilgiler.YNTBİLGİ);
            ViewBag.DEPARTMAN = new SelectList(db.Departman, "ID", "DPRTMN", bilgiler.DEPARTMAN);
            return View(bilgiler);
        }

        // POST: Bilgilers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AD,SOYAD,TELEFON,DEPARTMAN,YNTBİLGİ")] Bilgiler bilgiler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bilgiler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YNTBİLGİ = new SelectList(db.Bilgiler, "ID", "AD", bilgiler.YNTBİLGİ);
            ViewBag.DEPARTMAN = new SelectList(db.Departman, "ID", "DPRTMN", bilgiler.DEPARTMAN);
            return View(bilgiler);
        }

        // GET: Bilgilers/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Bilgilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bilgiler bilgiler = db.Bilgiler.Find(id);
            db.Bilgiler.Remove(bilgiler);
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

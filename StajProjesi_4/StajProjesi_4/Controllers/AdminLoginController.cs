using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StajProjesi_4.Models;

namespace StajProjesi_4.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autherize(StajProjesi_4.Models.Admin adminLogin)
        {
            using(DbBilgiKayitEntities1 db=new DbBilgiKayitEntities1())
            {
                var adminDetails = db.Admin.Where(x => x.ADMİN == adminLogin.ADMİN && x.SİFRE == adminLogin.SİFRE).FirstOrDefault();
                if (adminDetails == null)
                {
                    adminLogin.LoginErrorMessage = "Kullanıcı adı ve şifre yanlış";
                    return View("Index", adminLogin);
                }
                else
                {
                    Session["ID"] = adminDetails.ID;
                    Session["ADMİN"] = adminDetails.ADMİN;
                    return RedirectToAction("Index", "Yonetici");
                }
            }
        }
        public ActionResult LogOut()
        {
            int adminId = (int)Session["ID"];
            Session.Abandon();
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}
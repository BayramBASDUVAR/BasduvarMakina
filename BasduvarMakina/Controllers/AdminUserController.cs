using BasduvarMakina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasduvarMakina.Controllers
{
    public class AdminUserController : Controller
    {
        DataContext context = new DataContext();
        // GET: AdminUser
        public ActionResult Index()
        {
            ViewBag.Title = "Başduvar | Kullanıcı";

            var user = context.user.ToList();

            return View(context.user.ToList());
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                HttpNotFound();
            }

            User user = context.user.Find(Id);
            context.user.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
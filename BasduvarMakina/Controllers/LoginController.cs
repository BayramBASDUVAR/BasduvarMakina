using BasduvarMakina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasduvarMakina.Controllers
{
    public class LoginController : Controller
    {
        DataContext context = new DataContext();
        // GET: Login
        public ActionResult Index()
        {
            //var date = DateTime.Now;
            var list = context.user.ToList();
            return View();
        }
    }
}
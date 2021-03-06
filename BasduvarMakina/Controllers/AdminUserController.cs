﻿using BasduvarMakina.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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

            return View(context.user.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user, HttpPostedFileBase File)
        {
            var userExist = context.user.Any(m => m.Email == user.Email);
            if (userExist == false)
            {
                user.AddedDate = DateTime.Now;
                user.AddedBy = "Bayram BAŞDUVAR";

                if (File != null)
                {
                    FileInfo fileInfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileInfo.Extension).ToLower();
                    img.Resize(220, 180, false, false);
                    string tamYol = "~/images/users/" + uzanti;

                    img.Save(Server.MapPath(tamYol));
                    user.Image = "/images/users/" + uzanti;
                }

                context.user.Add(user);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
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

        public ActionResult Details(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }

            User user = context.user.Find(Id);

            return PartialView(user);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }

            User user = context.user.Find(Id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user, HttpPostedFileBase File)
        {

            if (user != null)
            {
                context.Entry(user).State = EntityState.Modified;

                context.Entry(user).Property(m => m.AddedBy).IsModified = false;
                context.Entry(user).Property(m => m.AddedDate).IsModified = false;
                if (File != null)
                {
                    FileInfo fileInfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileInfo.Extension).ToLower();
                    img.Resize(220, 180, false, false);
                    string tamYol = "~/images/users/" + uzanti;

                    img.Save(Server.MapPath(tamYol));
                    user.Image = "/images/users/" + uzanti;
                }
                else
                {
                    context.Entry(user).Property(m => m.Image).IsModified = false;
                }
                user.ModifyBy = "Bayram BAŞDUVAR";
                user.ModifyDate = DateTime.Now;
            }

            user.AddedDate = DateTime.Now;
            user.AddedBy = "Bayram BAŞDUVAR";

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
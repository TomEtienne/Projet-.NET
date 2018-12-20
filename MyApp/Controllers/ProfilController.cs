using MyApp.Context;
using MyApp.Entities;
using MyApp.Models;
using MyApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Controllers
{
    [Authorize]
    public class ProfilController : Controller
    {
        public ActionResult Index()
        {
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);
                User user = repo.getUser(HttpContext.User.Identity.Name);
                DisplayInfosModel model = new DisplayInfosModel()
                {
                    email = user.email,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    nickName = user.nickName
                };
                return View(model);
            }
            
        }

        public ActionResult Edit()
        {
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);
                User user = repo.getUser(HttpContext.User.Identity.Name);
                DisplayInfosModel model = new DisplayInfosModel()
                {
                    email = user.email,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    nickName = user.nickName
                };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(DisplayInfosModel model)
        {
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);
                User user = repo.getUser(HttpContext.User.Identity.Name);
                user.firstName = model.firstName;
                user.lastName = model.lastName;
                user.email = model.email;
                user.nickName = model.nickName;
                context.SaveChanges();

                return RedirectToAction("Index","Profil");
            }
        }

    }
}
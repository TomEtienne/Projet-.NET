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
    public class DisplayProfilController : Controller
    {
        public ActionResult Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                RedirectToAction("Form", "Login");
            }
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
    }
}
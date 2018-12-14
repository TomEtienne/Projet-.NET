using MyApp.Context;
using MyApp.Entities;
using MyApp.Models;
using MyApp.Repositories;
using System;
using System.Web.Mvc;

namespace MyApp.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Form()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        
        [HttpPost]
        public ActionResult Form(User model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using(MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);
                User user = new User()
                {
                    lastName = model.lastName,
                    firstName = model.firstName,
                    email = model.email,
                    nickName = model.nickName,
                    password = model.password,
                    verifyPassword = model.verifyPassword

                };
                repo.Add(user);
                context.SaveChanges();
            }

            return RedirectToAction("Form", "Login");
        }
    }
}
using MyApp.Context;
using MyApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyApp.Controllers
{

    public class LoginController : Controller
    {

        public LoginController()
        {

        }

        public ActionResult Form()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        
        [HttpPost]
        public ActionResult Form(Models.LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);
                if(repo.CheckUser(model.nickName,model.password))
                {
                    FormsAuthentication.SetAuthCookie(model.nickName, true);
                    return RedirectToAction("Index", "Home");
                } else
                {
                    return View(model);
                }
            }

        } 
        
        [HttpGet]
        public ActionResult Disconnect()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
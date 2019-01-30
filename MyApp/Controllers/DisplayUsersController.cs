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
    public class DisplayUsersController : Controller
    {
        public ActionResult Index()
        {
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);
                List<User> users = repo.getAll();

                List<DisplayInfosModel> models = new List<DisplayInfosModel>();
                foreach(User u in users)
                {
                    DisplayInfosModel model = new DisplayInfosModel()
                    {
                        email = u.email,
                        firstName = u.firstName,
                        lastName = u.lastName,
                        nickName = u.nickName
                    };
                    models.Add(model);
                }

                return View(models);
            }
        
        }

        [HttpGet]
        public ActionResult OtherProfil()
        {
            String nickName = Request.QueryString["nickName"];
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);
                User user = repo.getUser(nickName);
                DisplayInfosModel model = new DisplayInfosModel()
                {
                    email = user.email,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    nickName = user.nickName,
                    UserPhoto = user.UserPhoto
                };
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Follow()
        {
            String nickName = Request.QueryString["nickName"];
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);

                User userFollowed = repo.getUser(nickName);
                User userConnected = repo.getUser(HttpContext.User.Identity.Name);
                userConnected.listUsersfollow.Add(userFollowed);
                userFollowed.listUsersfollowBy.Add(userConnected);

                context.SaveChanges();

                return RedirectToAction("Index", "DisplayUsers");
            }
        }


    }

}
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
    public class DisplayUsersController : Controller
    {
        // GET: DisplayUsers
        public ActionResult Index()
        {
            using(MyAppContext context = new MyAppContext())
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
    }
}
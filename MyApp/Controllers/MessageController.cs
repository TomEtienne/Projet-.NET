using MyApp.Context;
using MyApp.Entities;
using MyApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Message model)
        {
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repoUser = new UserRepository(context);
                MessageRepository repoMessage = new MessageRepository(context);

                User user = repoUser.getUser(HttpContext.User.Identity.Name);
                Message message = new Message()
                {
                    author = user.nickName,
                    text = model.text
                };
                repoMessage.Add(message);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
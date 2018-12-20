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
        // GET: Message
        public ActionResult Index(Message model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repoUser = new UserRepository(context);
                User user = repoUser.getUser(HttpContext.User.Identity.Name);
                MessageRepository repoMessage = new MessageRepository(context);
                Message message = new Message()
                {
                    author = user,
                    text = model.text
                };
                repoMessage.Add(message);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
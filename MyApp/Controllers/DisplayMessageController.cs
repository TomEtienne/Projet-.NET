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
    public class DisplayMessageController : Controller
    {
        public ActionResult Index()
        {
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repoUser = new UserRepository(context);
                User user = repoUser.getUser(HttpContext.User.Identity.Name);
                MessageRepository repo = new MessageRepository(context);
                List<Message> messages = repo.getAllByName(user.nickName);

                List<Message> alMessages = new List<Message>();
                foreach (Message m in messages)
                {
                    Message model = new Message()
                    {
                        author = m.author,
                        text = m.text
                        
                    };
                    alMessages.Add(model);
                }

                return View(alMessages);
            }

        }
    }
}
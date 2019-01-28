using MyApp.Context;
using MyApp.Entities;
using MyApp.Models;
using MyApp.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
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
                    nickName = user.nickName,
                    UserPhoto = user.UserPhoto
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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "UserPhoto")]DisplayInfosModel model)
        {
            using (MyAppContext context = new MyAppContext())
            {
                UserRepository repo = new UserRepository(context);
                User user = repo.getUser(HttpContext.User.Identity.Name);
                user.firstName = model.firstName;
                user.lastName = model.lastName;
                user.email = model.email;
                user.nickName = model.nickName;

                HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];

                if (poImgFile.ContentLength != 0)
                {
                    byte[] imageData = null;

                    //HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }

                    user.UserPhoto = imageData;

                    context.SaveChanges();
                }

                return RedirectToAction("Index","Profil");
            }
        }

    }
}
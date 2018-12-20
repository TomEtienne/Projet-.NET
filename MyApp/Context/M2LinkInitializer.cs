using MyApp.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyApp.Context
{
    public class M2LinkInitializer : DropCreateDatabaseIfModelChanges<MyAppContext>
    {

        protected override void Seed(MyAppContext context)
        {
            UserRepository repo = new UserRepository(context);
            if(repo.getUser("Spocky") == null)
            {
                repo.Add(new Entities.User()
                {
                    firstName = "Tom",
                    lastName = "Etienne",
                    email = "tag.etienne@gmail.com",
                    nickName = "Spocky",
                    password = "Coucou95?"
                });
                context.SaveChanges();
            }
        }

    }
}
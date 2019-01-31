using MyApp.Context;
using MyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Repositories
{
    public class UserRepository
    {
        private MyAppContext context { get; set; }

        public UserRepository(MyAppContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public Boolean CheckUser(string nickName, string password)
        {
            if(nickName != null || password != null)
            {
                User user = context.Users.First((u) => u.nickName == nickName);
                if (user != null)
                {
                    return user.password == password;
                }
                else
                {
                    return false;
                }
            } else
            {
                return false;
            }
           
        }

        public User getUser(string nickName)
        {
            return context.Users.FirstOrDefault((u) => u.nickName == nickName);
        }

        public List<User> getAll()
        {
            return context.Users.ToList();
        }
    }
}
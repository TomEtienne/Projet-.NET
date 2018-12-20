using MyApp.Context;
using MyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Repositories
{
    public class MessageRepository
    {
        private MyAppContext context { get; set; }

        public MessageRepository(MyAppContext context)
        {
            this.context = context;
        }

        public void Add(Message message)
        {
            context.Messages.Add(message);
        }

        public List<Message> getAll()
        {
            return context.Messages.ToList();
        }
    }
}
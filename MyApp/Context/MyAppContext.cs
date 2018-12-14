﻿using MyApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyApp.Context
{
    public class MyAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MyAppContext()
        {
            DbContext db = new DbContext("MyAppContext");
        }

    }
}
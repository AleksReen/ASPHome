using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPHome.Models
{
    public class UserDataBase:DbContext
    {
            public DbSet<User> Users { get; set; }

            public DbSet<Country> Countries { get; set; }

            public DbSet<City> Cities { get; set; }
    }
}
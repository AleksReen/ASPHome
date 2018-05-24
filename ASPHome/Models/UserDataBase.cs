using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASPHome.Models
{
    public class UserDataBase:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public User GetUser(int? id)
        {
            var sqlQuery = "GetUser @userID";

            var sqlParams = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "@userID",  Value = id , Direction = System.Data.ParameterDirection.Input}                
            };

            var user = Database.SqlQuery<User>(sqlQuery, sqlParams).SingleOrDefault();

            return user;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPHome.Models
{
    public class UsersViewModel
    {
        public IEnumerable<User> userList { get; set; }

        public User selectedUser { get; set; }
    }
}
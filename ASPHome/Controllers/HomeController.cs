using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using ASPHome.Models;

namespace ASPHome.Controllers
{
    public class HomeController : Controller
    {
        private UserDataBase db = new UserDataBase();
        // GET: Home
        public ActionResult Index(int? id, int? page)
        {
            ViewBag.selectedUser = id == null ? null : db.GetUser(id);
            List<User> userList = db.Users.Select(user => user).OrderBy(user => user.Name).ToList<User>();

            ViewBag.List = userList;
            return View();
            
        }

        public ActionResult GetAjax(int? id)
        {
            Thread.Sleep(1000);

            var selectedUser = db.Users.Find(id);
            ViewBag.selectedUser = selectedUser;

            return PartialView("_GetAjax", selectedUser);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
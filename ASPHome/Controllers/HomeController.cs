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
        public ActionResult Index(int? id = 1, int page = 1)
        {
            var model = new UsersViewModel()
            {
                userList = db.Users
                    .Select(user => user)
                    .OrderBy(user => user.Name),

                selectedUser = page == 1 ? db.GetUser(id) :
                                           db.Users
                                            .OrderBy(user => user.Name)
                                            .Skip((page - 1) * 10)
                                            .Take(1)
                                            .FirstOrDefault()
            };
            
            return View(model);
            
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
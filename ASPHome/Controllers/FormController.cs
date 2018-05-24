using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPHome.Models;

namespace ASPHome.Controllers
{
    public class FormController : Controller
    {
        private UserDataBase db = new UserDataBase();
        // GET: Form
        [HttpGet]
        public ActionResult CreateForm()
        {
            Init();
            return View();
        }

        [HttpPost]
        public ActionResult CreateForm(User user)
        {
            Init();

            if (ModelState.IsValid)
            {
                var city = db.Cities.First(c => c.CityName == user.City.CityName);
                var country = db.Countries.First(c => c.CountryName == user.Country.CountryName);

                user.Country = country;
                user.City = city;

                db.Users.Add(user);
                db.SaveChanges();
                
                return View("Success", user);
            }
            return View(user) ;
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Redirect($"/Home/Index");
            }

            var editUser = db.Users.Find(id);
            Init(editUser.Country.CountryName, editUser.City.CityName);
            return View(editUser);
        }

        [HttpPost]
        public ActionResult Edit(User u)
        {
            var editUser = db.Users.Find(u.Id);

            if (editUser != null)
            {
                editUser.Name = u.Name;
                editUser.MiddleName = u.MiddleName;
                editUser.Password = u.Password;
                editUser.RePassword = u.Password;
                editUser.Phone = u.Phone;
                editUser.Email = u.Email;
                editUser.Details = u.Details;

                editUser.Country =
                    u.Country.CountryName != null ? db.Countries.Single(c => c.CountryName == u.Country.CountryName) : editUser.Country;

                editUser.City =
                    u.City.CityName != null ? db.Cities.Single(c => c.CityName == u.City.CityName) : editUser.City;

                editUser.Age = u.Age;

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    throw raise;
                }
 
                return Redirect($"/Home/Index/{u.Id}");
            }

            Init(editUser.Country.CountryName, editUser.City.CityName);
            return View(editUser);
        }

        public ActionResult Delete(int? id)
        {
            var deleteUser = db.Users.Find(id);
            return View(deleteUser);
        }

        [HttpPost]
        public ActionResult Delete(User u)
        {

            var deleteUser = db.Users.Find(u.Id);

            if (deleteUser != null)
            {
                db.Users.Remove(deleteUser);
                db.SaveChanges();
                return Redirect("/Home/Index");
            }

            return View();
        }

        #region Helper Method
        void Init()
        {
            List<string> country = db.Countries.Select(c => c.CountryName).ToList<string>();
            SelectList countryList = new SelectList(country);
            ViewBag.country = countryList;

            List<string> city = db.Cities.Select(c => c.CityName).ToList<string>();
            SelectList cityList = new SelectList(city);
            ViewBag.city = cityList;


        }
        void Init(string countryName, string cityName)
        {
            List<string> country = db.Countries.Select(c => c.CountryName).ToList<string>();
            country.Remove(countryName);
            SelectList countryList = new SelectList(country);
            ViewBag.country = countryList;

            List<string> city = db.Cities.Select(c => c.CityName).ToList<string>();
            city.Remove(cityName);
            SelectList cityList = new SelectList(city);
            ViewBag.city = cityList;    
        }
        #endregion
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
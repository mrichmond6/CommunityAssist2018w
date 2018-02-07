using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018w.Models;

namespace CommunityAssist2018w.Controllers
{
    public class RegistrationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Registration
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult RegisterUser([Bind(Include ="LastName, Firstname, Email, Phone, PlainPassword, Apartment, Street, City, State, Zipcode")]NewPerson np)
        {
            int result = db.usp_Register(np.LastName, np.FirstName, np.Email, np.Phone, np.PlainPassword, np.Apartment, np.Street, np.City, np.State, np.Zipcode);
            if(result != -1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
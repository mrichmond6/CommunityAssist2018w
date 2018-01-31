using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018w.Models;
namespace CommunityAssist2018w.Controllers
{
    public class HomeController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        public ActionResult Index()
        {
            //var grts = (from g in db.GrantTypes
                         //select g).ToList();
            return View(db.GrantTypes.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
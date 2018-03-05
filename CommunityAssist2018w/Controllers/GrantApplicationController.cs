using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CommunityAssist2018w.Models;

namespace CommunityAssist2018w.Controllers
{
    public class GrantApplicationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Grants
        public ActionResult Index()
        {
            if (Session["reviewerKey"] == null)
            {
                Message m = new Message
                {
                    MessageText = "You have to be logged in order to apply for assistance!"
                };
                return RedirectToAction("Result", m);
            }
            ViewBag.GrantTypeKey = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "GrantApplicationKey, PersonKey, GrantApplicationDate, GrantTypeKey, GrantApplicationRequestAmount, GrantApplicationReason, GrantApplicationStatusKey, GrantApplicationAllocationAmount, GrantType, GrantApplicationStatu, GrantApplicationReviews, Person")]GrantApplication ga)
        {
            //for donation get userkey from session?
            GrantApplication g = new GrantApplication();
            
                g.GrantApplicationKey = ga.GrantApplicationKey;
                g.PersonKey = (int)Session["reviewerKey"];
                g.GrantAppicationDate = DateTime.Now;
                g.GrantTypeKey = ga.GrantTypeKey;
                g.GrantApplicationRequestAmount = ga.GrantApplicationRequestAmount;

            db.GrantApplications.Add(g);


            Message m = new Message();
            m.MessageText = "You have successfully applied for assistance!";

            return View("Result", m);
        }
        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018w.Models;

namespace CommunityAssist2018w.Controllers
{
    public class DonationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Donation
        public ActionResult Index()
        {
            if (Session["reviewerKey"] == null)
            {
                Message m = new Message
                {
                    MessageText = "You must be logged in to donate"
                };
                return RedirectToAction("Result", m);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "DonationAmount, DonationDate, PersonKey, DonorConfirmationCode")]DonationClass dn)
        {
            //for donation get userkey from session?
            Donation d = new Donation();
            
                d.DonationAmount = dn.DonationAmount;
                d.DonationDate = DateTime.Now;
                d.PersonKey = (int)Session["reviewerKey"];
                d.DonationConfirmationCode = Guid.NewGuid();
                db.Donations.Add(d);

            db.SaveChanges();

        
            Message m = new Message();
            m.MessageText = "Thank you for donating!";

            return View("Result", m);
        }
        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}
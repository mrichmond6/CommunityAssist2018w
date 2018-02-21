using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssist2018w.Models
{
    public class DonationClass
    {
        public int DonationAmount { get; set; }
        public string DonationDate { get; set; }

        public int PersonKey { get; set; }
        public int DonationConfirmationCode { get; set; }

    }
}
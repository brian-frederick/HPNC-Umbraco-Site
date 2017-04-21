using Square.Connect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPNC_Website.Models
{
    public class DonationFormModel
    {
        public string status { get; set; }
        public int Amount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nonce { get; set; }
        public Address BillingAddress { get; set; }
    }
}
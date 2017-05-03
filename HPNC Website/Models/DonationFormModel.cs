
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
        public string Name { get; set; }
        public string Email { get; set; }
        public string Nonce { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
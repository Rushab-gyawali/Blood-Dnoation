using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDMS.Models
{
    public class DonationModel
    {
        public int DonationId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DonationCode { get; set; }
        public int DonorId { get; set; }
        public string DateOfDonation { get; set; }
        public string DonationOriganization { get; set; }
        public string DonationAddress { get; set; }
        public string PreviousDonationDate { get; set; }
        public string User { get; set; }
        public IEnumerable<SelectListItem> DonorList { get; set; }

    }
}
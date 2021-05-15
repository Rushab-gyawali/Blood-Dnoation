using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDMS.Models
{
    public class DonationModel
    {
        public int DonationId { get; set; }
        public string DonationCode { get; set; }
        public int DonorId { get; set; }
        public DateTime DateOfDonation { get; set; }
        public string DonationOriganization { get; set; }
        public string DonationAddress { get; set; }
        public DateTime PreviousDonationDate { get; set; }
        public string User { get; set; }
    }
}
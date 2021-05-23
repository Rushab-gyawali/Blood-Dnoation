using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Shared.Common
{
    public class DonationCommon
    {
        public int DonationId { get; set; }
        public string DonationCode { get; set; }
        public int DonorId { get; set; }
        public string DateOfDonation { get; set; }
        public string DonationOriganization { get; set; }
        public string DonationAddress { get; set; }
        public string PreviousDonationDate { get; set; }
        public string User { get; set; }
    }
}

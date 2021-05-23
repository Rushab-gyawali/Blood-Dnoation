using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.Donation
{
    public interface IDonationBusiness
    {
        List<DonationCommon> GetlastDonationdate(string DonorId);
        DbResponse New(DonationCommon common);
    }
}

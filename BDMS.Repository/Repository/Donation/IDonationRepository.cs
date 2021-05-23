using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Repository.Repository.Donation
{
    public interface IDonationRepository
    {
        List<DonationCommon> GetlastDonationdate(string DonorId);
        DbResponse New(DonationCommon common);
    }
}

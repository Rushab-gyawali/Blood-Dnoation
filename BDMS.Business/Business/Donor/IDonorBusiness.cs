using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.Donor
{
    public interface IDonorBusiness
    {
        List<DonorCommon> List();
        DbResponse New(DonorCommon model);
        List<DonorCommon> GetDonorsByID(string id);
    }
}

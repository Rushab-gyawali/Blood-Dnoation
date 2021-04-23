using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Repository.Repository.Donor
{
    public interface IDonorRepository
    {
        List<DonorCommon> GetDonorsByID(string id);
        List<DonorCommon> List();
        DbResponse New(DonorCommon model);
    }
}

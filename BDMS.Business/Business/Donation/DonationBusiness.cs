using BDMS.Repository.Repository.Donation;
using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.Donation
{
    public class DonationBusiness : IDonationBusiness
    {
        IDonationRepository repo;
        public DonationBusiness(IDonationRepository _repo)
        {
            repo = _repo;
        }
      
        public List<DonationCommon> GetlastDonationdate(string DonorId)
        {
            return repo.GetlastDonationdate(DonorId);
        }

        public DbResponse New(DonationCommon common)
        {
            return repo.New(common);        }
    }
}

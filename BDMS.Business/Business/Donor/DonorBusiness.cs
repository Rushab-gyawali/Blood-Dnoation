using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDMS.Repository.Repository.Donor;
using BDMS.Shared.Common;

namespace BDMS.Business.Business.Donor
{
    public class DonorBusiness : IDonorBusiness
    {
        IDonorRepository repo;
        public DonorBusiness(IDonorRepository _repo)
        {
            repo = _repo;
        }

        public List<DonorCommon> List()
        {
            return repo.List();
        }

        public DbResponse New(DonorCommon model)
        {
            return repo.New(model);
        }
    }
}

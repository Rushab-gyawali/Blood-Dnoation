using BDMS.Repository.Repository;
using BDMS.Repository.Repository.Designation;
using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.Designation
{
    public class DesignationBusiness : IDesignationBusiness
    {
        RepositoryDao repo;
        
        public DesignationBusiness(IDesignationRepository _repo)
        {
            repo = _repo;
        }
        public List<DesignationCommon> List()
        {
            return List.repo();
        }

        public DbResponse New(DesignationCommon common)
        {
            return New.repo(common);
        }
    }
}

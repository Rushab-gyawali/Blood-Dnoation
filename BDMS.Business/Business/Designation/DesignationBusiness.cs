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
        IDesignationRepository repo;
        
        public DesignationBusiness(IDesignationRepository _repo)
        {
            repo = _repo;
        }

        public List<DesignationCommon> GetDesignationById(string id)
        {
            return repo.GetDesignationById(id);
        }

        public List<DesignationCommon> List()
        {
            return repo.List();
        }

        public DbResponse New(DesignationCommon common)
        {
            return repo.New(common);
        }
    }
}

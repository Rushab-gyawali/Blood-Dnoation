using BDMS.Repository.Repository.Staff;
using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.Staff
{
    public class StaffBusiness : IStaffBusiness
    {
        IStaffRepository repo;

        public StaffBusiness(IStaffRepository _repo)
        {
            repo = _repo;
        }

        public List<StaffCommon> GetStaffByID(string id)
        {
            return repo.GetStaffByID(id);
        }

        public List<StaffCommon> List()
        {
            return repo.List();
        }


        public DbResponse New(StaffCommon common)
        {
            return repo.New(common);
        }
    }

}

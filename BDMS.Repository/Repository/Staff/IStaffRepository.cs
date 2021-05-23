using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Repository.Repository.Staff
{
    public interface IStaffRepository
    {
        List<StaffCommon> List();
        DbResponse New(StaffCommon common);
        List<StaffCommon> GetStaffByID(string id);
    }
}

using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.Staff
{
    public interface IStaffBusiness
    {
        List<StaffCommon> List();
        DbResponse New(StaffCommon common);
        List<StaffCommon> GetStaffByID(string id);
    }
}

using BDMS.Shared.Common;
using MVCERP.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.User
{
    public interface IDonorBusiness
    {
        List<DonorCommon> List();
        DbResponse New(DonorCommon model);
    }
}

using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.Designation
{
    public interface IDesignationBusiness
    {
        List<DesignationCommon> List();
        DbResponse New(DesignationCommon common);
    }
}

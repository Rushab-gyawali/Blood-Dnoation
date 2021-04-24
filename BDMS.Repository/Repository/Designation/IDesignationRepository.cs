using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Repository.Repository.Designation
{
    public interface IDesignationRepository
    {
        List<DesignationCommon> List();
        DbResponse New(DesignationCommon common);
        List<DesignationCommon> GetDesignationById(string id);

    }
}

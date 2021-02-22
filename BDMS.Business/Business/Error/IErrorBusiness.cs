using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.Error
{
    public interface IErrorBusiness
    {
        ErrorLogsCommon Details(string id, string User);
    }
}

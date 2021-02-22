using BDMS.Repository.Repository.Error;
using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.Error
{
    public class ErrorBusiness : IErrorBusiness
    {

        IErrorRepo repo;
        public ErrorBusiness(ErrorRepo _repo)
        {
            repo = _repo;
        }
        public Shared.Common.ErrorLogsCommon Details(string id, string User)
        {
            return repo.Details(id, User);
        }
    }
}

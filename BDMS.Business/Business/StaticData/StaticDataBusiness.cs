using BDMS.Repository.Repository.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.StaticData
{
    public class StaticDataBusiness : IStaticDataBusiness
    {
        IStaticDataRepository repo;
        public StaticDataBusiness(StaticDataRepository _repo)
        {
            repo = _repo;
        }

        public StaticDataBusiness()
        {
            // TODO: Complete member initialization
        }
        public List<BDMS.Shared.Common.StaticDataCommon> GetList(string User, string Id, string Search, int Pagesize)
        {
            return repo.GetList(User, Id, Search, Pagesize);
        }
        public List<BDMS.Shared.Common.StaticDataCommon> GetSubList(string User, string Id)
        {
            return repo.GetSubList(User, Id);
        }


        public BDMS.Shared.Common.DbResponse Manage(BDMS.Shared.Common.StaticDataCommon model)
        {
            return repo.Manage(model);
        }


        public BDMS.Shared.Common.DbResponse Delete(string User, int id)
        {
            return repo.Delete(User, id);
        }
        public BDMS.Shared.Common.DbResponse InsertErrorLog(BDMS.Shared.Common.ErrorLogsCommon log)
        {
            if (null == repo)
                repo = new StaticDataRepository();

            return repo.InsertErrorLog(log);
        }

        public Shared.Common.DbResponse EOD(string User)
        {
            return repo.EOD(User);
        }


        public Shared.Common.DbResponse BOD(string User, string Date)
        {
            return repo.BOD(User, Date);
        }
    }
}

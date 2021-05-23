using BDMS.Repository.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDMS.Business.Business.Common;

namespace BDMS.Business.Business.Common
{
    public class CommonBusiness : ICommonBusiness
    {
        ICommonRepository repo;
        public CommonBusiness(CommonRepository _repo)
        {
            repo = _repo; 
        }

        public Dictionary<string, string> StaticDropdown(string ddlName)
        {
            return repo.StaticDropdown(ddlName);
        }

        public List<Dictionary<string, string>> SetDropdownList(string ddlName, string User)
        {
            return repo.DropdownList(ddlName, User);
        }

        public Dictionary<string, string> SetDropdown(string ddlName, string Param = "")
        {
            return repo.Dropdown(ddlName, Param);
        }


        public System.Data.DataSet GetDropDownLists(string flag)
        {
            return repo.GetDropDownLists(flag);
        }


        public List<object> LoadAutocomplete(string type, string param, string user)
        {
            return repo.LoadAutocomplete(type, param, user);
        }


        public object GetDropdownForJQuery(string flag, string param, string User)
        {
            return repo.GetDropdownForJQuery(flag, param, User);
        }

        public Dictionary<string, string> SetDropdownUser(string ddlName, string Param = "")
        {
            return repo.SetDropdownUser(ddlName, Param);
        }
    }
}

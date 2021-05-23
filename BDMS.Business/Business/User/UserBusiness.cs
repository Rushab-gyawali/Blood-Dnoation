using BDMS.Repository.Repository.User;
using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Business.Business.User
{
    public class UserBusiness : IUserBusiness
    {
        IUserRepository repo;
        public UserBusiness(UserRepository _repo)
        {
            repo = _repo;
        }

        public StaffCommon UserLogin(LoginCommon login)
        {
            return repo.UserLogin(login);
        }
    }
}

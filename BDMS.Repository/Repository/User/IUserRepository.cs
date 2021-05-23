using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Repository.Repository.User
{
    public interface IUserRepository
    {
        StaffCommon UserLogin(LoginCommon login);
    }
}

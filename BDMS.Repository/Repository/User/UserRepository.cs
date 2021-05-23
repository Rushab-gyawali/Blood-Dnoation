using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Repository.Repository.User
{
    public class UserRepository : IUserRepository
    {
        RepositoryDao dao;
        public UserRepository()
        {
            dao = new RepositoryDao();
        }
        public StaffCommon UserLogin(LoginCommon login)
        {
            var sql = "EXEC PROC_USER_LOGIN @FLAG ='login'";
            sql += ",@UserName = " + dao.FilterString(login.UserName);
            sql += ",@Password = " + dao.FilterString(login.Password);
            sql += ",@Ip = " + dao.FilterString(login.Ip);
            sql += ",@BrowserInfo = " + dao.FilterString(login.BrowserInfo);
            var dr = dao.ExecuteDataRow(sql);
            var model = new StaffCommon();
            try
            {
                if (null != dr)
                {
                    model.Code = dr["CODE"].ToString();
                    model.Msg = dr["msg"].ToString();
                 
                    if (model.Code == "0")
                    {
                        return model;
                    }

                }
            }
            catch
            {
                model.Code = "1";//dr["CODE"].ToString();
                model.Msg = "Provided Username or Password is Incorrect.";//dr["msg"].ToString();
            }

            return model;
        }
    }
}

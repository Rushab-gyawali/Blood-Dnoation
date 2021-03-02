using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDMS.Shared.Common;

namespace BDMS.Repository.Repository.Donor
{
    public class DonorRepository : IDonorRepository
    {

        RepositoryDao dao;
        public DonorRepository()
        {
            dao = new RepositoryDao();

        }

        public List<DonorCommon> List()
        {
            var list = new List<DonorCommon>();
            try
            {
                var sql = "EXEC proc_Donor ";
                sql += "@Flag = 'List'";
                var dt = dao.ExecuteDataTable(sql);

                if (null != dt)
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in dt.Rows)
                    {
                        var common = new DonorCommon()
                        {
                          DonorId = Convert.ToInt32(item["DonorId"]),
                          FirstName = item["FullName"].ToString(),
                          MiddleName = item["FullName"].ToString(),
                          LastName = item["FullName"].ToString(),
                          Gender = item["FullName"].ToString(),
                          BloodGroup = item["FullName"].ToString(),
                          PhoneNo = item["FullName"].ToString(),
                          City = item["FullName"].ToString(),
                        };
                        sn++;
                        list.Add(common);
                    }
                }
                return list;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public DbResponse New(DonorCommon model)
        {
            var sql = "EXEC proc_Donor ";
            sql += "@Flag = "  +  dao.FilterString((model.DonorId > 0 ? "U" : "I"));
            sql += ",@FirstName = " + dao.FilterString(model.FirstName);
            sql += ",@MiddleName = " + dao.FilterString(model.MiddleName);
            sql += ",@LastName = " + dao.FilterString(model.LastName);
            sql += ",@Gender = " + dao.FilterString(model.Gender);
            sql += ",@DateOfBirth = " + dao.FilterString(model.DateOfBirth);
            sql += ",@BloodGroup = " + dao.FilterString(model.BloodGroup);
            sql += ",@Email = " + dao.FilterString(model.Email);
            sql += ",@PhoneNo = " + dao.FilterString(model.PhoneNo);
            sql += ",@District = " + dao.FilterString(model.District);
            sql += ",@Munciplity = " + dao.FilterString(model.Munciplity);
            sql += ",@City = " + dao.FilterString(model.City);
            sql += ",@WardNo = " + model.WardNo;
            if (model.DonorId == 0)
            {
                return dao.ParseDbResponse(sql);
            }
            else
            {
                return dao.ParseDbResponse(sql);
            }

        }
    }
}

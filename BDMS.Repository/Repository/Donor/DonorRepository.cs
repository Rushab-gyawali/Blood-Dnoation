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
                          DateOfBirth = Convert.ToDateTime(item["DateOfBirth"]),
                          BloodGroup = item["FullName"].ToString(),
                          Email = item["FullName"].ToString(),
                          PhoneNo = item["FullName"].ToString(),
                          //District = item["FullName"].ToString(),
                          //Munciplity = item["FullName"].ToString(),
                          //City = item["FullName"].ToString(),
                          //WardNo = Convert.ToInt32(item["WardNo"]),
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
            var sql = "EXEX proc_Donor ";
            sql += "@Flag = "  +  dao.FilterString((model.DonorId > 0 ? "U" : "I"));
            sql += "@FirstName = " + dao.FilterString(model.FirstName);
            sql += "@MiddleName = " + dao.FilterString(model.FirstName);
            sql += "@LastName = " + dao.FilterString(model.FirstName);
            sql += "@Gender = " + dao.FilterString(model.FirstName);
            sql += "@DateOfBirth = " + dao.FilterString(model.FirstName);
            sql += "@BloodGroup = " + dao.FilterString(model.FirstName);
            sql += "@Email = " + dao.FilterString(model.FirstName);
            sql += "@PhoneNo = " + dao.FilterString(model.FirstName);
            sql += "@District = " + dao.FilterString(model.FirstName);
            sql += "@Munciplity = " + dao.FilterString(model.FirstName);
            sql += "@City = " + dao.FilterString(model.FirstName);
            sql += "@WardNo = " + dao.FilterString(model.FirstName);
            sql += "@CreatedBy = " + dao.FilterString(model.FirstName);
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

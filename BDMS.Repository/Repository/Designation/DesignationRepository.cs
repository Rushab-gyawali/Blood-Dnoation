using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Repository.Repository.Designation
{
    public class DesignationRepository : IDesignationRepository
    {

        RepositoryDao dao;

        public DesignationRepository()
        {
            dao = new RepositoryDao();

        }
        public List<DesignationCommon> List()
        {
            var list = new List<DesignationCommon>();
            try
            {
                var sql = "EXEC proc_Designation ";
                sql += "@Flag = 'List'";
                var dt = dao.ExecuteDataTable(sql);

                if (null != dt)
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in dt.Rows)
                    {
                        var common = new DesignationCommon()
                        {
                            SNo = sn,
                            
                        };
                        sn++;
                        list.Add(common);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DbResponse New(DesignationCommon common)
        {
            throw new NotImplementedException();
            //var sql = "EXEC proc_Donor ";
            //sql += "@Flag = " + dao.FilterString((model.DonorId > 0 ? "Update" : "Insert"));
            //sql += ",@FirstName = " + dao.FilterString(model.FirstName);
            //sql += ",@MiddleName = " + dao.FilterString(model.MiddleName);
            //sql += ",@LastName = " + dao.FilterString(model.LastName);
            //sql += ",@Gender = " + dao.FilterString(model.Gender);
            //sql += ",@DateOfBirth = " + dao.FilterString(model.DateOfBirth);
            //sql += ",@BloodGroup = " + dao.FilterString(model.BloodGroup);
            //sql += ",@Email = " + dao.FilterString(model.Email);
            //sql += ",@PhoneNo = " + dao.FilterString(model.PhoneNo);
            //sql += ",@District = " + dao.FilterString(model.District);
            //sql += ",@Munciplity = " + dao.FilterString(model.Munciplity);
            //sql += ",@City = " + dao.FilterString(model.City);
            //sql += ",@WardNo = " + model.WardNo;
            //if (model.DonorId == 0)
            //{
            //    return dao.ParseDbResponse(sql);
            //}
            //else
            //{
            //    return dao.ParseDbResponse(sql);
            //}
        }
    }
}

using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Repository.Repository.Staff
{
    public class StaffRepository : IStaffRepository
    {


        RepositoryDao dao;
        public StaffRepository()
        {
            dao = new RepositoryDao();

        }

        public List<StaffCommon> GetStaffByID(string id)
        {
            var list = new List<StaffCommon>();
            try
            {
                var sql = "EXEC proc_Staff ";
                sql += "@Flag = 'getStaffById'";
                sql += ",@StaffId = " + dao.FilterString(id);
                var dt = dao.ExecuteDataTable(sql);

                if (null != dt)
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in dt.Rows)
                    {
                        var common = new StaffCommon()
                        {
                            StaffId = Convert.ToInt32(item["StaffId"]),
                            StaffFirstName = item["StaffFirstName"].ToString(),
                            StaffMiddleName = item["StaffMiddleName"].ToString(),
                            StaffLastName = item["StaffLastName"].ToString(),
                            Gender = item["Gender"].ToString(),
                            DateOfBirth = item["DateOfBirth"].ToString(),
                            BloodGroup = item["BloodGroup"].ToString(),
                            Email = item["Email"].ToString(),
                            PhoneNo = item["PhoneNo"].ToString(),
                            District = item["District"].ToString(),
                            Munciplity = item["Munciplity"].ToString(),
                            City = item["City"].ToString(),
                            StaffAddress = item["StaffAddress"].ToString(),
                            WardNo = Convert.ToInt32(item["WardNo"]),
                            Designation = item["Designation"].ToString(),
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

        public List<StaffCommon> List()
        {
            var list = new List<StaffCommon>();
            try
            {
                var sql = "EXEC proc_Staff ";
                sql += "@Flag = 'List'";
                var dt = dao.ExecuteDataTable(sql);

                if (null != dt)
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in dt.Rows)
                    {
                        var common = new StaffCommon()
                        {
                            SNNo = sn,
                            FullName = item["StaffFullName"].ToString(),
                            Designation = item["Designation"].ToString(),
                            PhoneNo = item["PhoneNo"].ToString(),
                            Email = item["Email"].ToString(),
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

        public DbResponse New(StaffCommon common)
        {
            var sql = "EXEC proc_Staff ";
            sql += "@Flag = " + dao.FilterString((common.StaffId > 0 ? "Update" : "InsertStaff"));
            sql += ",@StaffFirstName = " + dao.FilterString(common.StaffFirstName);
            sql += ",@StaffMiddleName = " + dao.FilterString(common.StaffMiddleName);
            sql += ",@StaffLastName = " + dao.FilterString(common.StaffLastName);
            sql += ",@StaffAddress = " + dao.FilterString(common.StaffAddress);
            sql += ",@Gender = " + dao.FilterString(common.Gender);
            sql += ",@DateOfBirth = " + dao.FilterString(common.DateOfBirth);
            sql += ",@Email = " + dao.FilterString(common.Email);
            sql += ",@PhoneNo = " + dao.FilterString(common.PhoneNo);
            sql += ",@District = " + dao.FilterString(common.District);
            sql += ",@Munciplity = " + dao.FilterString(common.Munciplity);
            sql += ",@City = " + dao.FilterString(common.City);
            sql += ",@WardNo = " + dao.FilterString(common.WardNo.ToString());
            if (common.StaffId == 0)
            {
                sql += ",@CreatedBy = 'system'";
                return dao.ParseDbResponse(sql);
            }
            else
            {
                return dao.ParseDbResponse(sql);
            }
        }
    }
}

﻿using System;
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

        public List<DonorCommon> GetDonorsByID(string id)
        {
            var list = new List<DonorCommon>();
            try
            {
                var sql = "EXEC proc_Donor ";
                sql += "@Flag = 'GetDonorById'";
                sql += ",@DonorId= " + dao.FilterString(id);
                var dt = dao.ExecuteDataTable(sql);

                if (null != dt)
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in dt.Rows)
                    {
                        var common = new DonorCommon()
                        {
                            DonorId = Convert.ToInt32(item["DonorId"]),
                            FirstName = item["FirstName"].ToString(),
                            MiddleName = item["MiddleName"].ToString(),
                            LastName = item["LastName"].ToString(),
                            Gender = item["Gender"].ToString(),
                            DateOfBirth = item["DateOfBirth"].ToString(),
                            BloodGroup = item["BloodGroup"].ToString(),
                            Email = item["Email"].ToString(),
                            PhoneNo = item["PhoneNo"].ToString(),
                            District = item["District"].ToString(),
                            Munciplity = item["Munciplity"].ToString(),
                            City = item["City"].ToString(),
                            WardNo = Convert.ToInt32(item["WardNo"])
                        };
                        sn++;
                        list.Add(common);
                    }
                }
                return list;
            }
            catch
            {
                return list;
            }
           
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
                          SNo = sn,
                          FullName = item["FullName"].ToString(),
                          BloodGroup = item["BloodGroup"].ToString(),
                          PhoneNo = item["PhoneNo"].ToString(),
                          Email = item["Email"].ToString(),
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
            sql += "@Flag = "  +  dao.FilterString((model.DonorId > 0 ? "Update" : "Insert"));
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
            sql += ",@CreatedBy = " + model.CreatedBy;
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

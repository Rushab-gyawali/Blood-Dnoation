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

        public List<DesignationCommon> GetDesignationById(string id)
        {
            var list = new List<DesignationCommon>();
            try
            {
                var sql = "EXEC proc_Designation ";
                sql += "@Flag = 'List'";
                sql += ",@DesignationId = " + dao.FilterString(id);
                sql += ",@User = " + dao.FilterString(id);
                var dt = dao.ExecuteDataTable(sql);

                if (null != dt)
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in dt.Rows)
                    {
                        var common = new DesignationCommon()
                        {
                            DesignationId = item["DesignationId"].ToString(),
                            DesignationName =item["DesignationName"].ToString(),
                            Remarks =item["Remarks"].ToString(),

                        };
                        sn++;
                        list.Add(common);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                return list;
            }
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

            var sql = "EXEC proc_Donor ";
            sql += "@Flag = " + dao.FilterString((common.DesignationId == "" ? "Insert":"Update"  ));
            sql += ",@DesignationId = " + dao.FilterString(common.DesignationId);
            sql += ",@Designationname = " + dao.FilterString(common.DesignationName);
            sql += ",@Remarks = " + dao.FilterString(common.Remarks);

            if (common.DesignationId == "")
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

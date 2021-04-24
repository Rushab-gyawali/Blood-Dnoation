using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Data;
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
            var sql = "EXEC proc_Designation ";
            sql += "@Flag = 'GetDesignationById'";
            sql += ",@Designationid = " + dao.FilterString(id);
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                int sn = 1;
                foreach (DataRow item in dt.Rows)
                {
                    var common = new DesignationCommon
                    {
                        DesignationId = Convert.ToInt32(item["RowId"]),
                        DesignationName = item["DesignationName"].ToString(),
                        Remarks = item["Remarks"].ToString()
                    };
                    sn++;
                    list.Add(common);
                }
            }
            return list;
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
                            DesignationId = Convert.ToInt32(item["RowId"]),
                            DesignationName = item["DesignationName"].ToString()
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
            //throw new NotImplementedException();
            var sql = "EXEC proc_Designation ";
            sql += "@Flag = " + dao.FilterString(common.DesignationId > 0 ?"Update" : "Insert");
            sql += ",@DesignationName = " + dao.FilterString(common.DesignationName);
            sql += ",@Remarks = " + dao.FilterString(common.Remarks);
            if (common.DesignationId == 0)
            {
                return dao.ParseDbResponse(sql);
            }
            else
            {
                sql += ",@DesignationId = " + dao.FilterString(common.DesignationId.ToString());
                return dao.ParseDbResponse(sql);
            }
        }
    }
}

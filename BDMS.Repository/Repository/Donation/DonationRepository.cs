using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Repository.Repository.Donation
{
    public class DonationRepository : IDonationRepository
    {
        RepositoryDao dao;
        public DonationRepository()
        {
            dao = new RepositoryDao();

        }
        public List<DonationCommon> GetlastDonationdate(string DonorId)
        {
            var list = new List<DonationCommon>();
            try
            {
                var sql = "EXEC proc_Donation ";
                sql += "@Flag =  'GetLastDonationDate'";
                sql += ",@DonorId = " + dao.FilterString(DonorId);
                var dt = dao.ExecuteDataTable(sql);

                if (null != dt)
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in dt.Rows)
                    {
                        var common = new DonationCommon()
                        {

                            DonorId = Convert.ToInt32(item["DonorId"]),
                            PreviousDonationDate = (item["LastDonationDate"].ToString()),

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

        public DbResponse New(DonationCommon common)
        {
            var sql = "EXEC proc_Donation ";
            sql += "@Flag = " + dao.FilterString("Donation");
            sql += ",@DonorId = " + dao.FilterString(common.DonorId.ToString());
            sql += ",@LastDonationDate = " + dao.FilterString(common.PreviousDonationDate.ToString());
            sql += ",@DonationDate = " + dao.FilterString(common.DateOfDonation.ToString());
            return dao.ParseDbResponse(sql);
        }
    }
}

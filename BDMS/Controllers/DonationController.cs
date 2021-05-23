using BDMS.Business.Business.Common;
using BDMS.Business.Business.Donation;
using BDMS.Models;
using BDMS.Shared.Common;
using MVCERP.Web.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDMS.Controllers
{
    public class DonationController : Controller
    {
        ICommonBusiness ddl;
        IDonationBusiness buss;
        public DonationController(ICommonBusiness _ddl, IDonationBusiness _buss)
        {
            ddl = _ddl;
        buss = _buss;
        }
       
        // GET: Donation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Donation()
        {
            var model = new DonationModel();
            loadDDL(model);
            return View();
        }
        public ActionResult loadDDL(DonationModel model)
        {
            model.DonorList = StaticData.SetDDLValue(ddl.SetDropdown("DonorDropDown", ""), "", "Select Donor...");
            return View(model);
        }
        [HttpPost]
        public ActionResult GetLastdonatedDate(string DonorId)
        {            
            var list = buss.GetlastDonationdate(DonorId);
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Donation(DonationModel model)
        {
            try
            {
                //ModelState.Remove("PreviousDonationDate");
                if (ModelState.IsValid)
                {
                    var DonationCommon = new DonationCommon();
                    DonationCommon.DonorId = model.DonorId;
                    DonationCommon.PreviousDonationDate = model.PreviousDonationDate.ToString();
                    DonationCommon.DateOfDonation = model.DateOfDonation.ToString();
                    var response = buss.New(DonationCommon);
                StaticData.SetMessageInSession(response);
                if (response.ErrorCode == 1)
                {
                    ModelState.AddModelError("", response.Message);
                    return View(model);
                }
                return RedirectToAction("Donation", "Donation");
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));

                ModelState.AddModelError("", errors);
            }

        }
            catch(Exception e)
            {
                throw e;
            }

                return View();
        }
    }
}
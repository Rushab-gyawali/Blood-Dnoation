using BDMS.Business.Business.Staff;
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
    public class StaffController : Controller
    {
        IStaffBusiness buss;

        public StaffController(IStaffBusiness _buss)
        {
            buss = _buss;
        }
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult List()
        {
            var data = buss.List();
            for (int i = 0; i < data.Count; i++)
            {
                //data[i].Action = StaticData.GetActions("Donor", data[i].DonorId, data[i].DonorId.ToString(), "New");
            }
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }




        public ActionResult New()
        {
            string id = Request.QueryString["id"];
            var StaffId = StaticData.Base64Encode(id);
            var model = new StaffModel();
            if (StaffId == "")
            {
                return View();
            }
            else
            {
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult New(StaffModel model)
        {
            if (ModelState.IsValid)
            {
                StaffCommon common = new StaffCommon();

                common.StaffId = Convert.ToInt32(model.StaffId);
                common.StaffFirstName = model.StaffFirstName;
                common.StaffMiddleName = model.StaffMiddleName;
                common.StaffLastName = model.StaffLastName;
                common.Gender = model.Gender;
                common.DateOfBirth = model.DateOfBirth;
                common.BloodGroup = model.BloodGroup;
                common.Email = model.Email;
                common.PhoneNo = model.PhoneNo;
                common.District = model.District;
                common.Munciplity = model.Munciplity;
                common.City = model.City;
                common.WardNo = Convert.ToInt32(model.WardNo);
                common.StaffAddress = model.StaffAddress;
                var response = buss.New(common);
                //StaticData.SetMessageInSession(response);
                if (response.ErrorCode == 0)
                {
                    ModelState.AddModelError("", response.Message);
                    return View(model);
                }
                return RedirectToAction("Index", "Donor");
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));

                ModelState.AddModelError("", errors);
            }
            ViewData["msg"] = "An error occured while registering the staff";
            return View(model);
        }
    }
}
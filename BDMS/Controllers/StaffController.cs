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
                data[i].Action = StaticData.GetActions("Staff", data[i].StaffId, data[i].StaffId.ToString(), "New");
            }
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult New()
        {
            string id = Request.QueryString["id"];
            var StaffId = StaticData.Base64Decode_URL(id);
            var model = new StaffModel();
            if (StaffId == "")
            {
                return View();
            }
            else
            {
                var data = buss.GetStaffByID(StaffId);
                model.StaffId = data[0].StaffId;
                model.StaffFirstName = data[0].StaffFirstName;
                model.StaffMiddleName = data[0].StaffMiddleName;
                model.StaffLastName = data[0].StaffLastName;
                model.Gender = data[0].Gender;
                model.DateOfBirth = data[0].DateOfBirth;
                model.Email = data[0].Email;
                model.BloodGroup = data[0].BloodGroup;
                model.PhoneNo = data[0].PhoneNo;
                model.District = data[0].District;
                model.BloodGroup = data[0].BloodGroup;
                model.WardNo = data[0].WardNo;
                model.City = data[0].City;
                model.Munciplity = data[0].Munciplity;
                model.Designation = data[0].Designation;
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult New(StaffModel model)
        {
            if (ModelState.IsValid)
            {
                StaffCommon common = new StaffCommon();

                common.StaffId = model.StaffId;
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
                common.Designation = model.Designation;
                common.WardNo = Convert.ToInt32(model.WardNo);
                common.StaffAddress = model.StaffAddress;
                common.UserName = model.UserName;
                common.Password = StaticData.Base64Encode(model.Password);
                var response = buss.New(common);
                //StaticData.SetMessageInSession(response);
                if (response.ErrorCode == 1)
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
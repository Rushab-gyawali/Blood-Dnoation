using BDMS.Business.Business.Common;
using BDMS.Business.Business.Donor;
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
    public class DonorController : Controller   
    {

        IDonorBusiness buss;
        ICommonBusiness ddl;

        public DonorController(IDonorBusiness _buss, ICommonBusiness _ddl)
        {
            buss = _buss;
            ddl = _ddl;
        }
        // GET: Donor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult loadDDL(DonorModel model)
        {
            model.GenderList = StaticData.SetDDLValue(ddl.SetDropdown("Gender", ""), "", "Select Gender...");
            model.BloodGrouplist = StaticData.SetDDLValue(ddl.SetDropdown("BloodGroup", ""), "", "Select BloodGroup...");
            return View(model);
        }
        [HttpPost]
        public JsonResult List()
        {
            var data = buss.List();
            for (int i = 0; i < data.Count; i++)
            {
                data[i].Action = StaticData.GetActions("Donor", data[i].DonorId, data[i].DonorId.ToString(), "New");
            }
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult New()
        {
            string id = Request.QueryString["id"];
            var DonorId = StaticData.Base64Decode_URL(id);
            var model = new DonorModel();
            loadDDL(model);
            if (DonorId == "")
            {
                return View(model);
            }
            else
            {
                var data = buss.GetDonorsByID(DonorId);
                model.Donorid = data[0].DonorId;
                model.FirstName = data[0].FirstName;
                model.MiddleName = data[0].MiddleName;
                model.LastName = data[0].LastName;
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
                return View(model);
            }
        }


        [HttpPost]
        public ActionResult New(DonorModel model)
        {
            //var donorId = StaticData.GetIdFromQuery("id");
            loadDDL(model);
            if (ModelState.IsValid)
            {
                DonorCommon common = new DonorCommon();

                common.DonorId = model.Donorid;
                common.FirstName = model.FirstName;
                common.MiddleName = model.MiddleName;
                common.LastName = model.LastName;
                common.Gender = model.Gender;
                common.DateOfBirth = model.DateOfBirth;
                common.BloodGroup = model.BloodGroup;
                common.Email = model.Email;
                common.PhoneNo = model.PhoneNo;
                common.District = model.District;
                common.Munciplity = model.Munciplity;
                common.City = model.City;
                common.WardNo = Convert.ToInt32(model.WardNo);
                common.CreatedBy = "Admin";
                var response = buss.New(common);
                StaticData.SetMessageInSession(response);
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
            ViewData["msg"] = "An error occured while registering the Donor";
            return View(model);
        }

    }
}
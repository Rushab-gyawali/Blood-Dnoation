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
        public DonorController(IDonorBusiness _buss)
        {
            buss = _buss;
        }
        // GET: Donor
        public ActionResult Index()
        {
            return View();
        }

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
            var DonorId = StaticData.Base64Encode_URL(id);
            var model = new DonorModel();
            if (DonorId == "")
            {
                return View();
            }
            else
            {
                //var data = buss.GetById(DonorId);
                //model.ID = data[0].ID.ToString();
                //model.FullName = data[0].FullName;
                //model.UserName = data[0].UserName;
                //model.Email = data[0].Email;
                //model.PhoneNo = data[0].PhoneNo;
                //model.Password = data[0].Password;
                ////model.AdminRight = Convert.ToBoolean(data[0].AdminRight);

                return View(model);
            }
        }


        [HttpPost]
        public ActionResult New(DonorModel model)
        {
            if (ModelState.IsValid)
            {
                DonorCommon common = new DonorCommon();

                common.DonorId = Convert.ToInt32(model.Donorid);
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
                common.CreatedBy = model.CreatedBy;
                var response = buss.New(common);
              //  StaticData.SetMessageInSession(response);
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
            ViewData["msg"] = "An error occured while registering the Donor";
            return View(model);
        }
    }
}
using BDMS.Business.Business.Designation;
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
    public class DesignationController : Controller
    {

        IDesignationBusiness buss;

        public DesignationController(IDesignationBusiness _buss)
        {
            buss = _buss;
        }


        // GET: Designation
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
            var DonorId = StaticData.Base64Encode_URL(id);
            var model = new DonorModel();
            if (DonorId == "")
            {
                return View();
            }
            else
            {
                return View(model);
            }
        }


        [HttpPost]
        public ActionResult New(DesignationModel model)
        {
            if (ModelState.IsValid)
            {
                DesignationCommon common = new DesignationCommon();

                common.DesignationId = model.DesignationId;
                common.DesignationName = model.DesignationName;
                common.Remarks = model.Remarks;               
                common.User = model.User;
                var response = buss.New(common);
                //  StaticData.SetMessageInSession(response);
                if (response.ErrorCode == 0)
                {
                    ModelState.AddModelError("", response.Message);
                    return View(model);
                }
                return RedirectToAction("Index", "Designation");
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
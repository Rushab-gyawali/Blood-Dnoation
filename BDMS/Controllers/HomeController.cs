using BDMS.Business.Business.Staff;
using BDMS.Business.Business.User;
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
    public class HomeController : Controller
    {
        IUserBusiness buss;
        IStaffBusiness business;
        public HomeController(IUserBusiness _buss, IStaffBusiness _business)
        {
            buss = _buss;
            business = _business;
        }
        public ActionResult Index(string log = null)
        {
            //UserMonitor.GetInstance().RemoveUser(StaticData.GetUser());
            //WebSecurity.Logout();
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            switch (log)
            {
                case "UnAuthorization":
                    ViewData["msg"] = "Sorry,Your Account is Currently blocked due to too many attempt of UnAuthorization";
                    break;
                case "Error":
                    ViewData["msg"] = "Sorry,Your Account is Currently blocked due to too many attempt of Errors";
                    break;
                default:
                    break;
            }

            return View();
        }
        public ActionResult DashBoard()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(LoginModel model)
        {

            string ip = Request.ServerVariables["REMOTE_ADDR"]
                    , browser = Request.Browser.Browser + " Version :" + Request.Browser.Version;

            var login = new LoginCommon
            {
                UserName = model.UserName,
                Password = StaticData.Base64Encode(model.Password),
                Ip = ip,
                BrowserInfo = browser
            };
            var resp = buss.UserLogin(login);
            if (resp.Code == "0")
            {

                Session["UserName"] = model.UserName;
                Session["sysDate"] = StaticData.DBToFrontDate(System.DateTime.Now.ToShortDateString());
                return RedirectToAction("DashBoard", "Home");
            }
            ViewData["msg"] = resp.Msg; //"The user name or password provided is incorrect.";
            return View(model);
        }
    }
}
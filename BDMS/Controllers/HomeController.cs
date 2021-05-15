using BDMS.Models;
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

        public ActionResult Index(UserModel model)
        {
            return View(model);
        }
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}
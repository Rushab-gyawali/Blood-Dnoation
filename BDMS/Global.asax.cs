using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BDMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Bootstrapper.Initialise();
        }
        protected void Application_Error()
        {
            HttpException err = Server.GetLastError() as HttpException;
            var exc = Server.GetLastError();
            System.Diagnostics.Debug.WriteLine(exc);
            if (err != null)
            {
                var page = HttpContext.Current.Request.Url.ToString();
                //StaticData.LogError(err, page);
            }

            Server.ClearError();
        }
    }
}

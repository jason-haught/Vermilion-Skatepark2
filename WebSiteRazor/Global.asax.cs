using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

using VermillionSkatePark.Models;

namespace VermillionSkatePark
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AppSettings.Instance.ApplicationTitle = WebConfigurationManager.AppSettings["App_Title"];
            AppSettings.Instance.ApplicationFooter = WebConfigurationManager.AppSettings["App_Footer"];
        }
    }
}

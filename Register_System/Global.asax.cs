using Register_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Register_System.Models.Interface_Logic_;
using System.Web.Services.Description;
using Register_System.App_Start;

namespace Register_System
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutofacConfig.ConfigureContainer();

        }
    }
}

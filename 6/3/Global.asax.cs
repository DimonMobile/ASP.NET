using _3.App_Code;
using Ninject;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // dependency injection
            var kernel = new StandardKernel(new NIConfig());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

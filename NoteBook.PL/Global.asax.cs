using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using NoteBook.Common.ResolverNinJect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NoteBook.PL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            NinjectModule registration = new MyNinject();
            var kernel = new StandardKernel(registration);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

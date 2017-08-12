using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using GeekHunters.GRS.BusinessModels;
using GeekHunters.GRS.Services;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace GeekHunters.GRS.Web
{
    public class Global : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.ConfigAutofac();
        }

        private void ConfigAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(BaseModel).Assembly);
            builder.RegisterAssemblyTypes(typeof(BaseService).Assembly).AsImplementedInterfaces().SingleInstance();

            builder.RegisterControllers(typeof(Global).Assembly);
            builder.RegisterApiControllers(typeof(Global).Assembly);

            builder.RegisterModule<AutofacWebTypesModule>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
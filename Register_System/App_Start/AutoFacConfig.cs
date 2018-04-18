using Autofac;
using Autofac.Integration.Mvc;
using Register_System.Models.Class_Logic_;
using Register_System.Models.Interface_Logic_;
using System.Web.Mvc;

namespace Register_System.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our Data dependencies
            builder.RegisterType<UserLogic>().As<IUserLogic>().InstancePerRequest();
            builder.RegisterType<SessionLogic>().As<ISessionLogic>().InstancePerRequest();

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


    }
}
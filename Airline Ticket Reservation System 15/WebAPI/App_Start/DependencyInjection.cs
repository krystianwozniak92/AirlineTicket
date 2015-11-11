using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebAPI.Repository;

namespace WebAPI
{
    public static class DependencyInjection
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Get HttpConfiguration
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register your interface implementations.
            RegisterTypes(builder);

            // OPTIONAL: register Autofac Filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<FlightRepository>().AsImplementedInterfaces();
        }
    }
}
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebApplication1.Filters;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new MessageHandler());
            config.Filters.Add(new SnailsAuthorizationFilterAttribute());
            config.Filters.Add(new NotFoundExceptionAttribute());
            config.Filters.Add(new DefaultExceptionAttribute());

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<SnailsRepository>().AsSelf().SingleInstance();
            builder.RegisterType<RacesRepository>().AsSelf().SingleInstance();

            var container = builder.Build();

            var repo = container.Resolve<SnailsRepository>();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.EnsureInitialized();
        }
    }
}

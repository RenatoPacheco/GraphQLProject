using SimpleInjector;
using System.Web.Http;
using CommonServiceLocator;
using GraphQLProject.API.Source;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using GraphQLProject.API.App_Start.IdCCustom;
using GraphQLProject.API.Source.Resources.DroidResource;
using GraphQLProject.API.Source.Resources.JediResource;

namespace GraphQLProject.API
{
    public class IdCConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(config);

            container.Register<DroidSchema>(Lifestyle.Scoped);
            container.Register<JediSchema>(Lifestyle.Scoped);

            container.Register<ServiceProvider>(Lifestyle.Scoped);

            // Adapter for Service Locator
            var adapter = new ServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => adapter);

            // Verify 
            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            config.MessageHandlers.Add(new DelegatingHandlerProxy<InicializeHandler>(container));
        }
    }
}
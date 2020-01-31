using SimpleInjector;
using System.Web.Http;
using CommonServiceLocator;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using GraphQLProject.App_Start.IdCCustom;

namespace GraphQLProject
{
    public class IdCConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(config);

            // Verify 
            container.Verify();

            // Adapter for Service Locator
            var adapter = new ServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => adapter);

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            config.MessageHandlers.Add(new DelegatingHandlerProxy<InicializeHandler>(container));
        }
    }
}
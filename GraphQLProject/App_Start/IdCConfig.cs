using SimpleInjector;
using System.Web.Http;
using CommonServiceLocator;
using GraphQLProject.Source;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using GraphQLProject.App_Start.IdCCustom;
using GraphQLProject.Source.Resources.DroidResource;
using GraphQLProject.Source.Resources.JediResource;
using GraphQLProject.Source.Resources;

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
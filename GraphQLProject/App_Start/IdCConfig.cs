using SimpleInjector;
using System.Web.Http;
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

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            config.MessageHandlers.Add(new DelegatingHandlerProxy<InicializeHandler>(container));
        }
    }
}
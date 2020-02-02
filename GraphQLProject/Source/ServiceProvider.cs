using GraphQL;
using System;
using CommonServiceLocator;

namespace GraphQLProject.Source
{
    public class ServiceProvider : IDependencyResolver
    {
        public T Resolve<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }

        public object Resolve(Type type)
        {
            return ServiceLocator.Current.GetInstance(type);
        }
    }
}
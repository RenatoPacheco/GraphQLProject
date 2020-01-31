using GraphQL;
using GraphQL.Types;

namespace GraphQLProject.Source
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(IDependencyResolver provider)
       : base(provider)
        {
            Query = provider.Resolve<StarWarsQuery>();
            Mutation = provider.Resolve<StarWarsMutation>();
        }
    }
}
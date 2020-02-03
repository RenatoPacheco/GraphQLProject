using GraphQL.Types;

namespace GraphQLProject.API.Source.Resources.DroidResource
{
    public class DroidSchema : Schema
    {
        public DroidSchema(ServiceProvider provider)
       : base(provider)
        {
            Query = provider.Resolve<DroidQuery>();
            Mutation = provider.Resolve<DroidMutation>();
        }
    }
}
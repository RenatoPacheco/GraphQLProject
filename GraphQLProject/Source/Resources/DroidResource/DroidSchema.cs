using GraphQL.Types;

namespace GraphQLProject.Source.Resources.DroidResource
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
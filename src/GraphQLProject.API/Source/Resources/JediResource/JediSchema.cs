using GraphQL.Types;

namespace GraphQLProject.API.Source.Resources.JediResource
{
    public class JediSchema : Schema
    {
        public JediSchema(ServiceProvider provider)
       : base(provider)
        {
            Query = provider.Resolve<JediQuery>();
            Mutation = provider.Resolve<JediMutation>();
        }
    }
}
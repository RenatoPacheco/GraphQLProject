using GraphQL.Types;
using GraphQLProject.Source.Models;

namespace GraphQLProject.Source.Resources.DroidResource
{
    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType()
        {
            Field(x => x.Id).Name("id").Description("The Id of the Droid.");
            Field(x => x.Name).Name("name").Description("The name of the Droid.");
        }
    }
}
using GraphQL.Types;
using GraphQLProject.API.Source.Commands;

namespace GraphQLProject.API.Source.Resources.DroidResource.InputTypes
{
    public class ListInputType : InputObjectGraphType<FindDroidCmd>
    {
        public ListInputType()
        {
            Field(d => d.Droid, nullable: true)
                .Name("id")
                .Description("List ids droids");
            
            Field(d => d.Keyworks, nullable: true)
                .Name("keyworks")
                .Description("Text droids");
        }
    }
}
using GraphQL.Types;
using GraphQLProject.Source.Commands;

namespace GraphQLProject.Source.Resources.JediResource.InputTypes
{
    public class ListInputType : InputObjectGraphType<FindediCmd>
    {
        public ListInputType()
        {
            Field(d => d.Jedi, nullable: true)
                .Name("jedi")
                .Description("List ids jedis");
            
            Field(d => d.Keyworks, nullable: true)
                .Name("keyworks")
                .Description("Text jedis");
        }
    }
}
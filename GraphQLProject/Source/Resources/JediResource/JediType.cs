using GraphQL.Types;
using GraphQLProject.Source.Models;

namespace GraphQLProject.Source.Resources.JediResource
{
    public class JediType : ObjectGraphType<Jedi>
    {
        public JediType()
        {
            Field(d => d.Id).Name("id").Description("Id to person");
            Field(d => d.Name, nullable: true).Name("name").Description("Name to person");
            Field(d => d.Side, nullable: true).Name("side").Description("Side to person");
        }
    }
}
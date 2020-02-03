using GraphQL.Types;
using GraphQLProject.API.Source.Models;

namespace GraphQLProject.API.Source.Resources.JediResource.ObjectTypes
{
    public class JediType : ObjectGraphType<Jedi>
    {
        public JediType()
        {
            Field(d => d.Id)
                .Name("id")
                .Description("Id to person");

            Field(d => d.Name, nullable: true)
                .Name("name")
                .Description("Name to person");
            
            Field(d => d.Side, nullable: true)
                .Name("side")
                .Description("Side to person");
        }
    }
}
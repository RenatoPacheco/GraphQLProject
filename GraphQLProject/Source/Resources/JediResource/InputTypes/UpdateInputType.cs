using GraphQL.Types;
using GraphQLProject.Source.Commands;

namespace GraphQLProject.Source.Resources.JediResource.InputTypes
{
    public class UpdateInputType : InputObjectGraphType<UpdateJediCmd>
    {
        public UpdateInputType()
        {
            Field(d => d.Id, nullable: false)
                .Name("id")
                .Description("Set id person");

            Field(d => d.Name, nullable: true)
                .Name("name")
                .Description("Set name person");

            Field(d => d.Side, nullable: true)
                .Name("side")
                .Description("Set side person");
        }
    }
}
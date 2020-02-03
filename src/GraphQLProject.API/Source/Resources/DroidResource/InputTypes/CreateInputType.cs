using GraphQL.Types;
using GraphQLProject.API.Source.Commands;

namespace GraphQLProject.API.Source.Resources.DroidResource.InputTypes
{
    public class CreateInputType : InputObjectGraphType<CreateDroidCmd>
    {
        public CreateInputType()
        {
            Name = "CreateInput";

            Field(d => d.Name, nullable: false)
                .Name("name")
                .Description("Set name person");
        }
    }
}
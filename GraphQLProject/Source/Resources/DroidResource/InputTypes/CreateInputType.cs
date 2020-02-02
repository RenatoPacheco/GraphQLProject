using GraphQL.Types;
using GraphQLProject.Source.Commands;

namespace GraphQLProject.Source.Resources.DroidResource.InputTypes
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
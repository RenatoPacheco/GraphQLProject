using GraphQL.Types;
using GraphQLProject.API.Source.Commands;

namespace GraphQLProject.API.Source.Resources.DroidResource.InputTypes
{
    public class UpdateInputType : InputObjectGraphType<UpdateDroidCmd>
    {
        public UpdateInputType()
        {
            Name = "UpdateInput";

            Field(d => d.Id, nullable: false)
                .Name("id")
                .Description("Set id person");

            Field(d => d.Name, nullable: true)
                .Name("name")
                .Description("Set name person");
        }
    }
}
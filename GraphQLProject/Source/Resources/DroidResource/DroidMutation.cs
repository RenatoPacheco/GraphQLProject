using GraphQL.Types;
using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Services;
using GraphQLProject.Source.Resources.DroidResource.InputTypes;
using GraphQLProject.Source.Resources.DroidResource.ObjectTypes;

namespace GraphQLProject.Source.Resources.DroidResource
{
    public class DroidMutation : ObjectGraphType
    {
        public DroidMutation(DroidService service)
        {
            Field<DroidType>(
                "createDroid", "Creating new droid",
                arguments: new QueryArguments() {
                    new QueryArgument<CreateInputType> {
                        Name = "command",
                        Description = "Command to create droids",
                        DefaultValue = new CreateDroidCmd(),
                    }
                },
                resolve: context => {
                    var userConterxt = context.UserContext as DroidUserContext;
                    var command = context.GetArgument<CreateDroidCmd>("command");

                    return service.Create(command);
                }
            );

            Field<DroidType>(
                "updateDroid", "Update droid by id",
                arguments: new QueryArguments() {
                    new QueryArgument<UpdateInputType> {
                        Name = "command",
                        Description = "Command to update droids",
                        DefaultValue = new UpdateDroidCmd(),
                    }
                },
                resolve: context => {
                    var userConterxt = context.UserContext as DroidUserContext;
                    var command = context.GetArgument<UpdateDroidCmd>("command");

                    return service.Update(command);
                }
            );
        }
    }
}
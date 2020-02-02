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
                "createDroid", "Get one droid by id",
                arguments: new QueryArguments() {
                    new QueryArgument<CreateInputType> {
                        Name = "command",
                        Description = "Command to list jedis",
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
                "updateDroid", "Get one droid by id",
                arguments: new QueryArguments() {
                    new QueryArgument<CreateInputType> {
                        Name = "command",
                        Description = "Command to list jedis",
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
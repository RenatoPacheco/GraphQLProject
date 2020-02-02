using GraphQL.Types;
using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Services;
using GraphQLProject.Source.Resources.JediResource.InputTypes;
using GraphQLProject.Source.Resources.JediResource.ObjectTypes;

namespace GraphQLProject.Source.Resources.JediResource
{
    public class JediMutation : ObjectGraphType
    {
        public JediMutation(JediService service)
        {
            Field<JediType>(
                "createJedi", "Get one droid by id",
                arguments: new QueryArguments() {
                    new QueryArgument<CreateInputType> {
                        Name = "command",
                        Description = "Command to list jedis",
                        DefaultValue = new CreateJediCmd(),
                    }
                },
                resolve: context => {
                    var userConterxt = context.UserContext as JediUserContext;
                    var command = context.GetArgument<CreateJediCmd>("command");

                    return service.Create(command);
                }
            );

            Field<JediType>(
                "updateJedi", "Get one droid by id",
                arguments: new QueryArguments() {
                    new QueryArgument<CreateInputType> {
                        Name = "command",
                        Description = "Command to list jedis",
                        DefaultValue = new UpdateJediCmd(),
                    }
                },
                resolve: context => {
                    var userConterxt = context.UserContext as JediUserContext;
                    var command = context.GetArgument<UpdateJediCmd>("command");

                    return service.Update(command);
                }
            );
        }
    }
}
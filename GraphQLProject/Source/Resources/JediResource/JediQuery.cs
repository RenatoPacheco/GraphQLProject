using GraphQL.Types;
using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Services;
using GraphQLProject.Source.Resources.DroidResource.InputTypes;
using GraphQLProject.Source.Resources.JediResource.ObjectTypes;

namespace GraphQLProject.Source.Resources.JediResource
{
    public class JediQuery : ObjectGraphType
    {
        public JediQuery(JediService service)
        {
            Field<JediType>(
                "jedi", "Get one droid by id",
                arguments: new QueryArguments() {
                    new QueryArgument<IntGraphType> {
                        Name = "id",
                        Description = "Command to list jedis"
                    }
                },
                resolve: context => {
                    var userConterxt = context.UserContext as JediUserContext;
                    var id = context.GetArgument<int>("id");

                    return service.Get(id);
                }
            );

            Field<ListGraphType<JediType>>(
              "jedis", "Get lists jedi by param",
              arguments: new QueryArguments() {
                new QueryArgument<ListInputType> {
                    Name = "param",
                    DefaultValue = new FindediCmd(),
                    Description = "Command to list jedis"
                },
                new QueryArgument<ListGraphType<IntGraphType>> {
                    Name = "id",
                    Description = "Command to list jedis"
                },
                new QueryArgument<StringGraphType> {
                    Name = "keyworks",
                    Description = "Command to list jedis"
                }
              },
              resolve: context => {
                  var userConterxt = context.UserContext as JediUserContext;
                  var param = context.GetArgument<FindediCmd>("param");
                  var keyworks = context.GetArgument<string>("keyworks");
                  var jedi = context.GetArgument<int[]>("id");

                  param.Keyworks = keyworks ?? param.Keyworks;
                  param.Jedi = jedi ?? param.Jedi;

                  return service.Find(param);
              }
            );
        }
    }
}
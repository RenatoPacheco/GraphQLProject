using GraphQL.Types;
using GraphQLProject.API.Source.Commands;
using GraphQLProject.API.Source.Services;
using GraphQLProject.API.Source.Resources.DroidResource.InputTypes;
using GraphQLProject.API.Source.Resources.DroidResource.ObjectTypes;

namespace GraphQLProject.API.Source.Resources.DroidResource
{
    public class DroidQuery : ObjectGraphType
    {
        public DroidQuery(DroidService service)
        {

            Field<DroidType>(
                "droid", "Get one droid by id",
                arguments: new QueryArguments() {
                    new QueryArgument<IntGraphType> {
                        Name = "id",
                        Description = "Command to list droids"
                    }
                },
                resolve: context => {
                    var userConterxt = context.UserContext as DroidUserContext;
                    var id = context.GetArgument<int>("id");

                    return service.Get(id);
                }
            );

            Field<ListGraphType<DroidType>>(
                "droids", "Get lists droid by param",
                arguments: new QueryArguments() {
                    new QueryArgument<ListInputType> {
                        Name = "param",
                        DefaultValue = new FindDroidCmd(),
                        Description = "Command to list doids"
                    },
                    new QueryArgument<ListGraphType<IntGraphType>> {
                        Name = "id",
                        Description = "Command to list doids"
                    },
                    new QueryArgument<StringGraphType> {
                        Name = "keyworks",
                        Description = "Command to list doids"
                    }
                },
                resolve: context => {
                    var userConterxt = context.UserContext as DroidUserContext;
                    var param = context.GetArgument<FindDroidCmd>("param");
                    var keyworks = context.GetArgument<string>("keyworks");
                    var doid = context.GetArgument<int[]>("id");

                    param.Keyworks = keyworks ?? param.Keyworks;
                    param.Droid = doid ?? param.Droid;

                    return service.Find(param);
                }
            );
        }
    }
}
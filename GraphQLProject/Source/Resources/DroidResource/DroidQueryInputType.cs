using CommonServiceLocator;
using GraphQL.Types;
using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Services;

namespace GraphQLProject.Source.Resources.DroidResource
{
    public class DroidQueryInputType : InputObjectGraphType<QueryDroidCmd>
    {
        public DroidQueryInputType()
        {
            Name = "queryDroid";
            Field(d => d.Droid, nullable: true).Name("id").Description("List ids droids");
            Field(d => d.Keyworks, nullable: true).Name("keyworks").Description("Text droids");
        }
        public static QueryArguments Arguments => new QueryArguments()
        {
            new QueryArgument<DroidQueryInputType>
            {
                Name = "param",
                DefaultValue = new QueryDroidCmd(),
                Description = "Command to list doids"
            },
            new QueryArgument<ListGraphType<IntGraphType>>
            {
                Name = "id",
                Description = "Command to list doids"
            },
            new QueryArgument<StringGraphType>
            {
                Name = "keyworks",
                Description = "Command to list doids"
            }
        };

        public static object Resove(ResolveFieldContext<object> context)
        {
            var service = ServiceLocator.Current.GetInstance<DroidService>();
            var userConterxt = context.UserContext as StarWarsUserContext;
            var param = context.GetArgument<QueryDroidCmd>("param");
            var keyworks = context.GetArgument<string>("keyworks");
            var doid = context.GetArgument<int[]>("id");

            param.Keyworks = keyworks ?? param.Keyworks;
            param.Droid = doid ?? param.Droid;

            return service.Query(param);
        }
    }
}
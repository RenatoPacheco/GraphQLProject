using CommonServiceLocator;
using GraphQL.Types;
using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Services;

namespace GraphQLProject.Source.Resources.DroidResource.InputTypes
{
    public class ListInputType : InputObjectGraphType<FindDroidCmd>
    {
        public ListInputType()
        {
            Name = "queryDroid";
            Field(d => d.Droid, nullable: true).Name("id").Description("List ids droids");
            Field(d => d.Keyworks, nullable: true).Name("keyworks").Description("Text droids");
        }
        public static QueryArguments Arguments => new QueryArguments()
        {
            new QueryArgument<ListInputType>
            {
                Name = "param",
                DefaultValue = new FindDroidCmd(),
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

        public static object Resove<T>(ResolveFieldContext<T> context)
        {
            var service = ServiceLocator.Current.GetInstance<DroidService>();
            var userConterxt = context.UserContext as DroidUserContext;
            var param = context.GetArgument<FindDroidCmd>("param");
            var keyworks = context.GetArgument<string>("keyworks");
            var doid = context.GetArgument<int[]>("id");

            param.Keyworks = keyworks ?? param.Keyworks;
            param.Droid = doid ?? param.Droid;

            return service.Find(param);
        }
    }
}
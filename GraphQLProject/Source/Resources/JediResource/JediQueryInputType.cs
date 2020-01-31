using CommonServiceLocator;
using GraphQL.Types;
using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Services;

namespace GraphQLProject.Source.Resources.JediResource
{
    public class JediQueryInputType : InputObjectGraphType<QueryJediCmd>
    {
        public JediQueryInputType()
        {
            Name = "queryJedi";
            Field(d => d.Jedi, nullable: true).Name("jedi").Description("List ids jedis");
            Field(d => d.Keyworks, nullable: true).Name("keyworks").Description("Text jedis");
        }

        public static QueryArguments Arguments => new QueryArguments() 
        {
            new QueryArgument<JediQueryInputType>
            {
                Name = "param",
                DefaultValue = new QueryJediCmd(),
                Description = "Command to list jedis"
            },
            new QueryArgument<ListGraphType<IntGraphType>>
            {
                Name = "id",
                Description = "Command to list jedis"
            },
            new QueryArgument<StringGraphType>
            {
                Name = "keyworks",
                Description = "Command to list jedis"
            }
        };

        public static object Resove<T>(ResolveFieldContext<T> context)
        {
            var service = ServiceLocator.Current.GetInstance<JediService>();
            var userConterxt = context.UserContext as StarWarsUserContext;
            var param = context.GetArgument<QueryJediCmd>("param");
            var keyworks = context.GetArgument<string>("keyworks");
            var jedi = context.GetArgument<int[]>("id");

            param.Keyworks = keyworks ?? param.Keyworks;
            param.Jedi = jedi ?? param.Jedi;

            return service.Query(param);
        }
    }
}
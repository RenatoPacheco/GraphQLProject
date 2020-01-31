using GraphQL.Types;
using System.Linq;
using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Services;
using CommonServiceLocator;

namespace GraphQLProject.Source.Resources.JediResource
{
    public class JediGetInputType
    {
        public static QueryArguments Arguments => new QueryArguments() 
        {
            new QueryArgument<IntGraphType>
            {
                Name = "id",
                Description = "Command to list jedis"
            }
        };

        public static object Resove(ResolveFieldContext<object> context)
        {
            var service = ServiceLocator.Current.GetInstance<JediService>();
            var userConterxt = context.UserContext as StarWarsUserContext;
            var id = context.GetArgument<int>("id");

            return service.Query(new QueryJediCmd() { Jedi = new int[] { id }}).FirstOrDefault();
        }
    }
}
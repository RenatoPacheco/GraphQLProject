using GraphQL.Types;
using System.Linq;
using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Services;
using CommonServiceLocator;

namespace GraphQLProject.Source.Resources.DroidResource
{
    public class DroidGetInputType
    {
        public static QueryArguments Arguments => new QueryArguments() 
        {
            new QueryArgument<IntGraphType>
            {
                Name = "id",
                Description = "Command to list droids"
            }
        };

        public static object Resove(ResolveFieldContext<object> context)
        {
            var userConterxt = context.UserContext as StarWarsUserContext;
            var id = context.GetArgument<int>("id");

            var service = ServiceLocator.Current.GetInstance<DroidService>();
            return service.Query(new QueryDroidCmd() { Droid = new int[] { id }}).FirstOrDefault();
        }
    }
}
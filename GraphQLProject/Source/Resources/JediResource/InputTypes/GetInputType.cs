using GraphQL.Types;
using System.Linq;
using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Services;
using CommonServiceLocator;

namespace GraphQLProject.Source.Resources.JediResource.InputTypes
{
    public class GetInputType
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
            var userConterxt = context.UserContext as JediUserContext;
            var id = context.GetArgument<int>("id");

            return service.Get(id);
        }
    }
}
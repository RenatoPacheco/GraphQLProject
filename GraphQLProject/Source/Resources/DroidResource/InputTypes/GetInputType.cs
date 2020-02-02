using GraphQL.Types;
using GraphQLProject.Source.Services;
using CommonServiceLocator;

namespace GraphQLProject.Source.Resources.DroidResource.InputTypes
{
    public class GetInputType
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
            var userConterxt = context.UserContext as DroidUserContext;
            var id = context.GetArgument<int>("id");

            var service = ServiceLocator.Current.GetInstance<DroidService>();
            return service.Get(id);
        }
    }
}
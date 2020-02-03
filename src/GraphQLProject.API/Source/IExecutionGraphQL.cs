using GraphQL;
using System.Threading.Tasks;

namespace GraphQLProject.API.Source
{
    interface IExecutionGraphQL
    {
        Task ExecuteAsync(IDataGraphQL data);

        bool AnyError();

        ExecutionResult Result();
    }
}
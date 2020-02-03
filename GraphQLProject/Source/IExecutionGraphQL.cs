using GraphQL;
using GraphQLProject.Models;
using System.Threading.Tasks;

namespace GraphQLProject.Source
{
    interface IExecutionGraphQL
    {
        Task ExecuteAsync(DataGraphQL data);

        bool AnyError();

        ExecutionResult Result();
    }
}
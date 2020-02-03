using GraphQL;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQLProject.Models;
using GraphQLProject.Source.Resources.DroidResource;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLProject.Source
{
    public class DroidGraphQL : IExecutionGraphQL
    {
        public DroidGraphQL(DroidSchema schema)
        {
            _schema = schema;
        }

        private Schema _schema;
        private bool _anyError = false;
        private ExecutionResult _result;

        public bool AnyError()
        {
            return _anyError;
        }

        public async Task ExecuteAsync(DataGraphQL data)
        {
            var start = DateTime.UtcNow;
            var metrics = data?.EnableMetrics ?? false;

            _anyError = false;
            _result = await new DocumentExecuter().ExecuteAsync(_ => {
                _.Schema = _schema;
                _.Query = data?.Query;
                _.OperationName = data?.OperationName;
                _.Inputs = data?.Variables?.ToInputs();
                _.UserContext = new DroidUserContext();
                if (metrics)
                {
                    _.EnableMetrics = true;
                    _.FieldMiddleware.Use<InstrumentFieldsMiddleware>();
                }
            });

            if (metrics)
            {
                _result.EnrichWithApolloTracing(start);
            }

            _anyError = _result.Errors?.Any() ?? false;
        }

        public ExecutionResult Result()
        {
            return _result;
        }
    }
}
using GraphQL;
using System.Net.Http;
using System.Web.Http;
using GraphQL.Types;
using GraphQLProject.Models;
using GraphQLProject.Source.Resources.JediResource;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Instrumentation;
using System;

namespace GraphQLProject.Controllers
{
    [RoutePrefix("api/jedi/graphql")]
    public class JediController : Common.CommonApiController
    {
        public JediController(JediSchema schema)
        {
            _schema = schema;
        }

        private readonly Schema _schema;

        [HttpGet, HttpPost, Route]
        public async Task<HttpResponseMessage> Graphql(DataGraphQL data)
        {
            var start = DateTime.UtcNow;
            var metrics = data?.EnableMetrics ?? false;

            var result = await new DocumentExecuter().ExecuteAsync(_ => {
                _.Schema = _schema;
                _.Query = data?.Query;
                _.OperationName = data?.OperationName;
                _.Inputs = data?.Variables?.ToInputs();
                _.UserContext = new JediUserContext();
                if(metrics)
                {
                    _.EnableMetrics = true;
                    _.FieldMiddleware.Use<InstrumentFieldsMiddleware>();
                }
            });

            if(metrics)
            {
                result.EnrichWithApolloTracing(start);
            }

            var status = result.Errors?.Any() ?? false 
                ? HttpStatusCode.BadRequest : HttpStatusCode.OK;

            return Request.CreateResponse(status, result);
        }
    }
}

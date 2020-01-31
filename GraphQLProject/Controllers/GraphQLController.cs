using GraphQL;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;
using GraphQL.Types;
using GraphQLProject.Models;
using GraphQLProject.Source;

namespace GraphQLProject.Controllers
{
    [RoutePrefix("api/graphql")]
    public class GraphQLController : Common.CommonApiController
    {
        public GraphQLController(StarWarsSchema schema)
        {
            _schema = schema;
        }

        private readonly Schema _schema;

        [HttpGet, HttpPost]
        public HttpResponseMessage Graphql(DataGraphQL data)
        {
            var json = _schema.Execute(_ =>
            {
                _.Query = data.Query;
                _.Inputs = JsonConvert.SerializeObject(data?.Variables ?? new { }).ToInputs();
                _.UserContext = new StarWarsUserContext();
            });

            return ResponseJsonString(json);
        }
    }
}

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
        public GraphQLController(StarWarsQuery query)
        {
            _schema = new Schema {
                Query = query
            };
        }

        private readonly Schema _schema;

        public HttpResponseMessage Getd(DataGraphQL data)
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

using GraphQL;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;
using GraphQL.Types;
using GraphQLProject.Models;
using GraphQLProject.Source.Resources.DroidResource;
using GraphQLProject.Source.Resources.JediResource;

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
        public HttpResponseMessage Graphql(DataGraphQL data)
        {
            var json = _schema.Execute(_ =>
            {
                _.Query = data.Query;
                _.Inputs = JsonConvert.SerializeObject(data?.Variables ?? new { }).ToInputs();
                _.UserContext = new DroidUserContext();
            });

            return ResponseJsonString(json);
        }
    }
}

using GraphQL;
using GraphQL.Types;
using GraphQLProject.Models;
using GraphQLProject.Source;
using GraphQLProject.Source.DroidResource;
using GraphQLProject.Source.JediResource;
using GraphQLProject.Source.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;

namespace GraphQLProject.Controllers
{
    [RoutePrefix("api/graphql")]
    public class GraphQLController : Common.CommonApiController
    {
        [Route("droid")]
        public HttpResponseMessage GetDroid(DataGraphQL data)
        {
            var service = new DroidService();

            Schema Schema = new Schema {
                Query = new DroidQuery(service)
            };

            var json = Schema.Execute(_ =>
            {
                _.Query = data.Query;
                _.Inputs = JsonConvert.SerializeObject(data?.Variables ?? new { }).ToInputs();
                _.UserContext = new GraphQLUserContext();
            });

            return ResponseJsonString(json);
        }

        [Route("jedi")]
        public HttpResponseMessage GetJedi(DataGraphQL data)
        {
            var service = new JediService();

            Schema Schema = new Schema
            {
                Query = new JediQuery(service)
            };

            var json = Schema.Execute(_ =>
            {
                _.Query = data.Query;
                _.Inputs = JsonConvert.SerializeObject(data?.Variables ?? new { }).ToInputs();
                _.UserContext = new GraphQLUserContext();
            });

            return ResponseJsonString(json);
        }
    }
}

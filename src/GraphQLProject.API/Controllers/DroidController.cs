using System.Net.Http;
using System.Web.Http;
using GraphQLProject.API.Models;
using System.Threading.Tasks;
using System.Net;
using GraphQLProject.API.Source;
using GraphQLProject.API.Source.Resources.DroidResource;

namespace GraphQLProject.API.Controllers
{
    [RoutePrefix("api/droid/graphql")]
    public class DroidController : Common.CommonApiController
    {
        public DroidController(DroidSchema schema)
        {
            _execution = new DroidGraphQL(schema);
        }

        private readonly DroidGraphQL _execution;

        [HttpGet, HttpPost, Route]
        public async Task<HttpResponseMessage> Graphql(DataGraphQL data)
        {
            await _execution.ExecuteAsync(data);

            var status = _execution.AnyError()
                ? HttpStatusCode.BadRequest : HttpStatusCode.OK;

            return Request.CreateResponse(status, _execution.Result());
        }
    }
}

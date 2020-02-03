using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace GraphQLProject.API.Controllers.Common
{
    public class CommonApiController : ApiController
    {
        public HttpResponseMessage ResponseJsonString(string value, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var response = this.Request.CreateResponse(statusCode);
                response.Content = new StringContent(value, Encoding.UTF8, "application/json");
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage ResponseJson(object value, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (value !=null)
            {
                return Request.CreateResponse(statusCode, value);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
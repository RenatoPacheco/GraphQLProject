﻿using System.Net.Http;
using System.Web.Http;
using GraphQLProject.Models;
using System.Threading.Tasks;
using System.Net;
using GraphQLProject.Source;
using GraphQLProject.Source.Resources.JediResource;

namespace GraphQLProject.Controllers
{
    [RoutePrefix("api/jedi/graphql")]
    public class JediController : Common.CommonApiController
    {
        public JediController(JediSchema schema)
        {
            _execution = new JediGraphQL(schema);
        }

        private readonly JediGraphQL _execution;

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

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLProject.App_Start.IdCCustom
{
    public class InicializeHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}
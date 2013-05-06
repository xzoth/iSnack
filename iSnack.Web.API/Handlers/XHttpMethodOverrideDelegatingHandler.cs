using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace iSnack.Web.API.Handlers
{
    /// <summary>
    /// HTTP Method Override Handler
    /// </summary>
    public class XHttpMethodOverrideDelegatingHandler : DelegatingHandler
    {
        static readonly string[] httpMethods = { "PUT", "DELETE" };
        static readonly string httpMethodOverrideHeader = "X-HTTP-Method-Override";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Post && request.Headers.Contains(httpMethodOverrideHeader))
            {
                var httpMethod = request.Headers.GetValues(httpMethodOverrideHeader).FirstOrDefault();
                if (httpMethods.Contains(httpMethod, StringComparer.InvariantCultureIgnoreCase))
                {
                    request.Method = new HttpMethod(httpMethod);
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
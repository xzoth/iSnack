using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace iSnack.Web.API.Handlers
{
    /// <summary>
    /// HTTP Strict Transport Security Handler
    /// </summary>
    public class HSTSHandler : DelegatingHandler
    {
        const string StrictTransportSecurity = "Strict-Transport-Security";
        const string STSHeaders = "max-age=16070400; includeSubDomains";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isHttps = String.Compare(request.RequestUri.Scheme, "HTTPS", StringComparison.CurrentCultureIgnoreCase) == 0;
            bool hasSTSHeader = request.Headers.Contains(StrictTransportSecurity);
            //bool isPreflightRequest = request.Method == HttpMethod.Options;
            if (!isHttps && !hasSTSHeader)
            {
                //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Headers.Add(StrictTransportSecurity, STSHeaders);

                TaskCompletionSource<HttpResponseMessage> tcs = new TaskCompletionSource<HttpResponseMessage>();
                tcs.SetResult(response);
                return tcs.Task;
            }
            else
            {
                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}
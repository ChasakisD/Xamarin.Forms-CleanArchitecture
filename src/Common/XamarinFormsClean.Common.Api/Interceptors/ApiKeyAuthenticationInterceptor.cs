using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using XamarinFormsClean.Environment;

namespace XamarinFormsClean.Common.Api.Interceptors
{
    public class ApiKeyAuthenticationInterceptor : DelegatingHandler
    {
        public ApiKeyAuthenticationInterceptor(HttpMessageHandler? innerHandler = null)
            : base(innerHandler ?? new HttpClientHandler()) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                var uriBuilder =  new UriBuilder(request.RequestUri);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["api_key"] = AppEnvironment.Default.ApiKey;
                uriBuilder.Query = query.ToString();
                
                request.RequestUri = uriBuilder.Uri;
                request.Headers.Authorization = null;
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
using System;
using System.Net.Http;
using System.Threading;
using HttpTracer;
using Newtonsoft.Json;
using Refit;
using XamarinFormsClean.Common.Api.Converters.Json;
using XamarinFormsClean.Common.Api.Interceptors;

namespace XamarinFormsClean.Common.Api
{
    public static class HttpSettings
    {
        private static readonly Lazy<RefitSettings> RefitSettingsLazy =
            new Lazy<RefitSettings>(GetRefitSettings,
                LazyThreadSafetyMode.PublicationOnly);

        public static RefitSettings Refit => RefitSettingsLazy.Value;

        private static RefitSettings GetRefitSettings()
        {
            var refitSettings = new RefitSettings
            {
                ContentSerializer = new JsonContentSerializer(new JsonSerializerSettings
                {
                    Converters =
                    {
                        new ApiDateTimeJsonConverter()
                    }
                })
            };

#if DEBUG
            refitSettings.HttpMessageHandlerFactory =
                () => new ApiKeyAuthenticationInterceptor(
                    new HttpTracerHandler(
                        HttpMessageParts.RequestBody
                        | HttpMessageParts.RequestHeaders
                        | HttpMessageParts.ResponseBody));
#else
            refitSettings.HttpMessageHandlerFactory =
                () => new ApiVersioningInterceptor();
#endif

            return refitSettings;
        }
    }
}

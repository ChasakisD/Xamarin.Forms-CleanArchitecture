using System;
using Newtonsoft.Json;
using XamarinFormsClean.Common.Data.Converters.Json;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Dto
{
    public class TokenValidationDto
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }
        
        [JsonProperty("request_token")]
        [JsonConverter(typeof(OptionJsonConverter<string>))]
        public Option<string> RequestToken { get; set; }
    }
}
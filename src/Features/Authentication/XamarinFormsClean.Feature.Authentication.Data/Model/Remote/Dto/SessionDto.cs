using Newtonsoft.Json;
using XamarinFormsClean.Common.Data.Converters.Json;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Dto
{
    public class SessionDto
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        
        [JsonProperty("session_id")]
        [JsonConverter(typeof(OptionJsonConverter<string>))]
        public Option<string> SessionId { get; set; }
    }
}
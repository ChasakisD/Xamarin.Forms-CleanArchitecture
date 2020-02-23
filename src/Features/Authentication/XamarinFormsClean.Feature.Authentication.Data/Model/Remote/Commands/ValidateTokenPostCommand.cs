using Newtonsoft.Json;
using XamarinFormsClean.Common.Data.Converters.Json;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Commands
{
    public class ValidateTokenPostCommand
    {
        [JsonProperty("username")]
        public string Username { get; }
        
        [JsonProperty("password")]
        public string Password { get; }
        
        [JsonProperty("request_token")]
        [JsonConverter(typeof(OptionJsonConverter<string>))]
        public Option<string> RequestToken { get; }
        
        public ValidateTokenPostCommand(string username, string password) =>
            (Username, Password) = (username, password);

        public ValidateTokenPostCommand(string username, string password, string requestToken)
            : this(username, password) =>
            RequestToken = requestToken;
    }
}
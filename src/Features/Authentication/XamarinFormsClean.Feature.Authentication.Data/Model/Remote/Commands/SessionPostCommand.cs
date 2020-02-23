using Newtonsoft.Json;

namespace XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Commands
{
    public class SessionPostCommand
    {
        [JsonProperty("request_token")]
        public string RequestToken { get; }

        public SessionPostCommand(string requestToken) =>
            RequestToken = requestToken;
    }
}
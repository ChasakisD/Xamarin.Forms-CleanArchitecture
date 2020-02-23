using System;
using Newtonsoft.Json;
using XamarinFormsClean.Common.Data.Converters.Json;
using XamarinFormsClean.Common.Data.Model.Local;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Feature.Authentication.Data.Model.Local
{
    public class SessionData : BaseData
    {
        [JsonConverter(typeof(OptionJsonConverter<string>))]
        public Option<string> SessionId { get; set; }
        
        [JsonConverter(typeof(OptionJsonConverter<string>))]
        public Option<string> RequestToken { get; set; }
        
        public DateTime ExpiresAt { get; set; }

        public SessionData()
        {
            ExpiresAt = MachineTime.Now;
        }
    }
}
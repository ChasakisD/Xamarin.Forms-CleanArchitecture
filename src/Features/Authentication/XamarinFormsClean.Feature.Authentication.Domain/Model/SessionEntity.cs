using System;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Feature.Authentication.Domain.Model
{
    public class SessionEntity
    {
        public Option<string> RequestToken { get; set; }

        public Option<string> SessionId { get; set; }

        public DateTime ExpiresAt { get; set; }

        public SessionEntity()
        {
            ExpiresAt = MachineTime.Now;
        }

        public SessionEntity(string sessionId, string requestToken) : this() =>
            (SessionId, RequestToken) = (sessionId, requestToken);
        
        public SessionEntity(Option<string> sessionId, Option<string> requestToken) : this() =>
            (SessionId, RequestToken) = (sessionId, requestToken);
    }
}
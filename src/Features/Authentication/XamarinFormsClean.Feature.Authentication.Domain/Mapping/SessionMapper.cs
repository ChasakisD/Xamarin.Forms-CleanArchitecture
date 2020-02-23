using XamarinFormsClean.Common.Domain.Mapping;
using XamarinFormsClean.Feature.Authentication.Data.Model.Local;
using XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Dto;
using XamarinFormsClean.Feature.Authentication.Domain.Mapping.Interface;
using XamarinFormsClean.Feature.Authentication.Domain.Model;

namespace XamarinFormsClean.Feature.Authentication.Domain.Mapping
{
    public class SessionMapper : BaseMapper, ISessionMapper
    {
        public SessionMapper() : base(SessionMapperConfig.Configure) { }

        public SessionData ToData(SessionEntity entity) =>
            Mapper.Map<SessionData>(entity);

        public SessionEntity ToDomain(SessionData data) =>
            Mapper.Map<SessionEntity>(data);
        
        public SessionEntity ToDomain(TokenValidationDto tokenValidation, SessionDto session) =>
            new SessionEntity(session.SessionId, tokenValidation.RequestToken);
    }
}
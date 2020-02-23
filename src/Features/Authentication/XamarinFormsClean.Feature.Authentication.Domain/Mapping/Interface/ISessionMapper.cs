using XamarinFormsClean.Feature.Authentication.Data.Model.Local;
using XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Dto;
using XamarinFormsClean.Feature.Authentication.Domain.Model;

namespace XamarinFormsClean.Feature.Authentication.Domain.Mapping.Interface
{
    public interface ISessionMapper
    {
        SessionData ToData(SessionEntity entity);
        
        SessionEntity ToDomain(SessionData data);
        SessionEntity ToDomain(TokenValidationDto tokenValidation, SessionDto session);
    }
}
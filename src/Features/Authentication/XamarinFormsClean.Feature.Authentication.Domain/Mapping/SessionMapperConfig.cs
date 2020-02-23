using AutoMapper;
using XamarinFormsClean.Feature.Authentication.Data.Model.Local;
using XamarinFormsClean.Feature.Authentication.Domain.Model;

namespace XamarinFormsClean.Feature.Authentication.Domain.Mapping
{
    public class SessionMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<SessionData, SessionEntity>()
                .ReverseMap();
        }
    }
}
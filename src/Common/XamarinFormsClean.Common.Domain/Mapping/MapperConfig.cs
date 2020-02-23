using System;
using AutoMapper;

namespace XamarinFormsClean.Common.Domain.Mapping
{
    public static class MapperConfig
    {
        public static MapperConfiguration Configure(
            Action<IMapperConfigurationExpression> configureAction)
        {
            var configuration = new MapperConfiguration(configureAction);
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
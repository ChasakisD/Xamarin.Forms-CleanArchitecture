using System;
using AutoMapper;

namespace XamarinFormsClean.Common.Domain.Mapping
{
    public static class MapperFactory
    {
        public static IMapper GetMapper(
            Action<IMapperConfigurationExpression> configureAction) =>
            new Mapper(MapperConfig.Configure(configureAction));
    }
}
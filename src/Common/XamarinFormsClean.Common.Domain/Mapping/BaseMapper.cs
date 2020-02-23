using System;
using AutoMapper;

namespace XamarinFormsClean.Common.Domain.Mapping
{
    public abstract class BaseMapper
    {
        protected IMapper Mapper { get; }

        protected BaseMapper(Action<IMapperConfigurationExpression> configureAction)
        {
            Mapper = MapperFactory.GetMapper(configureAction);
        }
    }
}
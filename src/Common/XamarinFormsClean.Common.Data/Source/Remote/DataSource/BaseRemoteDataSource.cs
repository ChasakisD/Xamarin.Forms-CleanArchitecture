using XamarinFormsClean.Common.Data.Source.Remote.Api.Interface;
using XamarinFormsClean.Common.Data.Source.Remote.DataSource.Interface;

namespace XamarinFormsClean.Common.Data.Source.Remote.DataSource
{
    public abstract class BaseRemoteDataSource<TApi> : IRemoteDataSource<TApi> where TApi : IApi
    {
        protected TApi Api { get; }

        protected BaseRemoteDataSource(TApi api) => Api = api;
    }
}
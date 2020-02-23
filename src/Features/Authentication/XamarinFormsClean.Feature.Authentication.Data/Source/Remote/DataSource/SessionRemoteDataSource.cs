using System;
using XamarinFormsClean.Common.Data.Extensions;
using XamarinFormsClean.Common.Data.Source.Remote.DataSource;
using XamarinFormsClean.Common.Data.Utils;
using XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Commands;
using XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Dto;
using XamarinFormsClean.Feature.Authentication.Data.Source.Remote.Api.Interface;
using XamarinFormsClean.Feature.Authentication.Data.Source.Remote.DataSource.Interface;

namespace XamarinFormsClean.Feature.Authentication.Data.Source.Remote.DataSource
{
    public class SessionRemoteDataSource : BaseRemoteDataSource<ITmdbAuthApi>, ISessionRemoteDataSource
    {
        public SessionRemoteDataSource(ITmdbAuthApi api) : base(api) { }

        public IObservable<Result<RequestTokenDto>> GetRequestToken() =>
            Api.CreateRequestToken().ToResult();

        public IObservable<Result<RequestTokenDto>> CreateRequestToken() =>
            Api.CreateRequestToken().ToResult();

        public IObservable<Result<SessionDto>> CreateSession(SessionPostCommand command) =>
            Api.CreateSession(command).ToResult();

        public IObservable<Result<TokenValidationDto>> ValidateRequestToken(ValidateTokenPostCommand command) =>
            Api.ValidateRequestToken(command).ToResult();
    }
}
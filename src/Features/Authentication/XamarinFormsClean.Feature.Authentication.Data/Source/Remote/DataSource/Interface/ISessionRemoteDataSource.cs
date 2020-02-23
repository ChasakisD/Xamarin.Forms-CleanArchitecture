using System;
using XamarinFormsClean.Common.Data.Source.Remote.DataSource.Interface;
using XamarinFormsClean.Common.Data.Utils;
using XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Commands;
using XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Dto;
using XamarinFormsClean.Feature.Authentication.Data.Source.Remote.Api.Interface;

namespace XamarinFormsClean.Feature.Authentication.Data.Source.Remote.DataSource.Interface
{
    public interface ISessionRemoteDataSource : IRemoteDataSource<ITmdbAuthApi>
    {
        IObservable<Result<RequestTokenDto>> CreateRequestToken();
        
        IObservable<Result<SessionDto>> CreateSession(SessionPostCommand command);
        
        IObservable<Result<TokenValidationDto>> ValidateRequestToken(ValidateTokenPostCommand command);
    }
}
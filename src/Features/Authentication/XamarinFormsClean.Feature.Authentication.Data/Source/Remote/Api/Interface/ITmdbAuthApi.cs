using System;
using Refit;
using XamarinFormsClean.Common.Data.Source.Remote.Api.Interface;
using XamarinFormsClean.Environment;
using XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Commands;
using XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Dto;

namespace XamarinFormsClean.Feature.Authentication.Data.Source.Remote.Api.Interface
{
    public interface ITmdbAuthApi : IApi
    {
        [Headers(AppEnvironment.Config.Api.AuthenticationHeader)]
        [Get("/authentication/token/new")]
        IObservable<RequestTokenDto> CreateRequestToken();
        
        [Headers(AppEnvironment.Config.Api.AuthenticationHeader)]
        [Post("/authentication/session/new")]
        IObservable<SessionDto> CreateSession(SessionPostCommand command);
        
        [Headers(AppEnvironment.Config.Api.AuthenticationHeader)]
        [Post("/authentication/token/validate_with_login")]
        IObservable<TokenValidationDto> ValidateRequestToken(ValidateTokenPostCommand command);
    }
}
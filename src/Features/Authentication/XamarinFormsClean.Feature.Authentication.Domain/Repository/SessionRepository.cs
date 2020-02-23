using System;
using System.Reactive.Linq;
using XamarinFormsClean.Common.Data.Extensions;
using XamarinFormsClean.Common.Data.Utils;
using XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Commands;
using XamarinFormsClean.Feature.Authentication.Data.Source.Local.DataSource.Interface;
using XamarinFormsClean.Feature.Authentication.Data.Source.Remote.DataSource.Interface;
using XamarinFormsClean.Feature.Authentication.Domain.Mapping.Interface;
using XamarinFormsClean.Feature.Authentication.Domain.Model;
using XamarinFormsClean.Feature.Authentication.Domain.Repository.Interface;

namespace XamarinFormsClean.Feature.Authentication.Domain.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ISessionMapper _mapper;
        private readonly ISessionLocalDataSource _sessionLocalDataSource;
        private readonly ISessionRemoteDataSource _sessionRemoteDataSource;

        public SessionRepository(
            ISessionMapper mapper, 
            ISessionLocalDataSource sessionLocalDataSource, 
            ISessionRemoteDataSource sessionRemoteDataSource)
        {
            _mapper = mapper;
            _sessionLocalDataSource = sessionLocalDataSource;
            _sessionRemoteDataSource = sessionRemoteDataSource;
        }

        public IObservable<Result<SessionEntity>> CreateSession(ValidateTokenPostCommand command) =>
            _sessionRemoteDataSource.CreateRequestToken()
                .ExtractResult()
                .Select(token => 
                    new ValidateTokenPostCommand(
                        command.Username, command.Password, token.RequestToken.Value))
                .SelectMany(validateCommand =>
                    _sessionRemoteDataSource.ValidateRequestToken(validateCommand))
                .ExtractResult()
                .Select(validation => 
                    (validation, new SessionPostCommand(validation.RequestToken.ValueOrDefault)))
                .SelectMany(tuple =>
                    _sessionRemoteDataSource.CreateSession(tuple.Item2)
                        .ExtractResult()
                        .Select(session => (tuple.validation, session)))
                .Select(tuple =>
                    _mapper.ToDomain(tuple.validation, tuple.session))
                .SelectMany(entity =>
                    _sessionLocalDataSource.AddItem(
                            _mapper.ToData(entity))
                        .ExtractResult()
                        .Select(_ => entity))
                .ToResult();
    }
}
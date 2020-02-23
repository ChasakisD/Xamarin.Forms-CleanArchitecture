using System;
using System.Reactive.Linq;
using XamarinFormsClean.Common.Domain.UseCase;
using XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Commands;
using XamarinFormsClean.Feature.Authentication.Domain.Repository.Interface;
using XamarinFormsClean.Feature.Authentication.Domain.UseCases.Interface;

namespace XamarinFormsClean.Feature.Authentication.Domain.UseCases
{
    public class CreateSessionUseCase : 
        UseCase<CreateSessionUseCase.RequestValues, CreateSessionUseCase.ResponseValue>,
        ICreateSessionUseCase
    {
        private readonly ISessionRepository _sessionRepository;

        public CreateSessionUseCase(ISessionRepository sessionRepository) => 
            _sessionRepository = sessionRepository;

        protected override IObservable<ResponseValue> ExecuteUseCase(RequestValues requestValues) =>
            _sessionRepository.CreateSession(requestValues)
                .Select(_ => new ResponseValue());

        public sealed class RequestValues : ValidateTokenPostCommand, IRequestValues
        {
            public RequestValues(string username, string password) 
                : base(username, password) { }
        }
        public sealed class ResponseValue : IResponseValue { }
    }
}
using System;
using XamarinFormsClean.Common.Data.Utils;
using XamarinFormsClean.Feature.Authentication.Data.Model.Remote.Commands;
using XamarinFormsClean.Feature.Authentication.Domain.Model;

namespace XamarinFormsClean.Feature.Authentication.Domain.Repository.Interface
{
    public interface ISessionRepository
    {
        IObservable<Result<SessionEntity>> CreateSession(ValidateTokenPostCommand command);
    }
}
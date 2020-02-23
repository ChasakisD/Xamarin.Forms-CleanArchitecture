using System;
using System.Reactive;
using XamarinFormsClean.Common.Data.Extensions;
using XamarinFormsClean.Common.Data.Utils;
using XamarinFormsClean.Common.Domain.UseCase.Interface;

namespace XamarinFormsClean.Common.Domain.UseCase
{
    public abstract class UseCase : IUseCase
    {
        IObservable<Result<Unit>> IUseCase.Execute() =>
            ExecuteUseCase().ToResult();

        protected abstract IObservable<Unit> ExecuteUseCase();
    }
    
    public abstract class UseCase<TResponse> : IUseCase<TResponse>
        where TResponse : class, UseCase<TResponse>.IResponseValue
    {
        IObservable<Result<TResponse>> IUseCase<TResponse>.Execute() =>
            ExecuteUseCase().ToResult();

        protected abstract IObservable<TResponse> ExecuteUseCase();
        
        public interface IResponseValue : IUseCase<TResponse>.IResponseValue { }
    }

    public abstract class UseCase<TQuery, TResponse> : IUseCase<TQuery, TResponse>
        where TQuery : class, UseCase<TQuery, TResponse>.IRequestValues
        where TResponse : class, UseCase<TQuery, TResponse>.IResponseValue
    {
        IObservable<Result<TResponse>> IUseCase<TQuery, TResponse>.Execute(TQuery requestValues) =>
            ExecuteUseCase(requestValues).ToResult();

        protected abstract IObservable<TResponse> ExecuteUseCase(TQuery requestValues);

        public interface IRequestValues : IUseCase<TQuery, TResponse>.IRequestValues { }

        public interface IResponseValue : IUseCase<TQuery, TResponse>.IResponseValue { }
    }
}
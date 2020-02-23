using System;
using System.Reactive;
using System.Reactive.Linq;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Domain.UseCase.Interface
{
    public interface IUseCase
    {
        IObservable<Result<Unit>> Execute();
    }

    public interface IUseCase<TResponse>
        where TResponse : class, IUseCase<TResponse>.IResponseValue
    {
        IObservable<Result<TResponse>> Execute();
        
        public interface IResponseValue { }
    }

    public interface IUseCase<in TQuery, TResponse>
        where TQuery : class, IUseCase<TQuery, TResponse>.IRequestValues
        where TResponse : class, IUseCase<TQuery, TResponse>.IResponseValue
    {
        IObservable<Result<TResponse>> Execute(TQuery requestValues);
        
        public interface IResponseValue { }
        public interface IRequestValues { }
    }
}
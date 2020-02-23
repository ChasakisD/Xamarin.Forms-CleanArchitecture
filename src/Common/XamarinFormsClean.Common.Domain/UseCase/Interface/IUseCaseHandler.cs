using System;
using System.Reactive;
using System.Reactive.Concurrency;
using ReactiveUI;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Domain.UseCase.Interface
{
    public interface IUseCaseHandler
    {
        IObservable<Result<Unit>> Execute<TUseCase>()
            where TUseCase : IUseCase =>
            Execute<TUseCase>(RxApp.TaskpoolScheduler);

        IObservable<Result<Unit>> Execute<TUseCase>(IScheduler scheduler)
            where TUseCase : IUseCase;
        
        IObservable<Result<TResponse>> Execute<TUseCase, TResponse>()
            where TUseCase : IUseCase<TResponse>
            where TResponse : class, IUseCase<TResponse>.IResponseValue =>
            Execute<TUseCase, TResponse>(RxApp.TaskpoolScheduler);

        IObservable<Result<TResponse>> Execute<TUseCase, TResponse>(IScheduler scheduler)
            where TUseCase : IUseCase<TResponse>
            where TResponse : class, IUseCase<TResponse>.IResponseValue;

        IObservable<Result<TResponse>> Execute<TUseCase, TQuery, TResponse>(TQuery values)
            where TUseCase : IUseCase<TQuery, TResponse>
            where TQuery : class, IUseCase<TQuery, TResponse>.IRequestValues
            where TResponse : class, IUseCase<TQuery, TResponse>.IResponseValue =>
            Execute<TUseCase, TQuery, TResponse>(values, RxApp.TaskpoolScheduler);

        IObservable<Result<TResponse>> Execute<TUseCase, TQuery, TResponse>(TQuery values, IScheduler scheduler)
            where TUseCase : IUseCase<TQuery, TResponse>
            where TQuery : class, IUseCase<TQuery, TResponse>.IRequestValues
            where TResponse : class, IUseCase<TQuery, TResponse>.IResponseValue;
        
        IObservable<Result<Unit>> Execute(IUseCase useCase)  =>
            Execute(useCase, RxApp.TaskpoolScheduler);

        IObservable<Result<Unit>> Execute(IUseCase useCase, IScheduler scheduler);

        IObservable<Result<TResponse>> Execute<TResponse>(IUseCase<TResponse> useCase)
            where TResponse : class, IUseCase<TResponse>.IResponseValue =>
            Execute(useCase, RxApp.TaskpoolScheduler);

        IObservable<Result<TResponse>> Execute<TResponse>(IUseCase<TResponse> useCase, IScheduler scheduler)
            where TResponse : class, IUseCase<TResponse>.IResponseValue;

        IObservable<Result<TResponse>> Execute<TQuery, TResponse>(IUseCase<TQuery, TResponse> useCase, TQuery values)
            where TQuery : class, IUseCase<TQuery, TResponse>.IRequestValues
            where TResponse : class, IUseCase<TQuery, TResponse>.IResponseValue =>
            Execute(useCase, values, RxApp.TaskpoolScheduler);

        IObservable<Result<TResponse>> Execute<TQuery, TResponse>(IUseCase<TQuery, TResponse> useCase, TQuery values, IScheduler scheduler)
            where TQuery : class, IUseCase<TQuery, TResponse>.IRequestValues
            where TResponse : class, IUseCase<TQuery, TResponse>.IResponseValue;
    }
}
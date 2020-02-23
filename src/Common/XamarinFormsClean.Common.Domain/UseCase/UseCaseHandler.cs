using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Prism.Ioc;
using ReactiveUI;
using XamarinFormsClean.Common.Data.Utils;
using XamarinFormsClean.Common.Domain.Ioc;
using XamarinFormsClean.Common.Domain.UseCase.Interface;

namespace XamarinFormsClean.Common.Domain.UseCase
{
    public class UseCaseHandler : IUseCaseHandler
    {
        public IObservable<Result<Unit>> Execute<TUseCase>(IScheduler scheduler)
            where TUseCase : IUseCase
        {
            var useCase = Injection.Current.Resolve<TUseCase>();
            return ExecuteObservableOn(useCase.Execute(), scheduler);
        }
        
        public IObservable<Result<TResponse>> Execute<TUseCase, TResponse>(IScheduler scheduler)
            where TUseCase : IUseCase<TResponse>
            where TResponse : class, IUseCase<TResponse>.IResponseValue
        {
            var useCase = Injection.Current.Resolve<TUseCase>();
            return ExecuteObservableOn(useCase.Execute(), scheduler);
        }

        public IObservable<Result<TResponse>> Execute<TUseCase, TQuery, TResponse>(TQuery values, IScheduler scheduler)
            where TUseCase : IUseCase<TQuery, TResponse>
            where TQuery : class, IUseCase<TQuery, TResponse>.IRequestValues
            where TResponse : class, IUseCase<TQuery, TResponse>.IResponseValue
        {
            var useCase = Injection.Current.Resolve<TUseCase>();
            return ExecuteObservableOn(useCase.Execute(values), scheduler);
        }
        
        public IObservable<Result<Unit>> Execute(IUseCase useCase, IScheduler scheduler)  =>
            ExecuteObservableOn(useCase.Execute(), scheduler);

        public IObservable<Result<TResponse>> Execute<TResponse>(IUseCase<TResponse> useCase, IScheduler scheduler)
            where TResponse : class, IUseCase<TResponse>.IResponseValue =>
            ExecuteObservableOn(useCase.Execute(), scheduler);

        public IObservable<Result<TResponse>> Execute<TQuery, TResponse>(IUseCase<TQuery, TResponse> useCase, TQuery values, IScheduler scheduler)
            where TQuery : class, IUseCase<TQuery, TResponse>.IRequestValues
            where TResponse : class, IUseCase<TQuery, TResponse>.IResponseValue =>
            ExecuteObservableOn(useCase.Execute(values), scheduler);

        private static IObservable<T> ExecuteObservableOn<T>(IObservable<T> observable, IScheduler scheduler) =>
            observable
                .SubscribeOn(scheduler)
                .ObserveOn(RxApp.MainThreadScheduler);
    }
}
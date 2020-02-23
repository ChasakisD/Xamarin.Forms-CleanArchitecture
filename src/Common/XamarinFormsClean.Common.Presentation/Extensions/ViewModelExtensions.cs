using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using XamarinFormsClean.Common.Presentation.ViewModels;

namespace XamarinFormsClean.Common.Presentation.Extensions
{
    public static class ViewModelExtensions
    {
        public static IObservable<T> WrapVisualState<T>(this BaseViewModel viewModel, IObservable<T> observable)
        {
            return viewModel.SetVisualState(BaseViewModel.State.Loading)
                .SelectMany(_ => observable)
                .SelectMany(observableResult =>
                    viewModel.SetVisualState(BaseViewModel.State.None)
                        .Select(_ => observableResult));
        }

        private static IObservable<Unit> SetVisualState(this BaseViewModel viewModel, BaseViewModel.State state)
        {
            return Observable.Start(() => viewModel.VisualState = state, RxApp.MainThreadScheduler)
                .Select(_ => Unit.Default);
        }
    }
}
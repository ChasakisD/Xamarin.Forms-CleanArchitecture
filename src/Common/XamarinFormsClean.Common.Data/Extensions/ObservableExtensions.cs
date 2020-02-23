using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace XamarinFormsClean.Common.Data.Extensions
{
    public static partial class ObservableExtensions
    {
        public static IObservable<bool> ToSafeObservable(
            this IObservable<Unit> observable) =>
            observable
                .Select(_ => true)
                .Catch(Observable.Return(false));

        public static IObservable<IEnumerable<T>> ToSafeObservable<T>(
            this IObservable<IEnumerable<T>> observable) =>
            observable
                .Select(enumerable => enumerable ?? Enumerable.Empty<T>())
                .Catch(Observable.Return(Enumerable.Empty<T>()));

        public static IObservable<bool> ToSafeObservable<T>(
            this IObservable<T> observable) =>
            observable
                .Select(_ => true)
                .Catch(Observable.Return(false));
    }
}
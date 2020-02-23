using System;
using System.Reactive.Linq;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Data.Extensions
{
    public static partial class ObservableExtensions
    {
        public static IObservable<Option<T>> ToOptionObservable<T>(
            this IObservable<T> observable) =>
            observable
                .Select(Option.From)
                .Catch(Observable.Return(Option.None<T>()));
    }
}
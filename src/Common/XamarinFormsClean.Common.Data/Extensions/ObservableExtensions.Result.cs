using System;
using System.Reactive.Linq;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Data.Extensions
{
    public static partial class ObservableExtensions
    {
        public static IObservable<Result<T>> ToResult<T>(
            this IObservable<T> observable) =>
            observable
                .Select(t => new Result<T>.Success(t))
                .Catch<Result<T>, Exception>(e =>
                    Observable.Return(new Result<T>.Error(e)));

        public static IObservable<T> ExtractResult<T>(
            this IObservable<Result<T>> observable) =>
            observable.SelectMany(r => r switch
            {
                Result<T>.Error {Exception: var e} =>
                    Observable.Throw<T>(e),
                Result<T>.Success {Data: var data} =>
                    Observable.Return(data),
                _ => 
                    Observable.Throw<T>(new InvalidOperationException())
            });
    }
}
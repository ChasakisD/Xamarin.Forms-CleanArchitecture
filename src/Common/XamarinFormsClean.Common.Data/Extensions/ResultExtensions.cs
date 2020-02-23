using System;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Data.Extensions
{
    public static class ResultExtensions
    {
        public static bool Succeeded<T>(this Result<T> result) =>
            result switch
            {
                Result<T>.Error _ => false,
                Result<T>.Loading _ => false,
                Result<T>.Success { Data: var data } when data == null => false,
                Result<T>.Success _ => true,
                _ => throw new InvalidOperationException()
            };

        public static Result<TTo> From<TFrom, TTo>(
            this Result<TFrom> fromResult, Func<TFrom, TTo> transform) =>
            fromResult switch
            {
                Result<TFrom>.Success { Data: var data } =>
                new Result<TTo>.Success(transform(data)),
                Result<TFrom>.Error { Exception: var exception } =>
                new Result<TTo>.Error(exception),
                Result<TFrom>.Loading _ =>
                new Result<TTo>.Loading(),
                _ => throw new InvalidOperationException()
            };
    }
}
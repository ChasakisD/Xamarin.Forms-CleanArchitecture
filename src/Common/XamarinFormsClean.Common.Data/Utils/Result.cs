using System;

namespace XamarinFormsClean.Common.Data.Utils
{
    public abstract class Result<T>
    {
        public sealed class Success : Result<T>
        {
            public T Data { get; }

            public Success(T data) =>
                Data = data;
        }

        public sealed class Error : Result<T>
        {
            public Exception Exception { get; }

            public Error(Exception exception) =>
                Exception = exception;
        }

        public sealed class Loading : Result<T> { }
    }
}
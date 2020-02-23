using System;
using System.Reactive;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Data.Source.Local.DataSource.Interface
{
    public interface ILocalDataSource
    {
        IObservable<Result<Unit>> Invalidate();
    }
}
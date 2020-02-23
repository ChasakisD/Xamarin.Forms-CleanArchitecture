using System;
using System.Reactive;
using XamarinFormsClean.Common.Data.Model.Local;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Data.Source.Local.DataSource.Interface
{
    public interface ISingleLocalDataSource<T> : ILocalDataSource where T : BaseData
    {
        IObservable<Result<T>> GetItem();
        IObservable<Result<Unit>> AddItem(T item);
        IObservable<Result<Unit>> UpdateItem(T item);
        IObservable<Result<Unit>> RemoveItem();
    }
}
using System;
using System.Collections.Generic;
using System.Reactive;
using XamarinFormsClean.Common.Data.Model.Local;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Data.Source.Local.DataSource.Interface
{
    public interface ICollectionLocalDataSource<T> : ILocalDataSource where T : BaseData
    {
        IObservable<Result<T>> GetItem(string key);
        IObservable<Result<IEnumerable<T>>> GetItems(IEnumerable<string> keys);
        IObservable<Result<IEnumerable<T>>> GetAllItems();
        
        IObservable<Result<Unit>> AddItem(T item);
        IObservable<Result<Unit>> AddItems(IEnumerable<T> items);
        
        IObservable<Result<Unit>> UpdateItem(T item);
        IObservable<Result<Unit>> UpdateItems(IEnumerable<T> items);
        
        IObservable<Result<Unit>> RemoveItem(T item);
        IObservable<Result<Unit>> RemoveItems(IEnumerable<T> items);
        IObservable<Result<Unit>> RemoveItem(string key);        
        IObservable<Result<Unit>> RemoveItems(IEnumerable<string> keys);
    }
}
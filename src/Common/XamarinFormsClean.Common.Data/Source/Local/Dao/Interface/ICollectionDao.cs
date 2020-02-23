using System;
using System.Collections.Generic;
using System.Reactive;
using XamarinFormsClean.Common.Data.Model.Local;

namespace XamarinFormsClean.Common.Data.Source.Local.Dao.Interface
{
    public interface ICollectionDao<T> : IDao where T : BaseData
    {
        IObservable<IEnumerable<T>> GetAllItems();
        
        IObservable<T> GetItem(string key);
        IObservable<IEnumerable<T>> GetItems(IEnumerable<string> keys);
        
        IObservable<Unit> AddItem(T item);
        IObservable<Unit> AddItems(IEnumerable<T> items);        

        IObservable<Unit> UpdateItem(T item);
        IObservable<Unit> UpdateItems(IEnumerable<T> items);
        
        IObservable<Unit> RemoveItem(T item);
        IObservable<Unit> RemoveItems(IEnumerable<T> items);
        IObservable<Unit> RemoveItem(string key);
        IObservable<Unit> RemoveItems(IEnumerable<string> keys);
    }
}
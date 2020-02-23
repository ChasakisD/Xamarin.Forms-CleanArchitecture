using System;
using System.Collections.Generic;
using System.Reactive;
using XamarinFormsClean.Common.Data.Model.Local;

namespace XamarinFormsClean.Common.Data.Source.Local.Dao.Interface
{
    public interface ICollectionDao<T> : ISingleDao<T> where T : BaseData
    {
        IObservable<IEnumerable<T>> GetAllItems();
        
        IObservable<IEnumerable<T>> GetItems(IEnumerable<string> keys);
        IObservable<Unit> AddItems(IEnumerable<T> items);
        IObservable<Unit> UpdateItems(IEnumerable<T> items);
        IObservable<Unit> RemoveItems(IEnumerable<T> items);
        IObservable<Unit> RemoveItems(IEnumerable<string> keys);
    }
}
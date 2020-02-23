using System;
using System.Reactive;
using XamarinFormsClean.Common.Data.Model.Local;

namespace XamarinFormsClean.Common.Data.Source.Local.Dao.Interface
{
    public interface ISingleDao<T> : IDao where T : BaseData
    {
        IObservable<T> GetItem(string key);
        IObservable<Unit> AddItem(string key, T item);
        IObservable<Unit> UpdateItem(string key, T item);
        IObservable<Unit> RemoveItem(string key);
    }
}
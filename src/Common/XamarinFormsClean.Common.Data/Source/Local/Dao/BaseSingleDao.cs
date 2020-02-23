using System;
using System.Reactive;
using System.Reactive.Linq;
using Akavache;
using XamarinFormsClean.Common.Data.Model.Local;
using XamarinFormsClean.Common.Data.Source.Local.Dao.Interface;

namespace XamarinFormsClean.Common.Data.Source.Local.Dao
{
    public abstract class BaseSingleDao<T> : ISingleDao<T> where T : BaseData
    {
        protected virtual IBlobCache Storage => ApplicationStorage.Default;
        
        public IObservable<Unit> Invalidate() =>
            Storage.GetAllObjects<T>()
                .SelectMany(keys => Storage.InvalidateAllObjects<T>());

        public IObservable<T> GetItem(string key) =>
            Storage.GetObject<T>(key);

        public IObservable<Unit> AddItem(T item) =>
            Storage.InsertObject(item.UniqueId, item);

        public IObservable<Unit> UpdateItem(T item) =>
            AddItem(item);

        public IObservable<Unit> RemoveItem(T item) =>
            RemoveItem(item.UniqueId);

        public IObservable<Unit> RemoveItem(string key) =>
            Storage.InvalidateObject<T>(key);
    }
}
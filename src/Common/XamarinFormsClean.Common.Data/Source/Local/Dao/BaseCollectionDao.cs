using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Akavache;
using XamarinFormsClean.Common.Data.Extensions;
using XamarinFormsClean.Common.Data.Model.Local;
using XamarinFormsClean.Common.Data.Source.Local.Dao.Interface;

namespace XamarinFormsClean.Common.Data.Source.Local.Dao
{
    public abstract class BaseCollectionDao<T> : ICollectionDao<T> where T : BaseData
    {
        protected virtual IBlobCache Storage => ApplicationStorage.Default;
        
        public IObservable<Unit> Invalidate() =>
            Storage.InvalidateAllObjects<T>();
        
        public IObservable<IEnumerable<T>> GetAllItems() =>
            Storage.GetAllObjects<T>();

        public IObservable<T> GetItem(string key) =>
            Storage.GetObject<T>(key);
        
        public IObservable<IEnumerable<T>> GetItems(IEnumerable<string> keys) =>
            Storage.GetObjects<T>(keys)
                .Select(dictionary => dictionary.Values);

        public IObservable<Unit> AddItem(T item) =>
            Storage.InsertObject(item.UniqueId, item);
        
        public IObservable<Unit> AddItems(IEnumerable<T> items) =>
            Storage.InsertObjects(
                items.ToDictionary(
                    keySelector => keySelector.UniqueId,
                    itemSelector => itemSelector));

        public IObservable<Unit> UpdateItem(T item) =>
            AddItem(item);
        
        public IObservable<Unit> UpdateItems(IEnumerable<T> items) =>
            AddItems(items);
        
        public IObservable<Unit> RemoveItem(T item) =>
            RemoveItem(item.UniqueId);

        public IObservable<Unit> RemoveItems(IEnumerable<T> items) =>
            RemoveItems(items.Select(item => item.UniqueId));

        public IObservable<Unit> RemoveItem(string key) =>
            Storage.InvalidateObject<T>(key);
        
        public IObservable<Unit> RemoveItems(IEnumerable<string> keys) =>
            Storage.InvalidateObjects<T>(keys);
    }
}
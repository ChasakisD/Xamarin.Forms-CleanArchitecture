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
            Storage.InvalidateAllObjects<T>();

        public IObservable<T> GetItem(string key) =>
            Storage.GetObject<T>(key);

        public IObservable<Unit> AddItem(string key, T item) =>
            Storage.InsertObject(key, item);

        public IObservable<Unit> UpdateItem(string key, T item) =>
            AddItem(key, item);

        public IObservable<Unit> RemoveItem(string key) =>
            Storage.InvalidateObject<T>(key);
    }
}
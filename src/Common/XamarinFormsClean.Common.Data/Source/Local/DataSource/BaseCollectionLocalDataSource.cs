using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using XamarinFormsClean.Common.Data.Extensions;
using XamarinFormsClean.Common.Data.Model.Local;
using XamarinFormsClean.Common.Data.Source.Local.Dao.Interface;
using XamarinFormsClean.Common.Data.Source.Local.DataSource.Interface;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Data.Source.Local.DataSource
{
    public abstract class BaseCollectionLocalDataSource<T> : ICollectionLocalDataSource<T> where T : BaseData
    {
        private readonly ICollectionDao<T> _dao;
        
        protected BaseCollectionLocalDataSource(ICollectionDao<T> dao) => 
            _dao = dao;

        public IObservable<Result<Unit>> Invalidate() =>
            _dao.Invalidate()
                .SelectMany(_ => Intercept())
                .ToResult();

        public IObservable<Result<T>> GetItem(string key) =>
            _dao.GetItem(key).ToResult();

        public IObservable<Result<IEnumerable<T>>> GetItems(IEnumerable<string> keys) =>
            _dao.GetItems(keys).ToResult();

        public IObservable<Result<IEnumerable<T>>> GetAllItems() =>
            _dao.GetAllItems().ToResult();

        public IObservable<Result<Unit>> AddItem(T item) =>
            _dao.AddItem(item)
                .SelectMany(_ => Intercept())
                .ToResult();

        public IObservable<Result<Unit>> AddItems(IEnumerable<T> items) =>
            _dao.AddItems(items)
                .SelectMany(_ => Intercept())
                .ToResult();

        public IObservable<Result<Unit>> UpdateItem(T item) =>
            _dao.UpdateItem(item)
                .SelectMany(_ => Intercept())
                .ToResult();

        public IObservable<Result<Unit>> UpdateItems(IEnumerable<T> items) =>
            _dao.UpdateItems(items)
                .SelectMany(_ => Intercept())
                .ToResult();

        public IObservable<Result<Unit>> RemoveItem(T item) =>
            _dao.RemoveItem(item)
                .SelectMany(_ => Intercept())
                .ToResult();

        public IObservable<Result<Unit>> RemoveItems(IEnumerable<T> items) =>
            _dao.RemoveItems(items)
                .SelectMany(_ => Intercept())
                .ToResult();

        public IObservable<Result<Unit>> RemoveItem(string key) =>
            _dao.RemoveItem(key)
                .SelectMany(_ => Intercept())
                .ToResult();

        public IObservable<Result<Unit>> RemoveItems(IEnumerable<string> keys) =>
            _dao.RemoveItems(keys)
                .SelectMany(_ => Intercept())
                .ToResult();
        
        protected virtual IObservable<Unit> Intercept() =>
            Observable.Return(Unit.Default);
    }
}
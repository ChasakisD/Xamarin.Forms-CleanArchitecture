using System;
using System.Reactive;
using System.Reactive.Linq;
using XamarinFormsClean.Common.Data.Extensions;
using XamarinFormsClean.Common.Data.Model.Local;
using XamarinFormsClean.Common.Data.Source.Local.Dao.Interface;
using XamarinFormsClean.Common.Data.Source.Local.DataSource.Interface;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Data.Source.Local.DataSource
{
    public abstract class BaseSingleLocalDataSource<T> : ISingleLocalDataSource<T> where T : BaseData 
    {
        private readonly ISingleDao<T> _dao;
        
        protected abstract string ItemKey { get; }
        
        protected BaseSingleLocalDataSource(ISingleDao<T> dao) => _dao = dao;

        public IObservable<Result<Unit>> Invalidate() =>
            _dao.Invalidate()
                .SelectMany(_ => Intercept())
                .ToResult();

        public IObservable<Result<T>> GetItem() =>
            _dao.GetItem(ItemKey).ToResult();

        public IObservable<Result<Unit>> AddItem(T item) =>
            _dao.AddItem(ItemKey, item)
                .SelectMany(_ => Intercept())
                .ToResult();

        public IObservable<Result<Unit>> UpdateItem(T item) =>
            _dao.UpdateItem(ItemKey, item)
                .SelectMany(_ => Intercept())
                .ToResult();

        public IObservable<Result<Unit>> RemoveItem() =>
            _dao.RemoveItem(ItemKey)
                .SelectMany(_ => Intercept())
                .ToResult();

        protected virtual IObservable<Unit> Intercept() =>
            Observable.Return(Unit.Default);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using XamarinFormsClean.Common.Data.Model.Local;
using XamarinFormsClean.Common.Data.Source.Local.Dao.Interface;
using XamarinFormsClean.Common.Data.Source.Local.DataSource.Interface;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Data.Source.Local.DataSource
{
    public abstract class BaseRealTimeCollectionLocalDataSource<T> :
        BaseCollectionLocalDataSource<T>,
        IRealTimeLocalDataSource<T>
        where T : BaseData
    {
        public IObservable<IEnumerable<T>> ItemsChanged { get; }

        private readonly Subject<IEnumerable<T>> _itemsChangedSubject;
        
        protected BaseRealTimeCollectionLocalDataSource(ICollectionDao<T> dao) : base(dao)
        {
            _itemsChangedSubject = new Subject<IEnumerable<T>>();
            
            ItemsChanged = Observable.Create<IEnumerable<T>>(observer =>
            {
                GetAllItems()
                    .SingleAsync()
                    .Subscribe(itemsResult => 
                        PublishItemsToObserver(itemsResult, observer));
                
                var subscription = _itemsChangedSubject
                    .AsObservable()
                    .Subscribe(observer);
                
                return Disposable.Create(() => subscription.Dispose());
            });
        }
        
        protected override IObservable<Unit> Intercept() =>
            Observable.If(() => _itemsChangedSubject.HasObservers,
                GetAllItems()
                    .Do(itemsResult => 
                        PublishItemsToObserver(itemsResult, _itemsChangedSubject))
                    .Select(_ => Unit.Default),
                Observable.Return(Unit.Default));

        private static void PublishItemsToObserver(
            Result<IEnumerable<T>> itemsResult, IObserver<IEnumerable<T>> observer)
        {
            switch (itemsResult)
            {
                case Result<IEnumerable<T>>.Error _:
                    observer.OnNext(Enumerable.Empty<T>());
                    break;
                case Result<IEnumerable<T>>.Success {Data: var data}:
                    observer.OnNext(data ?? Enumerable.Empty<T>());
                    break;
            }
        }
    }
}
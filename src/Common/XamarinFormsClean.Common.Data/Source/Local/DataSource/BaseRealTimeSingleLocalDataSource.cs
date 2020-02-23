using System;
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
    public abstract class BaseRealTimeSingleLocalDataSource<T> : 
        BaseSingleLocalDataSource<T>, 
        IRealTimeSingleLocalDataSource<T> 
        where T : BaseData
    {
        public IObservable<T> ItemChanged { get; }
        
        private readonly Subject<T> _itemsChangedSubject;

        protected BaseRealTimeSingleLocalDataSource(ISingleDao<T> dao) : base(dao)
        {
            _itemsChangedSubject = new Subject<T>();
            
            ItemChanged = Observable.Create<T>(observer =>
            {
                GetItem()
                    .SingleAsync()
                    .Subscribe(itemsResult => 
                        PublishItemsToObserver(itemsResult, observer, false));
                
                var subscription = _itemsChangedSubject
                    .AsObservable()
                    .Subscribe(observer);
                
                return Disposable.Create(() => subscription.Dispose());
            });
        }

        protected override IObservable<Unit> Intercept() =>
            Observable.If(() => _itemsChangedSubject.HasObservers,
                GetItem()
                    .Do(itemResult => 
                        PublishItemsToObserver(itemResult, _itemsChangedSubject, true))
                    .Select(_ => Unit.Default),
                Observable.Return(Unit.Default));

        private static void PublishItemsToObserver(
            Result<T> itemsResult, IObserver<T> observer, bool suppressErrors)
        {
            switch (itemsResult)
            {
                case Result<T>.Error {Exception: var exception}:
                    if (!suppressErrors)
                    {
                        observer.OnError(exception);
                    }
                    break;
                case Result<T>.Success {Data: var data}:
                    observer.OnNext(data);
                    break;
            }
        }
    }
}
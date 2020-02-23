using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Ioc;
using Prism.Navigation;
using ReactiveUI;
using XamarinFormsClean.Common.Domain.Ioc;
using XamarinFormsClean.Common.Domain.UseCase.Interface;

namespace XamarinFormsClean.Common.Presentation.ViewModels
{
    public abstract class BaseViewModel :
        ReactiveObject,
        IDestructible,
        IInitialize,
        IInitializeAsync,
        INavigationAware,
        IAutoInitialize
    {
        private readonly Subject<Unit> _whenDisposedSubject;
        private readonly Subject<INavigationParameters> _whenInitializedSubject;
        private readonly Subject<INavigationParameters> _whenNavigatedToSubject;
        private readonly Subject<INavigationParameters> _whenNavigatedFromSubject;

        protected CompositeDisposable Disposables { get; }

        protected IUseCaseHandler UseCaseHandler { get; }

        protected IObservable<Unit> WhenDisposed =>
            _whenDisposedSubject.AsObservable();

        protected IObservable<INavigationParameters> WhenInitialized =>
            _whenInitializedSubject.AsObservable();

        protected IObservable<INavigationParameters> WhenNavigatedTo =>
            _whenNavigatedToSubject.AsObservable();

        protected IObservable<INavigationParameters> WhenNavigatedFrom =>
            _whenNavigatedFromSubject.AsObservable();

        private State _visualState;
        public State VisualState
        {
            get => _visualState;
            set
            {
                if (_visualState == value) return;

                _visualState = value;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(IsLoading));
            }
        }
        
        public bool IsLoading => VisualState == State.Loading;

        protected BaseViewModel()
        {
            Disposables = new CompositeDisposable();

            UseCaseHandler = Injection.Current.Resolve<IUseCaseHandler>()
                ?? throw new ArgumentNullException(nameof(UseCaseHandler));

            _visualState = State.None;

            _whenDisposedSubject = new Subject<Unit>();
            _whenInitializedSubject = new Subject<INavigationParameters>();
            _whenNavigatedToSubject = new Subject<INavigationParameters>();
            _whenNavigatedFromSubject = new Subject<INavigationParameters>();
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters) =>
            _whenNavigatedToSubject.OnNext(parameters);

        public virtual void OnNavigatedFrom(INavigationParameters parameters) =>
            _whenNavigatedFromSubject.OnNext(parameters);

        public virtual void Initialize(INavigationParameters parameters) => 
            _whenInitializedSubject.OnNext(parameters);

        public virtual Task InitializeAsync(INavigationParameters parameters) => 
            Task.CompletedTask;

        public virtual void Destroy()
        {
            _whenDisposedSubject.OnNext(Unit.Default);

            Disposables.Dispose();

            _whenDisposedSubject.Dispose();
            _whenInitializedSubject.Dispose();
            _whenNavigatedToSubject.Dispose();
            _whenNavigatedFromSubject.Dispose();
        }

        public abstract class State
        {
            public static readonly State None = new NoneState();
            public static readonly State Loading = new LoadingState();
            
            private sealed class NoneState : State { }
            private sealed class LoadingState : State { }
        }
    }
}
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Disposables;
using XamarinFormsClean.Common.Presentation.Extensions;
using XamarinFormsClean.Common.Presentation.ViewModels;
using XamarinFormsClean.Feature.Authentication.Data.Source.Local.DataSource.Interface;
using XamarinFormsClean.Feature.Authentication.Domain.Mapping.Interface;
using XamarinFormsClean.Feature.Authentication.Domain.Model;
using XamarinFormsClean.Feature.Authentication.Domain.UseCases;
using XamarinFormsClean.Feature.Authentication.Domain.UseCases.Interface;

namespace XamarinFormsClean.Feature.Authentication.Presentation.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ISessionMapper _sessionMapper;        
        private readonly ICreateSessionUseCase _createSessionUseCase;
        private readonly ISessionLocalDataSource _sessionLocalDataSource;

        public LoginViewModel(
            ISessionMapper sessionMapper,
            ICreateSessionUseCase createSessionUseCase, 
            ISessionLocalDataSource sessionLocalDataSource)
        {
            _createSessionUseCase = createSessionUseCase;
            _sessionLocalDataSource = sessionLocalDataSource;
            _sessionMapper = sessionMapper;

            _username = string.Empty;
            _password = string.Empty;
            
            WhenInitialized
                .SelectMany(_sessionLocalDataSource.ItemsChanged)
                .Select(sessions => sessions.FirstOrDefault())
                .Subscribe(session =>
                {
                    if (session == null) return;
                    Session = _sessionMapper.ToDomain(session);
                })
                .DisposeWith(Disposables);
        }
        
        private string _username;
        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }
        
        private string _password;
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        private SessionEntity? _session;
        public SessionEntity Session
        {
            get => _session ?? new SessionEntity();
            set => this.RaiseAndSetIfChanged(ref _session, value);
        }

        private ICommand? _loginCommand;
        public ICommand LoginCommand =>
            _loginCommand ??= ReactiveCommand.CreateFromObservable(
                () => this.WrapVisualState(
                    UseCaseHandler.Execute(_createSessionUseCase,
                        new CreateSessionUseCase.RequestValues(
                            Username, Password))),
                this.WhenAnyValue(
                        vm => vm.Username,
                        vm => vm.Password,
                        (username, password) => (username, password))
                    .Select(vm =>
                        !string.IsNullOrEmpty(vm.username)
                        && !string.IsNullOrEmpty(vm.password)));
    }
}
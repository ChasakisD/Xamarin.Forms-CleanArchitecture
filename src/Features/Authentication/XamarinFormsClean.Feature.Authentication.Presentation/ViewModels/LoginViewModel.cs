using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;
using XamarinFormsClean.Common.Presentation.Extensions;
using XamarinFormsClean.Common.Presentation.ViewModels;
using XamarinFormsClean.Feature.Authentication.Domain.UseCases;
using XamarinFormsClean.Feature.Authentication.Domain.UseCases.Interface;

namespace XamarinFormsClean.Feature.Authentication.Presentation.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ICreateSessionUseCase _createSessionUseCase;

        public LoginViewModel(ICreateSessionUseCase createSessionUseCase)
        {
            _createSessionUseCase = createSessionUseCase;

            _username = string.Empty;
            _password = string.Empty;
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

        private ICommand? _loginCommand;
        public ICommand LoginCommand =>
            _loginCommand ??= ReactiveCommand.CreateFromObservable(
                () => this.WrapVisualState(
                    _createSessionUseCase.Execute(
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
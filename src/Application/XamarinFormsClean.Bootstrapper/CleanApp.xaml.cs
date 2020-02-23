using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Xamarin.Forms;
using XamarinFormsClean.Common.Data.Source.Local;
using XamarinFormsClean.Common.Domain.Ioc;
using XamarinFormsClean.Common.Domain.UseCase;
using XamarinFormsClean.Common.Domain.UseCase.Interface;
using XamarinFormsClean.Feature.Authentication.Module;

namespace XamarinFormsClean.Bootstrapper
{
    public partial class CleanApp
    {
        public CleanApp(IPlatformInitializer? initializer = null) : base(initializer)
        {
            InitializeComponent();
        }

        protected override void OnSleep() =>
            ApplicationStorage.EnsureFlushed();

        protected override void OnInitialized() =>
            NavigationService.NavigateAsync($"NavigationPage/LoginView");

        protected override IContainerExtension CreateContainerExtension()
        {
            Injection.Current = PrismContainerExtension.Current;
            return Injection.Current;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterSingleton<IUseCaseHandler, UseCaseHandler>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            
            moduleCatalog.AddModule<AuthenticationModule>();
        }
    }
}
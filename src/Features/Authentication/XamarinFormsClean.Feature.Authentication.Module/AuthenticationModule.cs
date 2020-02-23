using System.Diagnostics;
using Prism.Ioc;
using Prism.Modularity;
using Refit;
using XamarinFormsClean.Common.Api;
using XamarinFormsClean.Environment;
using XamarinFormsClean.Feature.Authentication.Data.Source.Local.Dao;
using XamarinFormsClean.Feature.Authentication.Data.Source.Local.Dao.Interface;
using XamarinFormsClean.Feature.Authentication.Data.Source.Local.DataSource;
using XamarinFormsClean.Feature.Authentication.Data.Source.Local.DataSource.Interface;
using XamarinFormsClean.Feature.Authentication.Data.Source.Remote.Api.Interface;
using XamarinFormsClean.Feature.Authentication.Data.Source.Remote.DataSource;
using XamarinFormsClean.Feature.Authentication.Data.Source.Remote.DataSource.Interface;
using XamarinFormsClean.Feature.Authentication.Domain.Mapping;
using XamarinFormsClean.Feature.Authentication.Domain.Mapping.Interface;
using XamarinFormsClean.Feature.Authentication.Domain.Repository;
using XamarinFormsClean.Feature.Authentication.Domain.Repository.Interface;
using XamarinFormsClean.Feature.Authentication.Domain.UseCases;
using XamarinFormsClean.Feature.Authentication.Domain.UseCases.Interface;
using XamarinFormsClean.Feature.Authentication.Presentation.ViewModels;
using XamarinFormsClean.Feature.Authentication.Presentation.Views;

namespace XamarinFormsClean.Feature.Authentication.Module
{
    public class AuthenticationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            Debug.WriteLine("Authentication Module Initialized!");
        }
        
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingletonFromDelegate<ITmdbAuthApi>(() =>
                RestService.For<ITmdbAuthApi>(AppEnvironment.Config.Api.BaseUrl, HttpSettings.Refit));
            
            containerRegistry.RegisterSingleton<ISessionDao, SessionDao>();
            containerRegistry.RegisterSingleton<ISessionLocalDataSource, SessionLocalDataSource>();
            containerRegistry.RegisterSingleton<ISessionRemoteDataSource, SessionRemoteDataSource>();

            containerRegistry.RegisterSingleton<ISessionMapper, SessionMapper>();
            containerRegistry.RegisterSingleton<ISessionRepository, SessionRepository>();

            containerRegistry.Register<ICreateSessionUseCase, CreateSessionUseCase>();
            
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
        }
    }
}
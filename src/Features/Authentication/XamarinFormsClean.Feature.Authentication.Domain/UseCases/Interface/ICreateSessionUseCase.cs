using XamarinFormsClean.Common.Domain.UseCase.Interface;

namespace XamarinFormsClean.Feature.Authentication.Domain.UseCases.Interface
{
    public interface ICreateSessionUseCase : IUseCase<CreateSessionUseCase.RequestValues, CreateSessionUseCase.ResponseValue> { }
}
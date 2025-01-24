using master.bank.application.appInterface.Base;
using master.bank.domain.core.repository.Interface.Base;
using master.bank.domain.core.service.Base;

namespace master.bank.application.appService.Base;

public class AppServiceBase<T, S, R> : IAppServiceBase<T, S, R>
    where T : class
    where S : IServiceBase<T, R>
    where R : IRepositoryBase<T>
{
    protected readonly IServiceBase<T, R> _service;

    public AppServiceBase(IServiceBase<T, R> serviceBase)
    {
        _service = serviceBase;
    }

    public S GetService() => (S)_service;
}
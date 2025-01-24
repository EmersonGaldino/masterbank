using master.bank.domain.core.repository.Interface.Base;
using master.bank.domain.core.service.Base;

namespace master.bank.application.appInterface.Base;

public interface IAppServiceBase<T, S, R>
	where T : class
	where S : IServiceBase<T, R>
	where R : IRepositoryBase<T>
{
	S GetService();
}
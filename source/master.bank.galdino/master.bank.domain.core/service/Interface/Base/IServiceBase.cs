using master.bank.domain.core.generic;
using master.bank.domain.core.repository.Interface.Base;

namespace master.bank.domain.core.service.Base;

public interface IServiceBase<T, R> : IGet<T>, ISelect<T> where T : class where R : IRepositoryBase<T>
{
    R GetRepository();
}
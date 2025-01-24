using master.bank.domain.core.generic;

namespace master.bank.domain.core.repository.Interface.Base;

public interface IRepositoryBase<T> : IGet<T>,
    ISelect<T>, IListByIds<T>, IGetUow, ISave<T>, ISaveAll<T> where T : class
{
}
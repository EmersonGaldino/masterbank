namespace master.bank.domain.core.generic;

public interface ISaveAll<T> where T : class
{
    Task SaveAsync(IList<T> entities);
}
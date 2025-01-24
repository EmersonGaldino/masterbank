namespace master.bank.domain.core.generic;

public interface ISave<T> where T : class
{
    Task SaveAsync(T entities);
}
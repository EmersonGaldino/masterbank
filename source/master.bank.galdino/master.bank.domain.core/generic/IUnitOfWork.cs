using System.Data;

namespace master.bank.domain.core.generic;

public interface IUnitOfWork : IDisposable
{
    void Begin();
    void Commit();
    void RollBack();
    IDbConnection GetConnection();
    IDbTransaction GetTransaction();
    void Release();
}

using master.bank.domain.core.generic;
using master.bank.utils.shared;

namespace master.bank.infraestructure.persistence.configuration.uow;

public class UnitOfWorkPostgres(string connectionString) : UnitOfWork(connectionString), IConnectionPostgres;
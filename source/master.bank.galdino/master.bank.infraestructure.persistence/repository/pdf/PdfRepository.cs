using master.bank.domain.core.repository.Interface.pdf;
using master.bank.infraestructure.persistence.repository.Base;
using master.bank.utils.shared;

namespace master.bank.infraestructure.persistence.repository.pdf;

public class PdfRepository(IConnectionPostgres uow) : RepositoryBase<object>(uow), IPdfRepository
{
    
}
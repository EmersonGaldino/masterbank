using master.bank.domain.core.Entity.pdf;
using master.bank.domain.core.repository.Interface.pdf;
using master.bank.domain.core.service.Base;

namespace master.bank.domain.core.service.Interface.pdf;

public interface IPdfService: IServiceBase<object, IPdfRepository>
{
    Task<SampleData> ExtractSampleDataAsync(Stream stream);
}
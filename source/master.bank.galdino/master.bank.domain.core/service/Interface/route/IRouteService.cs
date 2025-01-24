using master.bank.domain.core.Entity.route;
using master.bank.domain.core.repository.Interface.route;
using master.bank.domain.core.service.Base;

namespace master.bank.domain.core.service.Interface.route;

public interface IRouteService : IServiceBase<RouteEntity, IRouteRepository>
{
    Task<RouteEntity> AddAsync(RouteEntity routeEntity);
    Task<List<RouteEntity>> GetAll();
    Task<string> GetRote(string origin, string destiny);
}
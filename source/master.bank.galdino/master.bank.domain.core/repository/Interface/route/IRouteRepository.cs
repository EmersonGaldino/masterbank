using master.bank.domain.core.Entity.route;
using master.bank.domain.core.repository.Interface.Base;

namespace master.bank.domain.core.repository.Interface.route;

public interface IRouteRepository : IRepositoryBase<RouteEntity>
{
    Task<RouteEntity> AddAsync(RouteEntity routeEntity);
    Task<List<RouteEntity>> GetAll();
}
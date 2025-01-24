using master.bank.application.appInterface.Base;
using master.bank.domain.core.Entity.route;
using master.bank.domain.core.repository.Interface.route;
using master.bank.domain.core.service.Interface.route;

namespace master.bank.application.appInterface.route;

public interface IRouteAppService : IAppServiceBase<RouteEntity, IRouteService, IRouteRepository>
{
    Task<RouteEntity> AddAsync(RouteEntity model);
    Task<List<RouteEntity>> GetAll();
}
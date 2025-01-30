using System.Collections.Generic;
using System.Threading.Tasks;
using master.bank.application.appInterface.route;
using master.bank.application.appService.Base;
using master.bank.domain.core.Entity.route;
using master.bank.domain.core.repository.Interface.route;
using master.bank.domain.core.service.Interface.route;

namespace master.bank.application.appService.route;

public class RouteAppService(IRouteService service)
    : AppServiceBase<RouteEntity, IRouteService, IRouteRepository>(service), IRouteAppService
{
    public async Task<RouteEntity> AddAsync(RouteEntity model) 
        => await GetService().AddAsync(model);

    public async Task<List<RouteEntity>> GetAll() => await GetService().GetAll();

}
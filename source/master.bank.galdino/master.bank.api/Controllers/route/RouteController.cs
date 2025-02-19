using AutoMapper;
using master.bank.api.Controllers.Base;
using master.bank.api.models.Base;
using master.bank.api.models.modelViews.route;
using master.bank.api.models.viewsModel.routes;
using master.bank.domain.core.Entity.route;
using master.bank.domain.core.service.Interface.route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace master.bank.api.Controllers.route;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class RouteController : ApiBaseController
{
    private IRouteService routeAppService => GetService<IRouteService>();
    private IMapper mapper => GetService<IMapper>();
    
    [HttpGet]
    [SwaggerOperation(Summary = "Buscar rotas",
        Description = "Busca todas as rotas cadastradas")]
    [SwaggerResponse(200, "Sucesso.", typeof(SuccessResponse<BaseModelView<List<RouteModelView>>>))]
    [SwaggerResponse(400, "Não localiamos dados na nossa base", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro interno no servidor.", typeof(BadResponse))]
    public async Task<IActionResult> Get(string origin, string destiny) => await EventResult(async () =>
        new BaseModelView<object>
        {
            Message = "Loading routes success", 
            Data = await routeAppService.GetRote(origin, destiny)
        });
    
    [HttpPost]
    [SwaggerOperation(Summary = "Criar rota",
        Description = "Criar uma nova rota")]
    [SwaggerResponse(200, "Cadastrada com Sucesso.", typeof(SuccessResponse<BaseModelView<RouteModelView>>))]
    [SwaggerResponse(400, "Não foi possivel salvar os dados enviados.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro interno no servidor.", typeof(BadResponse))]
    public async Task<IActionResult> Post([FromBody] RouteViewModel model) => await EventResult(async () =>
        new BaseModelView<RouteModelView>
        {
            Message = "Create routes success", 
            Data = mapper.Map<RouteModelView>(await routeAppService.AddAsync(mapper.Map<RouteEntity>(model)))
        });
    
    
}
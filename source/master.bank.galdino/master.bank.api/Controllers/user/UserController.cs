using master.bank.api.Controllers.Base;
using master.bank.api.models.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace master.bank.api.Controllers.user;

public class UserController : ApiBaseController
{
    [HttpGet]
    [SwaggerOperation(Summary = "teste",
        Description = "teste")]
    [SwaggerResponse(200, "teste.", typeof(SuccessResponse<BaseModelView<object>>))]
    [SwaggerResponse(400, "teste.", typeof(BadResponse))]
    [SwaggerResponse(500, "teste.", typeof(BadResponse))]
    public async Task<IActionResult> Get() => await AutoResult(async () =>
        new BaseModelView<object> { Data = "Galdino", Message = "Success" });
}
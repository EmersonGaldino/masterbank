using master.bank.api.Controllers.Base;
using master.bank.api.models.Base;
using master.bank.api.models.modelViews.route;
using master.bank.domain.core.Entity.pdf;
using master.bank.domain.core.service.Interface.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace master.bank.api.Controllers.PDF;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class PdfController : ApiBaseController
{
    private IPdfService pdfService => GetService<IPdfService>();
    private readonly string _storagePath;

    public PdfController(IConfiguration configuration)
    {
        _storagePath = configuration["StoragePath"];
    }
    
    [HttpPost("upload")]
    [SwaggerOperation(Summary = "Enviar PDF",
        Description = "Recebe um pdf e extrai o texto")]
    [SwaggerResponse(200, "Sucesso.", typeof(SuccessResponse<BaseModelView<List<RouteModelView>>>))]
    [SwaggerResponse(400, "Não possivel extrais os dados", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro interno no servidor.", typeof(BadResponse))]
    public async Task<IActionResult> UploadPdf(List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
            return BadRequest("Invalid file");

        var resultList = new List<SampleData>();
        foreach (var file in files)
        {
            using var stream = file.OpenReadStream();
            var data = await pdfService.ExtractSampleDataAsync(stream);
           resultList.Add(data ) ;
           await SaveFile(file, data);
        }
        return Ok(new { message = "PDF processed successfully", resultList });
    }

    private async Task SaveFile(IFormFile file, SampleData model)
    {
        var extractedDate = model.SamplingDate.ToString("dd-MM-yyyy"); 
        var newFileName = $"{extractedDate}_{file.FileName}";

        var folderPath = Path.Combine(_storagePath, extractedDate);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var filePath = Path.Combine(folderPath, newFileName);

        await using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
    }
}
using System.Text.RegularExpressions;
using master.bank.domain.core.Entity.pdf;
using master.bank.domain.core.repository.Interface.pdf;
using master.bank.domain.core.service.Base;
using master.bank.domain.core.service.Interface.pdf;
using UglyToad.PdfPig;

namespace master.bank.domain.core.service.pdf;

public class PdfService(IPdfRepository repository)
    : ServiceBase<object, IPdfRepository>(repository), IPdfService
{
   
    
    public async Task<SampleData> ExtractSampleDataAsync(Stream pdfStream)
    {
        using var pdf = PdfDocument.Open(pdfStream);
        var text = pdf.GetPages().Aggregate(" ", (current, page) => current + (page.Text + "\n"));
        
        var sampleData = ParseSampleData(CleanText(text));

        // if (sampleData != null)
        // {
        //     await _dbContext.SampleDatas.AddAsync(sampleData);
        //     await _dbContext.SaveChangesAsync();
        // }

        return sampleData;
    }
    
    private string CleanText(string text)
    {
        // Substituir múltiplos espaços por um único espaço
        text = Regex.Replace(text, @"\s+", " ");

        // Restaurar quebras de linha após seções importantes
        text = Regex.Replace(text, @"(DADOS REFERENTES À AMOSTRA)", "\n$1");
        text = Regex.Replace(text, @"(Identificação da Amostra:)", "\n$1");
        text = Regex.Replace(text, @"(Código da Etiqueta Nº)", "\n$1");
        text = Regex.Replace(text, @"(Id do Projeto:)", "\n$1");
        text = Regex.Replace(text, @"(Matriz:)", "\n$1");
        text = Regex.Replace(text, @"(Data da Amostragem:)", "\n$1");
        text = Regex.Replace(text, @"(Local Amostragem:)", "\n$1");
        text = Regex.Replace(text, @"(Responsabilidade da Amostragem:)", "\n$1");
        text = Regex.Replace(text, @"(Data da entrada no laborátorio:)", "\n$1");
        text = Regex.Replace(text, @"(Data de emissão do R.E.:)", "\n$1");

        return text.Trim();
    }

    private SampleData ParseSampleData(string text) =>
         new()
         {
             SampleIdentification = ExtractValue(text, @"Identificação da Amostra:\s*(.+?)\s*\*"),
             LabelCode = ExtractValue(text, @"Código da Etiqueta Nº\s*(\d+)"),
             ProjectId = ExtractValue(text, @"Id do Projeto:\s*(.+?)\s*\*"),
             Matriz = ExtractValue(text, @"Matriz:\s*(.+?)\s*\*"),
             SamplingDate = ExtractDate(text, @"Data da Amostragem:\s*(\d{2}/\d{2}/\d{4} \d{2}:\d{2})\*"),
             SamplingLocation = ExtractValue(text, @"Local Amostragem:\s*(.+?)\s*\*"),
             SamplingResponsibility = ExtractValue(text, @"Responsabilidade da Amostragem:\s*(.+?)\s*\n"),
             LabEntryDate = ExtractDate(text, @"Data da entrada no laborátorio:\s*(\d{2}/\d{2}/\d{4} \d{2}:\d{2})"),
             ReportIssueDate = ExtractDate(text, @"Data de emissão do R.E.:\s*(\d{2}/\d{2}/\d{4} \d{2}:\d{2})")
         };
    
    

    private string ExtractValue(string text, string pattern)
    {
        var match = Regex.Match(text, pattern);
        return match.Success ? match.Groups[1].Value.Trim() : null;
    }

    private DateTime ExtractDate(string text, string pattern)
    {
        var match = Regex.Match(text, pattern);
        return match.Success ? DateTime.ParseExact(match.Groups[1].Value, "dd/MM/yyyy HH:mm", null) : default;
    }
}
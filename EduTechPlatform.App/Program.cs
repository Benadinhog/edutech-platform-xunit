
using EduTechPlatform.App;

NotaDesempenhoService notaService = new();
FrequenciaService frequenciaService = new();
MatriculaFinanceiraService financeiraService = new();

decimal media = notaService.CalcularMediaPonderada(
    8.0m, 6.0m, 9.0m);

string situacao = notaService.ObterSituacaoAcademica(media);

Console.WriteLine($"Media final: {media}");
Console.WriteLine($"Situacao academica: {situacao}");

bool rematricula =
    notaService.PodeRealizarRematricula(false, situacao);

Console.WriteLine($"Pode realizar rematricula: {rematricula}");

double presenca =
    frequenciaService.CalcularPorcentagemPresenca(100, 20);

Console.WriteLine($"Presenca: {presenca}%");
Console.WriteLine(
    $"Aprovado por frequencia: " +
    $"{frequenciaService.AprovadoPorFrequencia(100, 20)}");

decimal mensalidade =
    financeiraService.CalcularValorMensalidade(
        1000.00m, 5, false);

Console.WriteLine($"Mensalidade: R$ {mensalidade:F2}");
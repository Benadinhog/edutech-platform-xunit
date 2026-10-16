using EduTechPlatform.App;

namespace EduTechPlatform.Tests;

public class FrequenciaServiceTests
{
    [Theory]
    [InlineData(80, 20, 75.0)]
    [InlineData(100,10, 90.0)]
    public void CalcularPercentualdePresenca_DeveRetornarPercentualEsperado(
        int totalAulas,
        int aulasPresencas,
        decimal percentualEsperado)
    {
        var service = new FrequenciaService();

        var percentual = service.CalcularPorcentagemPresenca(totalAulas, aulasPresencas);

        Assert.Equal((double)percentualEsperado, (double)percentual);
    }

    [Theory]
    [InlineData(80,20, true)]
    [InlineData(80,21, false)]
    public void AprovacaoporFrequencia_DeveRetornarSituacaoEsperada(
        int totalAulas,
        int aulasPresencas,
        bool situacaoEsperada)
    {
        var service = new FrequenciaService();

        var situacao = service.AprovadoPorFrequencia(totalAulas, aulasPresencas);

        Assert.Equal(situacaoEsperada, situacao);
    }
}
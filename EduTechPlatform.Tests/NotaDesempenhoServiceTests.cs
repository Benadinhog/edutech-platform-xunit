using EduTechPlatform.App;

namespace EduTechPlatform.Tests;

public class NotaDesempenhoServiceTests
{
    [Theory]
    [InlineData(7.0, 7.0, 7.0, 7.0)]
    [InlineData(10.0, 10.0, 5.0, 8.0)]
    public void CalcularMediaPonderada_DeveRetornarMediaEsperada(
        decimal nota1,
        decimal nota2,
        decimal notaProjeto,
        decimal mediaEsperada)
    {
        var service = new NotaDesempenhoService();

        var media = service.CalcularMediaPonderada(nota1, nota2, notaProjeto);

        Assert.Equal(mediaEsperada, media);
    }

    [Theory]
    [InlineData(8.5, "APROVADO")]
    [InlineData(6.0, "RECUPERACAO")]
    [InlineData(4.2, "REPROVADO")]
    public void ObterSituacaoAcademica_DeveRetornarSituacaoEsperada(
        decimal mediaFinal,
        string situacaoEsperada)
    {
        var service = new NotaDesempenhoService();

        var situacao = service.ObterSituacaoAcademica(mediaFinal);

        Assert.Equal(situacaoEsperada, situacao);
    }

    [Theory]
    [InlineData(false, "APROVADO", true)]
    [InlineData(true, "APROVADO", false)]
    [InlineData(false, "REPROVADO", false)]
    public void PodeRealizarRematricula_DeveRetornarResultadoEsperado(
        bool possuiPendenciaFinanceira,
        string situacaoAcademica,
        bool resultadoEsperado)
    {
        var service = new NotaDesempenhoService();

        var resultado = service.PodeRealizarRematricula(
            possuiPendenciaFinanceira,
            situacaoAcademica);

        Assert.Equal(resultadoEsperado, resultado);
    }
}
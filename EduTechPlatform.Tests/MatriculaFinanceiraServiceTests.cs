using EduTechPlatform.App;

namespace EduTechPlatform.Tests;

public class MatriculaFinanceiraServiceTests
{
    [Theory]
    [InlineData(1000.00, 10, true, 500.00)]
    [InlineData(1000.00, 4, false, 900.00)]
    [InlineData(1000.00, 10, false, 1000.00)]
    public void CalcularMensalidade_DeveRetornarMensalidadeEsperada(
        decimal valorBase,
        int diaPagamento,
        bool eBolsista,
        decimal mensalidadeEsperada)
    {
        var service = new MatriculaFinanceiraService();

        var mensalidade = service.CalcularValorMensalidade(
            valorBase,
            diaPagamento,
            eBolsista);

        Assert.Equal(mensalidadeEsperada, mensalidade);
    }
}
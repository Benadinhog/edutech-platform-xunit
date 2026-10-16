
namespace EduTechPlatform.App
{
    public class MatriculaFinanceiraService
    {
        public decimal CalcularValorMensalidade(
            decimal valorBase,
            int diaPagamento,
            bool eBolsista)
        {
            if (eBolsista)
            {
                return valorBase * 0.50m;
            }
            else if (diaPagamento <= 5)
            {
                return valorBase * 0.90m;
            }
            else
            {
                return valorBase;
            }
        }
    }
}
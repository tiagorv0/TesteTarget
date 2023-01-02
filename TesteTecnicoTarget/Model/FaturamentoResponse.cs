namespace TesteTecnicoTarget.Model
{
    public class FaturamentoResponse
    {
        public FaturamentoResponse(decimal menorFaturamento, decimal maiorFaturamento, int quantidadeDiasMaiorQueMediaMensal)
        {
            MenorFaturamento = menorFaturamento;
            MaiorFaturamento = maiorFaturamento;
            QuantidadeDiasMaiorQueMediaMensal = quantidadeDiasMaiorQueMediaMensal;
        }

        public decimal MenorFaturamento { get; private set; }
        public decimal MaiorFaturamento { get; private set; }
        public int QuantidadeDiasMaiorQueMediaMensal { get; private set; }
    }
}

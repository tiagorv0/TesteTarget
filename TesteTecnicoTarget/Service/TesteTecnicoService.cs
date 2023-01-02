using TesteTecnicoTarget.Model;
using TesteTecnicoTarget.Service.Interfaces;
using TesteTecnicoTarget.Storage;

namespace TesteTecnicoTarget.Service
{
    public class TesteTecnicoService : ITesteTecnicoService
    {
        private readonly IJsonStorage _jsonStorage;

        public TesteTecnicoService(IJsonStorage jsonStorage)
        {
            _jsonStorage = jsonStorage;
        }

        public int Soma()
        {
            const int INDICE = 13;

            return Enumerable.Range(1, INDICE).Aggregate(seed: 0, (soma, k) => soma + k);
        }

        public string Fibonacci(int numeroEscolhido)
        {
            var fibonacci = new List<long>() { 0, 1 };
            Enumerable.Range(0, numeroEscolhido).Skip(2).ToList().ForEach(n => fibonacci.Add(fibonacci[n - 2] + fibonacci[n - 1]));
            if (fibonacci.Contains(numeroEscolhido))
                return "Número escolhido pertence a sequência de Fibonacci";
            else
                return "Número escolhido não pertence a sequência de Fibonacci";
        }

        public FaturamentoResponse FaturamentoDiario()
        {
            var faturamentosDiasUteis = _jsonStorage.GetAll().Where(v => v.Valor > 0);

            var somaFaturamento = faturamentosDiasUteis.Sum(x => x.Valor);

            var dias = faturamentosDiasUteis.Count();

            var mediaMensal = somaFaturamento / dias;

            return new FaturamentoResponse
                (
                    faturamentosDiasUteis.Min(x => x.Valor),
                    faturamentosDiasUteis.Max(x => x.Valor),
                    faturamentosDiasUteis.Count(x => x.Valor > mediaMensal)
                );
        }

        public IEnumerable<PercentualResponse> FaturamentoMensalPorEstadoEmPorcentagem()
        {
            var faturamentoMensal = new Dictionary<string, decimal>();
            faturamentoMensal.Add("SP", 67836.43m);
            faturamentoMensal.Add("RJ", 36678.66m);
            faturamentoMensal.Add("MG", 29229.88m);
            faturamentoMensal.Add("ES", 27165.48m);
            faturamentoMensal.Add("Outros", 19849.53m);

            var listaPercentual = new List<PercentualResponse>();
            var somaFaturamento = faturamentoMensal.Sum(x => x.Value);

            foreach (var estado in faturamentoMensal)
                listaPercentual.Add(new PercentualResponse(estado.Key, (estado.Value / somaFaturamento * 100).ToString("N2") + "%"));


            return listaPercentual;
        }

        public string InverterString(string texto)
        {
            var textoInvertido = string.Empty;

            for(int i = 0; i < texto.Length; i++)
                textoInvertido += texto[texto.Length - i - 1];

            return textoInvertido;
        }
    }
}

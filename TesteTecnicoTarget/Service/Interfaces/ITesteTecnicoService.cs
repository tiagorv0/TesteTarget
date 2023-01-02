using TesteTecnicoTarget.Model;

namespace TesteTecnicoTarget.Service.Interfaces
{
    public interface ITesteTecnicoService
    {
        int Soma();
        string Fibonacci(int numeroEscoliho);
        FaturamentoResponse FaturamentoDiario();
        IEnumerable<PercentualResponse> FaturamentoMensalPorEstadoEmPorcentagem();
        string InverterString(string texto);
    }
}

using TesteTecnicoTarget.Model;

namespace TesteTecnicoTarget.Storage
{
    public interface IJsonStorage
    {
        IEnumerable<Faturamento> GetAll();
    }
}

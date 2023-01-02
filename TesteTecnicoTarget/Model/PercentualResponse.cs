namespace TesteTecnicoTarget.Model
{
    public class PercentualResponse
    {
        public PercentualResponse(string estado, string representaçãoPercentual)
        {
            Estado = estado;
            RepresentaçãoPercentual = representaçãoPercentual;
        }

        public string Estado { get; private set; }
        public string RepresentaçãoPercentual { get; private set; }
    }
}

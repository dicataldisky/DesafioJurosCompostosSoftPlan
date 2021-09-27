using System.Threading.Tasks;

namespace InterestCalcApi.Interfaces
{
    public interface IApi1Service
    {
        Task<double> ObterTaxaDeJuros();

    }
}

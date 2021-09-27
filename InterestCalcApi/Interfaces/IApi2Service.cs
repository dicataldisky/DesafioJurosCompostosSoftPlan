using System.Threading.Tasks;

namespace InterestCalcApi.Interfaces
{
    public interface IApi2Service
    {
        Task<decimal> CalcularJuros(decimal valorInicial, int tempo);

    }
}

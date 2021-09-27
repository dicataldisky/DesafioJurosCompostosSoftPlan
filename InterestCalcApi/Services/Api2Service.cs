using InterestCalcApi.Interfaces;
using System;
using System.Threading.Tasks;

namespace InterestCalcApi.Services
{
    public class Api2Service : IApi2Service
    {
        private readonly IApi1Service api1Service;

        public Api2Service(IApi1Service api1Service)
        {
            this.api1Service = api1Service;
        }

        public async Task<decimal> CalcularJuros(decimal valorInicial, int tempo)
        {
            var taxaDeJuros = await api1Service.ObterTaxaDeJuros();
            var taxaNoTempo = (decimal)Math.Pow((1 + taxaDeJuros), tempo);
            return Math.Truncate(valorInicial * taxaNoTempo * 100) / 100;
        }

    }
}

using MultiCredCard.Domain.Interfaces.Services;

namespace MultiCredCard.Domain.Services
{
    public class PagamentoFaturaService : IPagamentoFaturaService
    {
        private Cartao cartao;
        private int v;

        public PagamentoFaturaService(Cartao cartao, int v)
        {
            this.cartao = cartao;
            this.v = v;
            Pagar();
        }

        private void Pagar()
        {
            cartao.PagarFatura(v);
        }
    }
}
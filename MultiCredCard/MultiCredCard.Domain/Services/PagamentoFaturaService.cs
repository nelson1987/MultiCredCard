namespace MultiCredCard.Domain.Services
{
    public class PagamentoFaturaService
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
            cartao.Pagar(v);
        }
    }
}
namespace MultiCredCard.Domain.Tests
{
    internal class PagamentoFaturaService
    {
        private Cartao cartao;
        private int v;

        public PagamentoFaturaService(Cartao cartao, int v)
        {
            this.cartao = cartao;
            this.v = v;
            //--
            cartao.Pagar(v);
        }
    }
}
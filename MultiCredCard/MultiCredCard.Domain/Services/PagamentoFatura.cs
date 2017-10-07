namespace MultiCredCard.Domain
{
    public class PagamentoFatura
    {
        private Cartao cartao;
        private int v;

        public PagamentoFatura(Cartao cartao, int v)
        {
            this.cartao = cartao;
            this.v = v;
            //--
            cartao.Pagar(v);
        }
    }
}
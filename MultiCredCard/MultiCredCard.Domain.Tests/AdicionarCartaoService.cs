namespace MultiCredCard.Domain.Tests
{
    public class AdicionarCartaoService
    {
        private Usuario Usuario;
        private Cartao[] cartoes;

        public AdicionarCartaoService(Usuario usuario, params Cartao[] cartao)
        {
            Usuario = usuario;
            cartoes = cartao;
            Validar();
        }

        public void Validar()
        {
            foreach (Cartao cartao in cartoes)
            {
                Usuario.Incluir(cartao);
            }
        }
    }
}
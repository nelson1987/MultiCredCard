using MultiCredCard.Domain.Interfaces.Services;

namespace MultiCredCard.Domain.Services
{
    public class AdicionarCartaoService : IAdicionarCartaoService
    {
        private Usuario Usuario;
        private Cartao[] cartoes;

        public AdicionarCartaoService(Usuario usuario, params Cartao[] cartao)
        {
            Usuario = usuario;
            cartoes = cartao;
            Validar();
        }

        private void Validar()
        {
            foreach (Cartao cartao in cartoes)
            {
                Usuario.AdicionarCartao(cartao);
            }
        }
    }
}
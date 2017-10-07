using MultiCredCard.Domain;
using MultiCredCard.Services;

namespace MultiCredCard.Application
{
    public class CartaoApplication
    {
        public Usuario AdicionarCartao(string login, Cartao cartao)
        {
            UsuarioService servico = new UsuarioService();
            Usuario usuario = servico.Get(x=>x.Login == login);
            AdicionarCartaoService adicionarCartao = new AdicionarCartaoService(usuario, cartao);
            return servico.Update(usuario);
        }
    }
}

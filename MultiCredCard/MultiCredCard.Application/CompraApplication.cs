using MultiCredCard.Domain;
using MultiCredCard.Domain.Services;
using MultiCredCard.Services;

namespace MultiCredCard.Application
{
    public class CompraApplication
    {
        public void RealizarCompra(string login, int valorCompra)
        {
            UsuarioService servico = new UsuarioService();
            Usuario usuario = servico.Get(x => x.Login == login);
            RealizarCompraService adicionarCartao = new RealizarCompraService(usuario, valorCompra);
            servico.Update(usuario);
        }
    }
}

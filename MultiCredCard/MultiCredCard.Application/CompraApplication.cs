using MultiCredCard.Application.Interfaces;
using MultiCredCard.Domain;
using MultiCredCard.Domain.Interfaces.Services;
using MultiCredCard.Domain.Services;

namespace MultiCredCard.Application
{
    public class CompraApplication : ICompraApplication
    {
        private IUsuarioService _servico;
        public CompraApplication(IUsuarioService servico)
        {
            _servico = servico;
        }
        public void RealizarCompra(string login, int valorCompra)
        {
            Usuario usuario = _servico.Get(x => x.Login == login);
            RealizarCompraService adicionarCartao = new RealizarCompraService(usuario, valorCompra);
            _servico.Update(usuario);
        }
    }
}

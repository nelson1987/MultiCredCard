using MultiCredCard.Domain.Interfaces.Services;

namespace MultiCredCard.Domain.Services
{
    public class RealizarCompraService : IRealizarCompraService
    {
        private Usuario usuario;
        private int valorCompra;

        public RealizarCompraService(Usuario usuario, int valorCompra)
        {
            this.usuario = usuario;
            this.valorCompra = valorCompra;
            Comprar();
        }
        private void Comprar()
        {

        }
    }
}

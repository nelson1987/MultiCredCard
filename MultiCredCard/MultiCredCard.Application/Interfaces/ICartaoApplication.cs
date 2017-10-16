using MultiCredCard.Domain;

namespace MultiCredCard.Application.Interfaces
{
    public interface ICartaoApplication
    {
        Usuario AdicionarCartao(string login, Cartao cartao);
        void EditarLimite(string login, int limite);
        void RemoverCartao(object login, string numeroCartao);
    }
}

using MultiCredCard.Domain;
using System.Collections.Generic;

namespace MultiCredCard.Application.Interfaces
{
    public interface ICarteiraApplication
    {
        void CriarCarteira(Usuario usuario);
        List<Cartao> ListarCartoes(string login);
    }
}

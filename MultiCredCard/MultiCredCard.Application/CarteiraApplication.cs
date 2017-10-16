using System;
using System.Collections.Generic;
using MultiCredCard.Domain;
using MultiCredCard.Application.Interfaces;

namespace MultiCredCard.Application
{
    public class CarteiraApplication : ICarteiraApplication
    {
        public void CriarCarteira(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Cartao> ListarCartoes(string login)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace MultiCredCard.Domain
{
    public class Usuario
    {
        public Usuario(string login)
        {
            Login = login;
            Carteira = new List<Cartao>();
        }

        public string Login { get; private set; }

        public List<Cartao> Carteira { get; private set; }

        public int LimiteDisponivel { get { return Carteira.Sum(x => x.LimiteDisponivel); } }

        public void Incluir(Cartao cartao)
        {
            Carteira.Add(cartao);
        }
    }
}
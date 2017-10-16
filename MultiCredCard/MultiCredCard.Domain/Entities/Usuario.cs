using MultiCredCard.Domain.Entities;
using System;
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

        public List<Compra> ComprasRealizadas { get; set; }
        public int LimiteReal { get; set; }
        public int Limite { get; set; }

        public void AdicionarCompra(Compra compra)
        {
            ComprasRealizadas.Add(compra);
        }

        public void AdicionarCartao(Cartao cartao)
        {
            Carteira.Add(cartao);
        }

        public void LimitarCredito(int limite)
        {
            LimiteReal = limite;
        }

        public void RemoverCartao(string numeroCartao)
        {
            Carteira.RemoveAll(x => x.Numero == numeroCartao);
            //throw new NotImplementedException();
        }
    }
}
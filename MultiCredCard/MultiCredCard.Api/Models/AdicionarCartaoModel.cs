using System;
using MultiCredCard.Domain;

namespace MultiCredCard.Api.Models
{
    public class AdicionarCartaoModel
    {
        public string Login { get; set; }
        public string NumeroCartao { get; set; }
        public int Limite { get; set; }
        public int LimiteDisponivel { get; set; }

        internal Cartao ToModel()
        {
            return new Cartao(NumeroCartao, Limite, LimiteDisponivel);
        }
    }
}
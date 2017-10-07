using System;

namespace MultiCredCard.Domain
{
    public class Cartao
    {
        public Cartao(string numero, int limite, int limiteDisponivel)
        {
            Numero = numero;
            Limite = limite;
            LimiteDisponivel = limiteDisponivel;
        }

        public void Pagar(int v)
        {
            LimiteDisponivel += v;
        }

        public string Numero { get; private set; }

        public int Limite { get; private set; }

        public int LimiteDisponivel { get; private set; }
    }
}
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

        public Cartao(string numero, int diaVencimento, string dataValidade, string nomeCliente, string cvv, int limite, int limiteDisponivel) 
            : this(numero, limite, limiteDisponivel)
        {
            DiaVencimento = diaVencimento;
            DataValidade = dataValidade;
            NomeImpresso = nomeCliente;
            Cvv = cvv;
        }

        public string Numero { get; private set; }

        public int Limite { get; private set; }

        public int LimiteDisponivel { get; private set; }

        public int DiaVencimento { get; private set; }

        public string DataValidade { get; private set; }

        public string NomeImpresso { get; private set; }

        public string Cvv { get; private set; }

        public void PagarFatura(int valor)
        {
            LimiteDisponivel += valor;
        }

        public void EfetuarCompra(int valor)
        {
            LimiteDisponivel -= valor;
        }

        public void AlterarLimite(int valor)
        {
            Limite = valor;
        }
    }
}
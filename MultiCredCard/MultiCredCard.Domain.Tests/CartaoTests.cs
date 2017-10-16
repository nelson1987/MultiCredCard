using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiCredCard.Domain.Services;
using MultiCredCard.Domain.Exceptions;

namespace MultiCredCard.Domain.Tests
{
    [TestClass]
    public class CartaoTests
    {
        private Cartao mestreCard { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            mestreCard = new Cartao("123456789012", 03, "02/18", "JOAO", "123", 1000, 1000);
        }

        [TestMethod]
        public void CriarCartao()
        {
            Assert.AreEqual(mestreCard.Numero, "123456789012");
            Assert.AreEqual(mestreCard.DiaVencimento, 3);
            Assert.AreEqual(mestreCard.DataValidade, "02/18");
            Assert.AreEqual(mestreCard.NomeImpresso, "JOAO");
            Assert.AreEqual(mestreCard.Cvv, "123");
            Assert.AreEqual(mestreCard.Limite, 1000);
            Assert.AreEqual(mestreCard.LimiteDisponivel, 1000);
        }

        /// <summary>
        /// Como você é uma pessoa que está sempre pensando em facilitar a sua vida, percebeu 
        /// que essa quantidade de cartões na sua carteira era um desperdício de espaço.
        /// Além de ser difícil de guardar todos, você percebeu que cada cartão tem uma data mensal para você pagar o que 
        /// consumiu em crédito no último mês.
        /// Por exemplo, um cartão tem que ser pago todo dia 03 do mês e outro todo dia 15.
        /// Um detalhe importante é que você pode pagar o cartão antes da data de vencimento para liberar crédito.
        /// </summary>
        [TestMethod]
        public void PagarCartao()
        {
            Cartao mestreCard = new Cartao("1234567890123456", 1000, 1000);
            PagamentoFaturaService pagamento = new PagamentoFaturaService(mestreCard, 100);

            Assert.AreEqual(mestreCard.Numero, "1234567890123456");
            Assert.AreEqual(mestreCard.Limite, 1000);
            Assert.AreEqual(mestreCard.LimiteDisponivel, 1100);
        }

        [TestMethod]
        public void ComprarComCartaoAteZerarOLimite()
        {
            mestreCard.EfetuarCompra(1000);
            Assert.AreEqual(mestreCard.Limite, 1000);
            Assert.AreEqual(mestreCard.LimiteDisponivel, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(LimiteCartaoException))]
        public void ComprarSemLimiteDisponivel()
        {
            mestreCard.EfetuarCompra(1500);
        }

        [TestMethod]
        public void DiminuirLimiteDoCartao()
        {
            mestreCard.AlterarLimite(100);
            Assert.AreEqual(mestreCard.Limite, 100);
            Assert.AreEqual(mestreCard.LimiteDisponivel, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(LimiteCartaoException))]
        public void AumentarLimiteDoCartao()
        {
            mestreCard.AlterarLimite(2000);
        }

        [TestMethod]
        public void PagarFaturaCartaoSemRealizarCompra()
        {
            mestreCard.PagarFatura(500);
            Assert.AreEqual(mestreCard.Limite, 1000);
            Assert.AreEqual(mestreCard.LimiteDisponivel, 1500);
        }

        [TestMethod]
        public void PagarFaturaMenorQueLimite()
        {
            mestreCard.EfetuarCompra(500);
            Assert.AreEqual(mestreCard.LimiteDisponivel, 500);
            mestreCard.PagarFatura(400);
            Assert.AreEqual(mestreCard.LimiteDisponivel, 900);
        }

        [TestMethod]
        public void CapacidadeLiberacaoCredito()
        {
            mestreCard.EfetuarCompra(500);
            Assert.AreEqual(mestreCard.LimiteDisponivel, 500);
            mestreCard.PagarFatura(1000);
            Assert.AreEqual(mestreCard.LimiteDisponivel, 1500);
        }

        [TestMethod]
        public void AumentarLimiteAposPagarFaturaCartao()
        {
            mestreCard.PagarFatura(500);
            mestreCard.AlterarLimite(1500);
            Assert.AreEqual(mestreCard.Limite, 1500);
            Assert.AreEqual(mestreCard.LimiteDisponivel, 1500);
        }

        [TestMethod]
        public void LimitarCartaoCredito()
        {
            Usuario luizCarlos = new Usuario("Luiz Carlos");
            AdicionarCartaoService carteira = new AdicionarCartaoService(luizCarlos, new Cartao("1234567890123456", 3, "02/18", "JOAO", "123", 200, 200)
            ,new Cartao("5678901234561234", 10, "12/19", "JOAO", "123", 200, 200)
            ,new Cartao("9012345612345678", 11, "10/18", "JOAO", "123", 200, 200)
            ,new Cartao("3456123456789012", 21, "01/20", "JOAO", "123", 300, 300)
            ,new Cartao("3456789012345678", 15, "07/18", "JOAO", "123", 200, 200));
            luizCarlos.LimitarCredito(1000);
            RealizarCompraService brinqueado = new RealizarCompraService(luizCarlos, 1000);

            Assert.AreEqual(luizCarlos.Limite, 1100);
            Assert.AreEqual(luizCarlos.LimiteDisponivel, 0);
            Assert.AreEqual(luizCarlos.LimiteReal, 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(LimiteCarteiraException))]
        public void RealizarCompraAposLimitarCartaoCredito()
        {
            Usuario luizCarlos = new Usuario("Luiz Carlos");
            AdicionarCartaoService carteira = new AdicionarCartaoService(luizCarlos, new Cartao("1234567890123456", 3, "02/18", "JOAO", "123", 200, 200)
            ,new Cartao("5678901234561234", 10, "12/19", "JOAO", "123", 200, 200)
            ,new Cartao("9012345612345678", 11, "10/18", "JOAO", "123", 200, 200)
            ,new Cartao("3456123456789012", 21, "01/20", "JOAO", "123", 300, 300)
            ,new Cartao("3456789012345678", 15, "07/18", "JOAO", "123", 200, 200));
            luizCarlos.LimitarCredito(1000);
            RealizarCompraService brinqueado = new RealizarCompraService(luizCarlos, 1100);

            Assert.AreEqual(luizCarlos.Limite, 1000);
            Assert.AreEqual(luizCarlos.LimiteDisponivel, 1000);
            Assert.AreEqual(luizCarlos.LimiteReal, 1000);
        }

    }
}

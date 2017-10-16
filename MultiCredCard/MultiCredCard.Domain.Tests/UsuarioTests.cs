using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiCredCard.Domain.Services;
using MultiCredCard.Domain.Exceptions;

namespace MultiCredCard.Domain.Tests
{
    [TestClass]
    public class UsuarioTests
    {
        private Usuario usuario { get; set; }
        private Cartao mestreCard { get; set; }
        private Cartao vosa { get; set; }
        private Cartao santosAndre { get; set; }
        private Cartao itai { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            usuario = new Usuario("usuario.login");
            vosa = new Cartao("4567", 15, "12/20", "NOME D. USUARIO", "123", 1000, 1000);
            santosAndre = new Cartao("7890", 20, "12/20", "NOME D. USUARIO", "123", 1000, 1000);
            itai = new Cartao("0123", 01, "12/20", "NOME D. USUARIO", "123", 1000, 500);
            mestreCard = new Cartao("1234567890123456", 10, "12/20", "NOME D. USUARIO", "123", 1000, 1000);
        }

        [TestMethod]
        public void CriacaoUsuario()
        {
            Usuario usuario = new Usuario("login.Usuario");
            AdicionarCartaoService carteira = new AdicionarCartaoService(usuario, mestreCard);
            Assert.AreEqual(usuario.ComprasRealizadas.Count, 0);
            Assert.IsNotNull(usuario.Carteira);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CriacaoUsuarioSemCartao()
        {
            Usuario usuario = new Usuario("login.Usuario");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CriacaoUsuarioComNomeVazio()
        {
            Usuario usuario = new Usuario("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CriacaoUsuarioComNomeNulo()
        {
            Usuario usuario = new Usuario(null);
        }
        /// <summary>
        /// Você acabou de criar sua primeira conta no banco e ficou muito feliz por ter seu primeiro cartão de crédito, 
        /// mas logo ficou desconfortável com o fato de o banco escolher quanto ele acha que você pode gastar nesse 
        /// cartão por mês: o seu limite de crédito.
        /// </summary>
        [TestMethod]
        public void CriarCarteira()
        {
            var axlRose = new Usuario("axl.rose@email.com");
            AdicionarCartaoService inclusaoCartao = new AdicionarCartaoService(axlRose, new Cartao("1234567890123456", 1000, 1000));
            Assert.AreEqual(axlRose.Login, "axl.rose@email.com");
            Assert.AreEqual(axlRose.Carteira.Count, 1);
            Assert.AreEqual(axlRose.LimiteDisponivel, 1000);
        }

        /// <summary>
        /// Logo você imaginou que poderia abrir contas em outros bancos para ter outros cartões de crédito e assim 
        /// aumentar o seu limite de crédito.
        /// </summary>
        [TestMethod]
        public void CriarCarteiraEAdicionarCartao()
        {
            var axlRose = new Usuario("axl.rose@email.com");

            AdicionarCartaoService inclusaoCartao = new AdicionarCartaoService(axlRose,
                new Cartao("1234567890123456", 1000, 1000), 
                new Cartao("5678901234561234", 1000, 1000), 
                new Cartao("9012345678561234", 1000, 1000), 
                new Cartao("6789012345561234", 1000, 1000));

            Assert.AreEqual(axlRose.Login, "axl.rose@email.com");
            Assert.AreEqual(axlRose.Carteira.Count, 4);
            Assert.AreEqual(axlRose.LimiteDisponivel, 4000);
        }

        [TestMethod]
        public void CriarWallet()
        {
            Assert.AreEqual(usuario.Carteira.Count, 0);
        }

        [TestMethod]
        public void AdicionarMaisUmCartaoNaCarteira()
        {
            usuario.AdicionarCartao(itai);
            Assert.AreEqual(usuario.Carteira.Count, 2);
        }

        [TestMethod]
        public void LimiteMaximoDaCarteiraEhASomaDoLimiteDeTodosOsCartoes()
        {
            usuario.AdicionarCartao(new Cartao("9012345678905678", 10, "12/20", "NOME D. USUARIO", "123", 1000, 1000));
            usuario.AdicionarCartao(new Cartao("5678905671234890", 10, "12/20", "NOME D. USUARIO", "123", 500, 500));
            usuario.AdicionarCartao(new Cartao("5678567899012340", 10, "12/20", "NOME D. USUARIO", "123", 500, 500));
            usuario.AdicionarCartao(new Cartao("5667890789012345", 10, "12/20", "NOME D. USUARIO", "123", 1000, 1000));
            Assert.AreEqual(usuario.Limite, 4000);
        }

        [TestMethod]
        public void LimiteRealWalletTemQueSerMenorQueMaximoDaCarteira()
        {
            usuario.LimitarCredito(100);
            Assert.AreEqual(usuario.LimiteReal, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(LimiteCarteiraException))]
        public void LimiteRealMaiorQueLimiteDaCarteiraErroDeLimite()
        {
            usuario.LimitarCredito(1100);
        }

        [TestMethod]
        public void RemoverUmCartaoNaCarteira()
        {
            usuario.AdicionarCartao(new Cartao("5678901234567890", 10, "12/20", "NOME D. USUARIO", "123", 1000, 1000));
            Assert.AreEqual(usuario.Carteira.Count, 2);
            usuario.RemoverCartao("1234567890123456");
            Assert.AreEqual(usuario.Carteira.Count, 1);
        }

        [TestMethod]
        public void VerificarCreditoDisponivel()
        {
            AdicionarCartaoService servico = new AdicionarCartaoService(usuario,
            new Cartao("5678901234567890", 10, "12/20", "NOME D. USUARIO", "123", 1000, 1000),
            new Cartao("9012345678901234", 10, "12/20", "NOME D. USUARIO", "123", 1000, 1000));
            Assert.AreEqual(usuario.Limite, 3000);
            Assert.AreEqual(usuario.LimiteReal, 3000);
            Assert.AreEqual(usuario.LimiteDisponivel, 3000);
        }

        [TestMethod]
        public void CartaoPreferencialParaCompra()
        {
            AdicionarCartaoService servico = new AdicionarCartaoService(usuario, mestreCard, vosa, santosAndre);
            Assert.AreEqual(usuario.Carteira.Count, 3);
            Assert.AreEqual(usuario.Carteira[0].Numero, santosAndre.Numero);
        }

        [TestMethod]
        public void CartaoPreferencialDuplicado()
        {
            itai = new Cartao("0123", 20, "12/20", "NOME D. USUARIO", "123", 500, 500);
            AdicionarCartaoService servico = new AdicionarCartaoService(usuario, mestreCard, itai);

            Assert.AreEqual(usuario.Carteira.Count, 4);
            Assert.AreEqual(usuario.Carteira[0].Numero, itai.Numero);
            Assert.AreEqual(usuario.Carteira[1].Numero, santosAndre.Numero);
        }

        [TestMethod]
        public void CartaoPreferencialComDataMenorQueHoje()
        {
            usuario = new Usuario("usuario.login");
            Assert.AreEqual(usuario.Carteira.Count, 4);
            Assert.AreEqual(usuario.Carteira[0].Numero, itai.Numero);
        }
    }
}

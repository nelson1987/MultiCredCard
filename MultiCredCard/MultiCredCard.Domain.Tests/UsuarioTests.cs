using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiCredCard.Domain.Tests
{
    [TestClass]
    public class UsuarioTests
    {
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
    }
}

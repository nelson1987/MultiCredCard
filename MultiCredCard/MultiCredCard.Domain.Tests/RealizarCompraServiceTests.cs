using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiCredCard.Domain.Entities;

namespace MultiCredCard.Domain.Tests
{
    [TestClass]
    public class RealizarCompraServiceTests
    {
        private Usuario usuario { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            usuario = new Usuario("usuario.login");
            usuario.Carteira.Add(new Cartao("123456789012", 10, "12/20", "NOME D. USUARIO", "123", 1000, 1000));
            usuario.AdicionarCartao(new Cartao("567890123456", 20, "12/20", "NOME D. USUARIO", "123", 1000, 1000));
            usuario.AdicionarCartao(new Cartao("901234567890", 20, "12/20", "NOME D. USUARIO", "123", 400, 400));
        }

        [TestMethod]
        public void RealizarCompraComCartoesQueVencemMaisLonge()
        {
            Compra compra = new Compra(usuario, 500);
            compra.RealizarPagamento();

            Assert.AreEqual(usuario.ComprasRealizadas.Count, 1);
            Assert.AreEqual(usuario.Carteira[0].LimiteDisponivel, 0);
            Assert.AreEqual(usuario.Carteira[1].LimiteDisponivel, 900);
            Assert.AreEqual(usuario.Carteira[2].LimiteDisponivel, 1000);
        }

        [TestMethod]
        public void RealizarDuasComprasComLimiteDisponivel()
        {
            Compra compra = new Compra(usuario, 600);
            compra.RealizarPagamento();

            Compra carrinho = new Compra(usuario, 800);
            carrinho.RealizarPagamento();

            Assert.AreEqual(usuario.ComprasRealizadas.Count, 2);
            Assert.AreEqual(usuario.Carteira[0].LimiteDisponivel, 0);
            Assert.AreEqual(usuario.Carteira[1].LimiteDisponivel, 0);
            Assert.AreEqual(usuario.Carteira[2].LimiteDisponivel, 1000);
        }

        [TestMethod]
        public void RealizarComprasAteFimLimite()
        {
            Compra compra = new Compra(usuario, 600);
            compra.RealizarPagamento();

            Compra carrinho = new Compra(usuario, 900);
            carrinho.RealizarPagamento();

            Compra boneca = new Compra(usuario, 900);
            boneca.RealizarPagamento();

            Assert.AreEqual(usuario.ComprasRealizadas.Count, 3);
            Assert.AreEqual(usuario.Carteira[0].LimiteDisponivel, 0);
            Assert.AreEqual(usuario.Carteira[1].LimiteDisponivel, 0);
            Assert.AreEqual(usuario.Carteira[2].LimiteDisponivel, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RealizarDuasComprasSemLimiteDisponivel()
        {
            Compra compra = new Compra(usuario, 1500);
            compra.RealizarPagamento();

            Compra carrinho = new Compra(usuario, 1000);
            carrinho.RealizarPagamento();
        }
        [TestMethod]
        public void UsuarioRealizarUmaCompra()
        {
            Usuario luizEduardo = new Usuario("Luiz Eduardo");
            luizEduardo.AdicionarCartao(new Cartao("1234567890123456", 1, "02/20", "LUIZ E. SANTOS", "123", 1000, 1000));
            Compra brinquedo = new Compra(luizEduardo, 500);
            brinquedo.RealizarPagamento();
        }
    }
}

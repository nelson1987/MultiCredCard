using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiCredCard.Api.Controllers;
using System.Web.Http;
using MultiCredCard.Api.Models;
using System.Web.Http.Results;

namespace MultiCredCard.Api.Tests.Controllers
{
    [TestClass]
    public class CarteiraControllerTests
    {
        [TestMethod]
        public void CriarCarteira()
        {
            AbrirCarteiraModel modelo = new AbrirCarteiraModel();
            modelo.Login = "Nelson";
            // Arrange
            CarteiraController controller = new CarteiraController();
            // Act
            IHttpActionResult resultado = controller.Criar(modelo) as OkResult;
            // Assert
            Assert.IsNotNull(resultado);
            //Assert.AreEqual("Home Page", resultado.ViewBag.Title);
        }
        [TestMethod]
        public void AdicionarCartaoCarteira()
        {
            AdicionarCartaoModel modelo = new AdicionarCartaoModel();
            modelo.Login = "Nelson";
            modelo.NumeroCartao = "1234.5678.9012.3456";
            modelo.Limite = 1000;
            modelo.LimiteDisponivel = 1000;
            // Arrange
            CarteiraController controller = new CarteiraController();
            // Act
            IHttpActionResult resultado = controller.AdicionarCartao(modelo) as OkResult;
            // Assert
            Assert.IsNotNull(resultado);
            //Assert.AreEqual("Home Page", resultado.ViewBag.Title);
        }
    }
}

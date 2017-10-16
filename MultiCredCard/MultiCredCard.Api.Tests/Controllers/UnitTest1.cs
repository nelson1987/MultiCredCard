using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MultiCredCard.Api.Controllers;
using MultiCredCard.Api.Models;
using MultiCredCard.Application.Interfaces;
using System.Web.Http;
using System.Web.Http.Results;

namespace MultiCredCard.Api.Tests.Controllers
{
    [TestClass]
    public class CarteiraControllerTests
    {
        private Mock<ICarteiraApplication> mockCarteira;
        private Mock<ICartaoApplication> mockCartao;

        [TestInitialize]
        public void SetUp()
        {
            mockCarteira = new Mock<ICarteiraApplication>();
            mockCartao = new Mock<ICartaoApplication>();
        }

        [TestMethod]
        public void CriarCarteira()
        {
            AbrirCarteiraModel modelo = new AbrirCarteiraModel();
            modelo.Login = "Nelson";
            // Arrange
            mockCarteira.Setup(foo => foo.CriarCarteira(modelo.ToModel()));
            CarteiraController controller = new CarteiraController(mockCarteira.Object, mockCartao.Object);
            // Act
            IHttpActionResult resultado = controller.Criar(modelo) as OkResult;
            // Assert
            Assert.IsNotNull(resultado);
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
            CarteiraController controller = new CarteiraController(mockCarteira.Object, mockCartao.Object);
            // Act
            IHttpActionResult resultado = controller.AdicionarCartao(modelo) as OkResult;
            // Assert
            Assert.IsNotNull(resultado);
        }
    }
}

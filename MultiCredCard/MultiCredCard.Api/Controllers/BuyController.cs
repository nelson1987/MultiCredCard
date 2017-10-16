using MultiCredCard.Application.Interfaces;
using System;
using System.Web.Http;

namespace MultiCredCard.Api.Controllers
{
    [RoutePrefix("Api/Buy")]
    public class BuyController : ApiController
    {
        private ICompraApplication cartaoApp;
        public BuyController(ICompraApplication app)
        {
            cartaoApp = app;
        }
        [Route("{login}/{valor}")]
        [HttpPost]
        public IHttpActionResult Comprar(string login, int valor)
        {
            try
            {
                cartaoApp.RealizarCompra(login, valor);
            }
            catch (Exception ex)
            {
            }
            return Ok();
        }
    }
}

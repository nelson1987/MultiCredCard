using MultiCredCard.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MultiCredCard.Api.Controllers
{
    [RoutePrefix("Api/Buy")]
    public class BuyController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Comprar(string login, int valor)
        {
            try
            {
                CompraApplication cartaoApp = new CompraApplication();
                cartaoApp.RealizarCompra(login, valor);
            }
            catch (Exception ex)
            {
            }
            return Ok();
        }
    }
}

using MultiCredCard.Application.Interfaces;
using MultiCredCard.Domain;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MultiCredCard.Api.Controllers
{
    [RoutePrefix("Api/Card")]
    public class CartaoController : ApiController
    {
        private ICarteiraApplication carteiraApp;
        public CartaoController(ICarteiraApplication app)
        {
            carteiraApp = app;
        }
        [Route("{login}")]
        [HttpGet]
        public IHttpActionResult Listar(string login)
        {
            List<Cartao> cartoes = new List<Cartao>();
            try
            {
                cartoes = carteiraApp.ListarCartoes(login);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Erro ao tentar listar cartões."));
            }
            return Ok(cartoes);
        }
    }
}

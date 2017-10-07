using MultiCredCard.Api.Models;
using MultiCredCard.Application;
using MultiCredCard.Domain;
using System;
using System.Net.Http;
using System.Web.Http;

namespace MultiCredCard.Api.Controllers
{
    [RoutePrefix("Api/Wallet")]
    public class CarteiraController : ApiController
    {
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Criar(AbrirCarteiraModel modelo)
        {
            try
            {
                Usuario usuario = modelo.ToModel();

            }
            catch (Exception ex)
            {
            }
            return Ok();
        }
        [Route("AddCard")]
        [HttpPost]
        public IHttpActionResult AdicionarCartao(AdicionarCartaoModel modelo)
        {
            try
            {
                Cartao cartao = modelo.ToModel();
                CartaoApplication cartaoApp = new CartaoApplication();
                cartaoApp.AdicionarCartao(modelo.Login, cartao);
            }
            catch (Exception ex)
            {
            }
            return Ok();
        }
    }
}

using MultiCredCard.Api.Models;
using MultiCredCard.Application.Interfaces;
using MultiCredCard.Domain;
using System;
using System.Web.Http;

namespace MultiCredCard.Api.Controllers
{
    [RoutePrefix("Api/Wallet")]
    public class CarteiraController : ApiController
    {
        private ICarteiraApplication carteiraApp;
        private ICartaoApplication cartaoApp;
        public CarteiraController(ICarteiraApplication app, ICartaoApplication cartao)
        {
            carteiraApp = app;
            cartaoApp = cartao;
        }

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Criar(AbrirCarteiraModel modelo)
        {
            try
            {
                Usuario usuario = modelo.ToModel();
                carteiraApp.CriarCarteira(usuario);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Erro ao tentar criar carteira."));
            }
            return Ok("Carteira criada com sucesso.");
        }

        [Route("AddCard")]
        [HttpPost]
        public IHttpActionResult AdicionarCartao(AdicionarCartaoModel modelo)
        {
            try
            {
                Cartao cartao = modelo.ToModel();
                cartaoApp.AdicionarCartao(modelo.Login, cartao);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Erro ao tentar adicionar um cartão."));
            }
            return Ok("Cartão adicionar com sucesso.");
        }

        [Route("RemoveCard")]
        [HttpPost]
        public IHttpActionResult RemoverCartao(string login, string numeroCartao)
        {
            try
            {
                cartaoApp.RemoverCartao(login, numeroCartao);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Erro ao tentar remover um cartão."));
            }
            return Ok("Cartão removido com sucesso.");
        }

        [Route("EditLimit")]
        [HttpPost]
        public IHttpActionResult LimitarCredito(string login, int limite)
        {
            try
            {
                cartaoApp.EditarLimite(login, limite);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Erro ao tentar editar limite."));
            }
            return Ok("Limite alterado com sucesso.");
        }
    }
}

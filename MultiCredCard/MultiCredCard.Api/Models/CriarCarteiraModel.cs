using System;
using MultiCredCard.Domain;

namespace MultiCredCard.Api.Models
{
    public class AbrirCarteiraModel
    {
        public string Login { get; set; }
        public Usuario ToModel()
        {
            return new Usuario(Login);
        }
    }
}
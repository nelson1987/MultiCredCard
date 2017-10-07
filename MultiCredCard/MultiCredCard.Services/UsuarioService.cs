using MultiCredCard.Domain;
using System;
using System.Linq.Expressions;

namespace MultiCredCard.Services
{
    public class UsuarioService
    {
        public Usuario Get(Expression<Func<Usuario, bool>> predicate)
        {
            return new Usuario("");
        }

        public Usuario Update(Usuario usuario)
        {
            return usuario;
        }
    }
}

using System;
using System.Linq.Expressions;

namespace MultiCredCard.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario Get(Expression<Func<Usuario, bool>> predicate);
        Usuario Update(Usuario usuario);
    }
}

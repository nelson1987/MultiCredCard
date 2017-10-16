using System;
using System.Linq;
using System.Linq.Expressions;

namespace MultiCredCard.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario Get(Expression<Func<Usuario, bool>> predicate);
        IQueryable<Usuario> ToList(Expression<Func<Usuario, bool>> predicate);
        Usuario Add(Usuario entidade);
        void Edit(Expression<Func<Usuario, bool>> predicate, Usuario entidade);
    }
}

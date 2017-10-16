using System;
using System.Linq.Expressions;
using MultiCredCard.Domain;
using MultiCredCard.Domain.Interfaces.Repositories;

namespace MultiCredCard.Repositories
{
    public class UsuarioRepository : DefaultRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository() : base("Usuario")
        {
        }

        public void Edit(Expression<Func<Usuario, bool>> predicate, Usuario entidade)
        {
            //Edit(predicate, new UpdateDefinition<Usuario>(entidade))
        }
    }
}

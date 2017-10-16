using MultiCredCard.Domain;
using MultiCredCard.Domain.Interfaces.Repositories;
using MultiCredCard.Domain.Interfaces.Services;
using System;
using System.Linq.Expressions;

namespace MultiCredCard.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Usuario Get(Expression<Func<Usuario, bool>> predicate)
        {
            return _repository.Get(predicate);
        }

        public Usuario Update(Usuario usuario)
        {
            _repository.Edit(x=>x.Login == usuario.Login, usuario);
            return usuario;
        }
    }
}

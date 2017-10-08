using MultiCredCard.Domain;
using MultiCredCard.Repositories;
using System;
using System.Linq.Expressions;

namespace MultiCredCard.Services
{
    public class UsuarioService
    {
        private UsuarioRepository usuarioRepository;
        public UsuarioService()
        {
            usuarioRepository = new UsuarioRepository();
        }

        public Usuario Get(Expression<Func<Usuario, bool>> predicate)
        {
            return usuarioRepository.Get(predicate);
        }

        public Usuario Update(Usuario usuario)
        {
            return usuario;
            //return usuarioRepository.Edit(x=>x.Login == usuario.Login, usuario);
        }
    }
}

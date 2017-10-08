using MultiCredCard.Domain;

namespace MultiCredCard.Repositories
{
    public class UsuarioRepository : DefaultRepository<Usuario>
    {
        public UsuarioRepository() : base("Usuario")
        {

        }
    }
}

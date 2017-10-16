
using System;

namespace MultiCredCard.Domain.Entities
{
    public class Compra
    {
        public Usuario Usuario { get; private set; }
        public int Valor { get; private set; }

        public Compra(Usuario usuario, int v)
        {
            Usuario = usuario;
            Valor = v;
        }

        public void RealizarPagamento()
        {
            Usuario.AdicionarCompra(this);
            throw new NotImplementedException();
        }
    }
}

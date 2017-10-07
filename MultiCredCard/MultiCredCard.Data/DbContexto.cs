using MultiCredCard.Domain;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MultiCredCard.Data
{
    public class DbContexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
    }
}

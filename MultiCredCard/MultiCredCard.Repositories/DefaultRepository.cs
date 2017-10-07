using MultiCredCard.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiCredCard.Repositories
{
    public abstract class DefaultRepository<T> where T : class
    {
        public T Get(Expression<Func<T, bool>> predicate)
        {
            using (var contexto = new DbContexto())
            {
                return contexto.Set<T>().FirstOrDefault(predicate);
            }
        }
        public IQueryable<T> ToList(Expression<Func<T, bool>> predicate)
        {
            using (var contexto = new DbContexto())
            {
                return contexto.Set<T>().Where(predicate);
            }
        }
        public T Add(T entidade)
        {
            using (var contexto = new DbContexto())
            {
                contexto.Entry<T>(entidade).State = EntityState.Added;
                contexto.SaveChanges();
                return entidade;
            }
        }
        public T Edit(T entidade)
        {
            using (var contexto = new DbContexto())
            {
                contexto.Entry<T>(entidade).State = EntityState.Modified;
                contexto.SaveChanges();
                return entidade;
            }
        }
    }
}

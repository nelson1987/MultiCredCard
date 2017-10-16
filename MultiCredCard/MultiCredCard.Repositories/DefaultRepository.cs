using MongoDB.Driver;
using System;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;

namespace MultiCredCard.Repositories
{
    public abstract class DefaultRepository<T> where T : class
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        private IMongoCollection<T> collection;

        private string GetMongoDbConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MONGOHQ_URL") ??
                ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ??
                "mongodb://localhost/Things";
        }

        public DefaultRepository(string document)
        {

            var url = new MongoUrl(GetMongoDbConnectionString());
            _client = new MongoClient(url);
            _database = _client.GetDatabase(url.DatabaseName);
            collection = _database.GetCollection<T>(document);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return collection.Find(predicate).FirstOrDefault();
        }

        public IQueryable<T> ToList(Expression<Func<T, bool>> predicate)
        {
            return collection.Find(predicate).ToList().AsQueryable();
        }

        public T Add(T entidade)
        {
            collection.InsertOne(entidade);
            return entidade;
        }
        public void Edit(Expression<Func<T, bool>> predicate, UpdateDefinition<T> entidade)
        {
            collection.FindOneAndUpdate(predicate, entidade);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using LiveClinic.SharedKernel.Interfaces.Persistence;
using LiveClinic.SharedKernel.Model;
using MongoDB.Driver;

namespace LiveClinic.SharedKernel.Infrastructure.Persistence
{
    public abstract class DocumentRepository<T> :IDocumentRepository<T>  where T : AggregateRoot
    {
        protected internal readonly IMongoDatabase Database;
        protected internal readonly IMongoCollection<T> DbCollections;

        public IDatabaseSettings DatabaseSettings { get; }

        protected DocumentRepository(IDatabaseSettings settings)
        {
            DatabaseSettings = settings;

            var collectionName = GetCollectionName();
            var client = new MongoClient(settings.ConnectionString);
            Database = client.GetDatabase(settings.DatabaseName);
            DbCollections = Database.GetCollection<T>(collectionName);
        }

        public async Task Create(T entity)
        {
            await DbCollections.InsertOneAsync(entity);
        }

        public async Task<T> Read(string id)
        {
            var entity =await  DbCollections.FindAsync(x => x.Id == id);
            return entity.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> Read()
        {
            var entities = await DbCollections.FindAsync(x => true);
            return entities.ToList();
        }

        public Task<IEnumerable<T>> Read(Expression<Func<T, bool>> predicate)
        {
            var entities =  DbCollections
                .AsQueryable()
                .Where(predicate.Compile())
                .ToList();

            return Task.FromResult<IEnumerable<T>>(entities);
        }

        public async Task Update(T entity)
        {
            await DbCollections.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task Delete(T entity)
        {
            await DbCollections.DeleteOneAsync(x => x.Id == entity.Id);
        }

        private string GetCollectionName()
        {
            var obj = System.Runtime.Serialization.FormatterServices
                .GetUninitializedObject(typeof(T)) as AggregateRoot;
            return obj?.PreferredDocName;
        }
    }
}

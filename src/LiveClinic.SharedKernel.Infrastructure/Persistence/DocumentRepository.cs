using System.Collections.Generic;
using System.Threading.Tasks;
using LiveClinic.SharedKernel.Interfaces.Persistence;
using LiveClinic.SharedKernel.Model;
using MongoDB.Driver;

namespace LiveClinic.SharedKernel.Infrastructure.Persistence
{
    public abstract class DocumentRepository<T> :IDocumentRepository<T>  where T : AggregateRoot, new()
    {
        protected internal readonly IMongoDatabase Database;
        protected internal readonly IMongoCollection<T> DbCollections;

        public object DatabaseContext { get; }
        public string CollectionName { get; }

        protected DocumentRepository(IDatabaseSettings settings)
        {
            CollectionName = new T().PreferredDocName;
            var client = new MongoClient(settings.ConnectionString);
            DatabaseContext = Database = client.GetDatabase(settings.DatabaseName);
            DbCollections = Database.GetCollection<T>(CollectionName);
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

        public async Task Update(T entity)
        {
            await DbCollections.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task Delete(T entity)
        {
            await DbCollections.DeleteOneAsync(x => x.Id == entity.Id);
        }

    }
}

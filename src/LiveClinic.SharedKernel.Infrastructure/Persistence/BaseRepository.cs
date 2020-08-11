using System.Collections.Generic;
using System.Threading.Tasks;
using LiveClinic.SharedKernel.Interfaces.Persistence;
using LiveClinic.SharedKernel.Model;
using MongoDB.Driver;

namespace LiveClinic.SharedKernel.Infrastructure.Persistence
{
    public abstract class BaseRepository<T> :IRepository<T>  where T : AggregateRoot
    {
        protected internal readonly IMongoCollection<T> DbCollections;

        protected BaseRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            DbCollections = database.GetCollection<T>(nameof(T));
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

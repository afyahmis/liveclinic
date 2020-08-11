using System.Collections.Generic;
using System.Threading.Tasks;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Interfaces.Persistence
{
    public interface IDocumentRepository<T> where T : AggregateRoot
    {
        IDatabaseSettings DatabaseSettings { get; }
        Task Create(T entity);
        Task<T> Read(string id);
        Task<IEnumerable<T>> Read();
        Task Update(T entity);
        Task Delete(T entity);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Interfaces.Persistence
{
    public interface IRepository<T>  where T : AggregateRoot
    {
        Task Create(T entity);
        Task<T> Read(string id);
        Task<IEnumerable<T>> Read();
        Task Update(T entity);
        Task Delete(T entity);
    }
}

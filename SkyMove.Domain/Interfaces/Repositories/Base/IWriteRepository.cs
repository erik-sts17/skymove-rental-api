using SkyMove.Domain.Entities;

namespace SkyMove.Domain.Interfaces.Repositories.Base
{
    public interface IWriteRepository<T> where T : Entity
    {
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
    }
}
using SkyMove.Domain.Entities;

namespace SkyMove.Domain.Interfaces.Repositories.Base
{
    public interface IReadRepository<T> where T : Entity
    {
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
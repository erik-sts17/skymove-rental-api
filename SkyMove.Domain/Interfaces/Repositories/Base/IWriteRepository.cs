using SkyMove.Domain.Entities;
using System.Linq.Expressions;

namespace SkyMove.Domain.Interfaces.Repositories.Base
{
    public interface IWriteRepository<TEntity, TDto> where TEntity : Entity
    {
        Task<Guid> InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Expression<Func<TDto, bool>> where);
    }
}
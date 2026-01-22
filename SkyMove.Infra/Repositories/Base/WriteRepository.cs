using LinqToDB;
using SkyMove.Domain.Entities;
using SkyMove.Domain.Interfaces.Repositories.Base;
using SkyMove.Infra.Contexts;

namespace SkyMove.Infra.Repositories.Base
{
    public class WriteRepository<T>(WiteContext context) : IWriteRepository<T> where T : Entity
    {
        private readonly WiteContext _context = context;

        public async Task Delete(Guid id)
        {
            await _context.GetTable<T>()
                          .Where(x => x.Id == id)
                          .Set(x => x.Active, false)
                          .UpdateAsync();
        }

        public async Task Insert(T entity)
        {
            await _context.InsertAsync(entity);
        }

        public async Task Update(T entity)
        {
            await _context.UpdateAsync(entity);
        }
    }
}

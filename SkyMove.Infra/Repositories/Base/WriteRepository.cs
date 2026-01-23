using AutoMapper;
using LinqToDB;
using SkyMove.Domain.Entities;
using SkyMove.Domain.Interfaces.Repositories.Base;
using SkyMove.Infra.Contexts;
using System.Linq.Expressions;

namespace SkyMove.Infra.Repositories.Base
{
    public class WriteRepository<TEntity, TDto>(WriteContext context, IMapper mapper) : IWriteRepository<TEntity, TDto> 
        where TEntity : Entity
        where TDto : class
    {
        private readonly WriteContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task DeleteAsync(Expression<Func<TDto, bool>> where)
        {
            await _context.GetTable<TDto>()
                          .Where(where)
                          .DeleteAsync();
        }

        public async Task<Guid> InsertAsync(TEntity entity)
        {
            var dto = _mapper.Map<TDto>(entity);
            await _context.InsertAsync(dto);
            return entity.Id;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var dto = _mapper.Map<TDto>(entity);
            await _context.UpdateAsync(dto);
        }
    }
}

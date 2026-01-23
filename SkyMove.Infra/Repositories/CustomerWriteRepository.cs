using AutoMapper;
using SkyMove.Domain.Entities;
using SkyMove.Domain.Interfaces.Repositories;
using SkyMove.Infra.Contexts;
using SkyMove.Infra.Dtos;
using SkyMove.Infra.Repositories.Base;

namespace SkyMove.Infra.Repositories
{
    public class CustomerWriteRepository(WriteContext context, IMapper mapper) : WriteRepository<Customer, CustomerDto>(context, mapper), ICustomerWriteRepository
    {
        public async Task DeleteAsync(Guid id)
        {
            await DeleteAsync(x => x.Id == id);
        }
    }
}
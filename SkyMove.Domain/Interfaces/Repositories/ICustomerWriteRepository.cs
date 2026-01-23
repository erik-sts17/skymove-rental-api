using SkyMove.Domain.Entities;

namespace SkyMove.Domain.Interfaces.Repositories
{
    public interface ICustomerWriteRepository
    {
        Task<Guid> InsertAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
    }
}
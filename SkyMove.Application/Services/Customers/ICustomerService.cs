using SkyMove.Application.Dtos.Customer;

namespace SkyMove.Application.Services.Customers
{
    public interface ICustomerService
    {
        Task<Guid> Insert(CreateCustomerRequest customer);
        Task Update();
    }
}
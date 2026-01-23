using AutoMapper;
using SkyMove.Application.Dtos.Customer;
using SkyMove.Domain.Entities;
using SkyMove.Domain.Interfaces.Repositories;

namespace SkyMove.Application.Services.Customers
{
    public class CustomerService(ICustomerWriteRepository writeRepository, IMapper mapper) : ICustomerService
    {
        private readonly ICustomerWriteRepository _writeRepository = writeRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Guid> Insert(CreateCustomerRequest customer)
        {
            return await _writeRepository.InsertAsync(_mapper.Map<Customer>(customer));
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}

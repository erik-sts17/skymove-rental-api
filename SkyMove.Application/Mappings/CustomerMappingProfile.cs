using AutoMapper;
using SkyMove.Application.Dtos.Customer;
using SkyMove.Domain.Entities;
using SkyMove.Domain.ValueObjects;

namespace SkyMove.Application.Mappings
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CreateCustomerRequest, Customer>()
                .ForMember(x => x.Name, src => src.MapFrom(x => new Name(x.FirstName, x.LastName)))
                .ForMember(x => x.Document, src => src.MapFrom(x => new Document(x.Cpf)))
                .ForMember(x => x.Email, src => src.MapFrom(x => new Email(x.Email)));
        }
    }
}

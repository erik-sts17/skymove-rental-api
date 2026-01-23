using AutoMapper;
using SkyMove.Domain.Entities;
using SkyMove.Infra.Dtos;

namespace SkyMove.Infra.Mappings
{
    public class CustomerDtoMappingProfile : Profile
    {
        public CustomerDtoMappingProfile()
        {
            CreateMap<Customer, CustomerDto>()
                 .ForMember(x => x.Name, src => src.MapFrom(x => x.Name.ToString()))
                 .ForMember(x => x.Document, src => src.MapFrom(x => x.Document.Number))
                 .ForMember(x => x.Email, src => src.MapFrom(x => x.Email.Address));
        }
    }
}
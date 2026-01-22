using LinqToDB;
using LinqToDB.Data;
using SkyMove.Infra.Dtos;

namespace SkyMove.Infra.Contexts
{
    public class WiteContext(DataOptions<WiteContext> options) : DataConnection(options.Options)
    {
        public ITable<CustomerDto> Customers => this.GetTable<CustomerDto>();
        public ITable<AddressDto> Addresses => this.GetTable<AddressDto>();
    }
}
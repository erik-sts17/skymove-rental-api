using LinqToDB.Mapping;

namespace SkyMove.Infra.Dtos
{
    [Table("CUSTOMER")]
    public class CustomerDto
    {
        [Column("ID"), PrimaryKey, Identity]
        public Guid Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; } = default!;

        [Column("DOCUMENT")]
        public string Document { get; set; } = default!;

        [Column("EMAIL")]
        public string Email { get; set; } = default!;

        [Column("PHONE_NUMBER")]
        public string PhoneNumber { get; set; } = default!;

        [Column("BIRTHDAY")]
        public DateTime Birthday { get; set; }

        [Column("ADDRESS_ID")]
        public long AddressId { get; set; }

        [Association(ThisKey = nameof(AddressId), OtherKey = nameof(AddressDto.Id), CanBeNull = false)]
        public AddressDto? Address { get; set; }
    }
}

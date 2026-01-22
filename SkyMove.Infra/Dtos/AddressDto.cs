using LinqToDB.Mapping;

namespace SkyMove.Infra.Dtos
{
    [Table("ADDRESS")]
    public class AddressDto
    {
        [Column("ID"), PrimaryKey, Identity]
        public long Id { get; set; }

        [Column("CEP"), NotNull]
        public string Cep { get; set; } = default!;

        [Column("LOGRADOURO"), NotNull]
        public string Logradouro { get; set; } = default!;

        [Column("BAIRRO"), NotNull]
        public string Bairro { get; set; } = default!;

        [Column("UF"), NotNull]
        public string Uf { get; set; } = default!;

        [Column("NUMERO"), NotNull]
        public string Numero { get; set; } = default!;

        [Column("COMPLEMENTO"), Nullable]
        public string? Complemento { get; set; }
    }
}

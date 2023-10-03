using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Infra.Configurations;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("TBENDERECO");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Cep).HasColumnType("VARCHAR(10)").IsRequired();
        builder.Property(p => p.Estado).HasColumnType("VARCHAR(30)").IsRequired();
        builder.Property(p => p.Cidade).HasColumnType("VARCHAR(30)").IsRequired();
        builder.Property(p => p.Bairro).HasColumnType("VARCHAR(30)").IsRequired();
        builder.Property(p => p.Logradouro).HasColumnType("VARCHAR(30)").IsRequired();
        builder.Property(p => p.Numero).HasColumnType("VARCHAR(10)").IsRequired();
        builder.Property(p => p.Complemento).HasColumnType("VARCHAR(10)").IsRequired();        
    }
}

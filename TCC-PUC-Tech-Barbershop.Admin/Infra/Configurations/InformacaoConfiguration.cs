using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Infra.Configurations;

public class InformacaoConfiguration : IEntityTypeConfiguration<Informacao>
{
    public void Configure(EntityTypeBuilder<Informacao> builder)
    {
        builder.ToTable("TBINFORMACAO");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome).HasColumnType("VARCHAR(20)").IsRequired();
        builder.Property(p => p.Sobrenome).HasColumnType("VARCHAR(20)").IsRequired();
        builder.Property(p => p.Sexo).HasColumnType("VARCHAR(20)").IsRequired();
        builder.Property(p => p.Descricao).HasColumnType("VARCHAR(20)").IsRequired(false);
    }
}

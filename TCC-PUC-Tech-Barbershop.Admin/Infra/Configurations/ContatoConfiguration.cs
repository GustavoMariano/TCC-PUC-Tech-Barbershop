using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Infra.Configurations;

public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.ToTable("TBCONTATO");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Celular).HasColumnType("VARCHAR(20)").IsRequired(false);
        builder.Property(p => p.Email).HasColumnType("VARCHAR(50)").IsRequired(false);
    }
}

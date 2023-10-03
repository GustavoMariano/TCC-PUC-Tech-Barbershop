using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Infra.Configurations;

public class AtendimentoConfiguration : IEntityTypeConfiguration<Atendimento>
{
    public void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        builder.ToTable("TBATENDIMENTO");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.BarbeiroId).HasColumnType("VARCHAR(10)").IsRequired(false);
        builder.Property(p => p.ClienteId).HasColumnType("INT").IsRequired(false);
        builder.Property(p => p.Data).HasColumnType("VARCHAR(30)").IsRequired();
        builder.Property(p => p.Hora).HasColumnType("VARCHAR(30)").IsRequired();

        builder.HasOne(p => p.Barbeiro).WithMany(p => p.Atendimentos);
        builder.HasOne(p => p.Cliente).WithMany(p => p.Atendimentos);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Infra.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("TBUSUARIO");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Login).HasColumnType("VARCHAR(20)").IsRequired();
        builder.Property(p => p.Senha).HasColumnType("VARCHAR(20)").IsRequired();
        builder.Property(p => p.TipoUsuario).HasColumnType("VARCHAR(20)").IsRequired();

        builder.HasOne(p => p.Contato);
        builder.HasOne(p => p.Endereco);
        builder.HasOne(p => p.Informacoes);
    }
}

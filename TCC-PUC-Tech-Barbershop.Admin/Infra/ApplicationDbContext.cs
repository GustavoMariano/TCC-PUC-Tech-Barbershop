using Microsoft.EntityFrameworkCore;
using TCC_PUC_Tech_Barbershop.Admin.Models;

namespace TCC_PUC_Tech_Barbershop.Admin.Infra;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Barbeiro> Barbeiros { get; set; }
    public DbSet<Agenda> Agendas { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Informacao> Informacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Atendimento
        modelBuilder.Entity<Atendimento>()
        .HasOne(a => a.Cliente)
        .WithMany()
        .HasForeignKey(a => a.ClienteId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Atendimento>()
        .HasOne(a => a.Barbeiro)
        .WithMany()
        .HasForeignKey(a => a.BarbeiroId)
        .OnDelete(DeleteBehavior.NoAction);
        #endregion Atendimento

        #region Comentario
        modelBuilder.Entity<Comentario>()
        .HasOne(c => c.Cliente)
        .WithMany()
        .HasForeignKey(c => c.ClienteId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Comentario>()
        .HasOne(c => c.Barbeiro)
        .WithMany()
        .HasForeignKey(c => c.BarbeiroId)
        .OnDelete(DeleteBehavior.NoAction);
        #endregion
    }
}

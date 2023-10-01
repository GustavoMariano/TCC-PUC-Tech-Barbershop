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
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCC_PUC_Tech_Barbershop.Admin.Infra;

#nullable disable

namespace TCC_PUC_Tech_Barbershop.Admin.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231001025054_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Atendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BarbeiroId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BarbeiroId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BarbeiroId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BarbeiroId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.FormasPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FormaPagamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FormasPagamento");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Informacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Informacoes");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContatoId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("InformacoesId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("InformacoesId");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Barbeiro", b =>
                {
                    b.HasBaseType("TCC_PUC_Tech_Barbershop.Admin.Models.Usuario");

                    b.Property<int>("AgendaId")
                        .HasColumnType("int");

                    b.Property<int>("FormasAceitasId")
                        .HasColumnType("int");

                    b.HasIndex("AgendaId");

                    b.HasIndex("FormasAceitasId");

                    b.HasDiscriminator().HasValue("Barbeiro");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Cliente", b =>
                {
                    b.HasBaseType("TCC_PUC_Tech_Barbershop.Admin.Models.Usuario");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Atendimento", b =>
                {
                    b.HasOne("TCC_PUC_Tech_Barbershop.Admin.Models.Barbeiro", "Barbeiro")
                        .WithMany()
                        .HasForeignKey("BarbeiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TCC_PUC_Tech_Barbershop.Admin.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barbeiro");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Comentario", b =>
                {
                    b.HasOne("TCC_PUC_Tech_Barbershop.Admin.Models.Barbeiro", "Barbeiro")
                        .WithMany()
                        .HasForeignKey("BarbeiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TCC_PUC_Tech_Barbershop.Admin.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barbeiro");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Usuario", b =>
                {
                    b.HasOne("TCC_PUC_Tech_Barbershop.Admin.Models.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TCC_PUC_Tech_Barbershop.Admin.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TCC_PUC_Tech_Barbershop.Admin.Models.Informacao", "Informacoes")
                        .WithMany()
                        .HasForeignKey("InformacoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato");

                    b.Navigation("Endereco");

                    b.Navigation("Informacoes");
                });

            modelBuilder.Entity("TCC_PUC_Tech_Barbershop.Admin.Models.Barbeiro", b =>
                {
                    b.HasOne("TCC_PUC_Tech_Barbershop.Admin.Models.Agenda", "Agenda")
                        .WithMany()
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TCC_PUC_Tech_Barbershop.Admin.Models.FormasPagamento", "FormasAceitas")
                        .WithMany()
                        .HasForeignKey("FormasAceitasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agenda");

                    b.Navigation("FormasAceitas");
                });
#pragma warning restore 612, 618
        }
    }
}

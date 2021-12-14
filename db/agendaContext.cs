using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Agenda.db
{
    public partial class agendaContext : DbContext
    {
        public agendaContext()
        {
        }
        public agendaContext(DbContextOptions<agendaContext> options)
            : base(options)
        {
        }
        public virtual DbSet<contato> contatos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
    if (!optionsBuilder.IsConfigured)
        {
        optionsBuilder.UseMySQL("server=localhost;port=3307;user=root;password=root;database=agenda");
        }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>(entity =>
            {
                entity.ToTable("contato");
                entity.HasIndex(e => e.Nome, "nome_UNIQUE")
                    .IsUnique();
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Estrelas).HasColumnName("estrelas");
                entity.Property(e => e.Fone)
                    .HasMaxLength(20)
                    .HasColumnName("fone");
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
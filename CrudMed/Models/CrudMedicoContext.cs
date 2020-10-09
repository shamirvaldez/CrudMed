using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudMed.Models
{
    public partial class CrudMedicoContext : DbContext
    {
        public CrudMedicoContext()
        {
        }

        public CrudMedicoContext(DbContextOptions<CrudMedicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CondicionMedica> CondicionMedica { get; set; }
        public virtual DbSet<Registro> Registro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
              //  optionsBuilder.UseSqlServer("Server=DESKTOP-6H08URB;Database=CrudMedico;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CondicionMedica>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Diagnostico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdCondicionMed)
                    .HasColumnName("Id_CondicionMed")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Tratamiento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCondicionMedNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCondicionMed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGISTRO_MED");
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.IdCondicionMed).HasColumnName("Id_CondicionMed");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

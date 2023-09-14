using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Veterinaria.Controllers;

namespace Veterinaria.Models
{
    public partial class VeterinariaContext : DbContext
    {
        public VeterinariaContext()
        {
        }

        public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comidum> Comida { get; set; } = null!;
        public virtual DbSet<Dueño> Dueños { get; set; } = null!;
        public virtual DbSet<Mascota> Mascotas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-TCBHHF7S;Database=Veterinaria; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comidum>(entity =>
            {
                entity.HasKey(e => e.IdComida);

                entity.Property(e => e.IdComida)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idComida");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dueño>(entity =>
            {
                entity.HasKey(e => e.Iddueños);

                entity.Property(e => e.Iddueños)
                    .HasMaxLength(50)
                    .HasColumnName("iddueños")
                    .IsFixedLength();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(e => e.Idmascotas);

                entity.Property(e => e.Idmascotas)
                    .ValueGeneratedNever()
                    .HasColumnName("idmascotas");

                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .HasColumnName("color")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Raza)
                    .HasMaxLength(10)
                    .HasColumnName("raza")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

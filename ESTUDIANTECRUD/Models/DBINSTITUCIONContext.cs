using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESTUDIANTECRUD.Models
{
    public partial class DBINSTITUCIONContext : DbContext
    {
        public DBINSTITUCIONContext()
        {
        }

        public DBINSTITUCIONContext(DbContextOptions<DBINSTITUCIONContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Materium> Materia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__estudian__E0B2763C1EA191FD");

                entity.ToTable("estudiante");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.CedulaEstudiante)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cedula_estudiante");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.NombreEstudiante)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_estudiante");

                entity.HasOne(d => d.oMateria)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdMateria)
                    .HasConstraintName("FK__estudiant__id_ma__3B75D760");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.HasKey(e => e.IdMateria)
                    .HasName("PK__Materia__7E03FD398615A20C");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.CodigoCurso)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo_curso");

                entity.Property(e => e.NombreMateria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_materia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
